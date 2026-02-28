using GuildManagerServer.Api.Models;
using GuildManagerServer.Domain;

namespace GuildManagerServer.Api.Mapping;

public static class EquipmentMapping
{
    public static Equipment ToEquipment(this EquipmentModel model)
    {
        return new Equipment
        {
            Id = model.Id,
            Name = model.Name
        };
    }
}
