using System;
using GuildManagerServer.Api.Dto;
using GuildManagerServer.Api.Mapping;
using GuildManagerServer.Api.Models;
using GuildManagerServer.Api.Repositories;
using GuildManagerServer.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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

    public async Task<List<Character>> GetAllAsync()
    {
        List<CharacterModel> models = await repository.GetAllModelsAsync();

        return models.Select(c => c.ToCharacter()).ToList();
    }

    public async Task<Character?> GetByIdAsync(int id)
    {
        CharacterModel? model = await repository.GetModelByIdAsync(id);

        if(model == null)
        {
            return null;
        }

        return model.ToCharacter();
    }

    public async Task<Character?> CreateCharacterAsync(DtoPostCharacter characterToCreate)
    {
        RaceModel? raceModel = await raceRepository.GetByIdAsync(characterToCreate.RaceId);
        if(raceModel == null)
        {
            return null;
        }

        JobModel? jobModel = await jobRepository.GetByIdAsync(characterToCreate.JobId);
        if(jobModel == null)
        {
            return null;
        }

        EquipmentModel? equipmentModel = await equipmentRepository.GetByIdAsync(characterToCreate.EquipmentId);
        if(equipmentModel == null)
        {
            return null;
        }

        Character newCharacter = characterToCreate.ToCharacter(raceModel.ToRace(), jobModel.ToJob(), equipmentModel.ToEquipment());

        CharacterModel model = newCharacter.ToModel(raceModel, jobModel, equipmentModel);
        await repository.AddModel(model);

        newCharacter.Id = model.Id;

        return newCharacter;
    }

    public async Task<Character?> UpdateCharacterAsync(int id, DtoPutCharacter updatedCharacter)
    {
        CharacterModel? modelToUpdate = await repository.GetModelByIdAsync(id);

        if(modelToUpdate == null)
        {
            return null;
        }

        Character character = modelToUpdate.ToCharacter();

        //Updates Character. CODE REVIEW : Mettre les setters en private
        character.Name = updatedCharacter.Name;
        character.Level = updatedCharacter.Level;
        character.Strength = updatedCharacter.Strength;
        character.Spirit = updatedCharacter.Spirit;
        character.Presence = updatedCharacter.Presence;
        character.Dexterity = updatedCharacter.Dexterity;
        character.Instinct = updatedCharacter.Instinct;
        character.BodyId = updatedCharacter.BodyId;
        character.HairId = updatedCharacter.HairId;
        character.HairColorId = updatedCharacter.HairColorId;

        if(character.Race.Id != updatedCharacter.RaceId)
        {
            RaceModel? raceModel = await raceRepository.GetByIdAsync(updatedCharacter.RaceId);
            if(raceModel == null)
            {
                return null;
            }

            character.Race = raceModel.ToRace();
        }

        if(character.Job.Id != updatedCharacter.JobId)
        {
            JobModel? jobModel = await jobRepository.GetByIdAsync(updatedCharacter.JobId);
            if(jobModel == null)
            {
                return null;
            }

            character.Job = jobModel.ToJob();
        }

        if(character.Equipment.Id != updatedCharacter.EquipmentId)
        {
            EquipmentModel? equipmentModel = await equipmentRepository.GetByIdAsync(updatedCharacter.EquipmentId);
            if(equipmentModel == null)
            {
                return null;
            }

            character.Equipment = equipmentModel.ToEquipment();
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

        return character;
    }

    public async Task DeleteCharacterAsync(int id)
    {
        await repository.DeleteModelAsync(id);
    }
}
