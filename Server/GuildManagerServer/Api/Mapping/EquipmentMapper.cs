using GuildManagerServer.Api.Dto.EquipmentDto;
using GuildManagerServer.Api.Models;
using GuildManagerServer.Domain;

namespace GuildManagerServer.Api.Mapping;

public static class EquipmentMapper
{
    /// <summary>
    /// Map an EquipmentModel to an Equipment.
    /// </summary>
    /// <param name="model">The Model to map.</param>
    /// <returns></returns>
    public static Equipment ToEquipment(this EquipmentModel model)
    {
        return new Equipment
        {
            Id = model.Id,
            Name = model.Name
        };
    }

    
    public static DtoGetEquipment ToDtoGetEquipment(this Equipment equipment)
    {
        return new DtoGetEquipment
        {
            Id = equipment.Id,
            Name = equipment.Name
        };
    }
}
