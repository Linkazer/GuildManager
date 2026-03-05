namespace GuildManagerServer.Api.Models;

/// <summary>
/// Model for Equipments. Defines the Equipment data stored in the Database.
/// </summary>
public class EquipmentModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
