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
}
