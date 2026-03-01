using GuildManagerServer.Api.Dto;
using GuildManagerServer.Api.Mapping;
using GuildManagerServer.Api.Models;
using GuildManagerServer.Api.Repositories;
using GuildManagerServer.Api.Results;
using GuildManagerServer.Domain;

namespace GuildManagerServer.Api.Services;

public class CharacterService : ICharacterService
{
    private readonly ICharacterRepository repository;
    private readonly IRaceRepository raceRepository;
    private readonly IJobRepository jobRepository;
    private readonly IEquipmentRepository equipmentRepository;

    public CharacterService(ICharacterRepository nRepository, IRaceRepository nRaceRepository, IJobRepository nJobRepository, IEquipmentRepository nEquipmentRepository)
    {
        repository = nRepository;
        raceRepository = nRaceRepository;
        jobRepository = nJobRepository;
        equipmentRepository = nEquipmentRepository;
    }

    public async Task<Result<List<Character>>> GetAllAsync()
    {
        List<CharacterModel> models = await repository.GetAllModelsAsync();

        return Result<List<Character>>.Success(ResultCode.DataFound, models.Select(c => c.ToCharacter()).ToList());
    }

    public async Task<Result<Character>> GetByIdAsync(int id)
    {
        CharacterModel? model = await repository.GetModelByIdAsync(id);

        if(model == null)
        {
            return Result<Character>.Failure(ResultCode.CharacterNotfound);
        }

        return Result<Character>.Success(ResultCode.DataFound, model.ToCharacter());
    }

    public async Task<Result<Character>> CreateCharacterAsync(DtoPostCharacter characterToCreate)
    {
        RaceModel? raceModel = await raceRepository.GetByIdAsync(characterToCreate.RaceId);
        if(raceModel == null)
        {
            return Result<Character>.Failure(ResultCode.RaceNotFound);
        }

        JobModel? jobModel = await jobRepository.GetByIdAsync(characterToCreate.JobId);
        if(jobModel == null)
        {
            return Result<Character>.Failure(ResultCode.JobNotFound);
        }

        EquipmentModel? equipmentModel = await equipmentRepository.GetByIdAsync(characterToCreate.EquipmentId);
        if(equipmentModel == null)
        {
            return Result<Character>.Failure(ResultCode.EquipmentNotFound);
        }

        try
        {
            Character newCharacter = characterToCreate.ToCharacter(raceModel.ToRace(), jobModel.ToJob(), equipmentModel.ToEquipment());

            CharacterModel model = newCharacter.ToModel(raceModel, jobModel, equipmentModel);
            await repository.AddModel(model);

            newCharacter.SetId(model.Id);

            return Result<Character>.Success(ResultCode.DataCreated, newCharacter);
        }
        catch (ArgumentException ex)
        {
            return Result<Character>.Failure(ResultCode.InvalidCharacterData, ex.Message);
        }
    }

    public async Task<Result<Character>> UpdateCharacterAsync(int id, DtoPutCharacter updatedCharacter)
    {
        CharacterModel? modelToUpdate = await repository.GetModelByIdAsync(id);

        if(modelToUpdate == null)
        {
            return Result<Character>.Failure(ResultCode.CharacterNotfound);
        }

        try
        {
            Character character = modelToUpdate.ToCharacter();

            //Updates Character. CODE REVIEW : Mettre les setters en private
            character.SetName(updatedCharacter.Name);

            character.SetStats(updatedCharacter.Level,
                updatedCharacter.Strength,
                updatedCharacter.Spirit,
                updatedCharacter.Presence,
                updatedCharacter.Dexterity,
                updatedCharacter.Instinct);

            character.SetPersonalisation(updatedCharacter.BodyId,
                updatedCharacter.HairId,
                updatedCharacter.HairColorId);

            if(character.Race.Id != updatedCharacter.RaceId)
            {
                RaceModel? raceModel = await raceRepository.GetByIdAsync(updatedCharacter.RaceId);
                if(raceModel == null)
                {
                    return Result<Character>.Failure(ResultCode.RaceNotFound);;
                }

                character.SetRace(raceModel.ToRace());
            }

            if(character.Job.Id != updatedCharacter.JobId)
            {
                JobModel? jobModel = await jobRepository.GetByIdAsync(updatedCharacter.JobId);
                if(jobModel == null)
                {
                    return Result<Character>.Failure(ResultCode.JobNotFound);;
                }

                character.SetJob(jobModel.ToJob());
            }

            if(character.Equipment.Id != updatedCharacter.EquipmentId)
            {
                EquipmentModel? equipmentModel = await equipmentRepository.GetByIdAsync(updatedCharacter.EquipmentId);
                if(equipmentModel == null)
                {
                    return Result<Character>.Failure(ResultCode.EquipmentNotFound);;
                }

                character.SetEquipment(equipmentModel.ToEquipment());
            }

            //Update Model. CODE REVIEW : Peut être mit à part (Mapper)
            modelToUpdate.Name = character.Name;
            modelToUpdate.Level = character.Level;
            modelToUpdate.Strength = character.Strength;
            modelToUpdate.Spirit = character.Spirit;
            modelToUpdate.Presence = character.Presence;
            modelToUpdate.Dexterity = character.Dexterity;
            modelToUpdate.Instinct = character.Instinct;
            modelToUpdate.BodyId = character.BodyId;
            modelToUpdate.HairId = character.HairId;
            modelToUpdate.HairColorId = character.HairColorId;

            modelToUpdate.RaceId = character.Race.Id;
            modelToUpdate.JobId = character.Job.Id;
            modelToUpdate.EquipmentId = character.Equipment.Id;

            await repository.UpdateModel(modelToUpdate);

            return Result<Character>.Success(ResultCode.SimpleValidate);
        }
        catch (ArgumentException ex)
        {
            return Result<Character>.Failure(ResultCode.InvalidCharacterData, ex.Message);
        }
    }

    public async Task<Result<Character>> DeleteCharacterAsync(int id)
    {
        Result<Character> foundCharacterResult = await GetByIdAsync(id);

        if(foundCharacterResult.Data == null)
        {
            return foundCharacterResult;
        }

        await repository.DeleteModelAsync(id);
        return Result<Character>.Success(ResultCode.SimpleValidate);
    }
}
