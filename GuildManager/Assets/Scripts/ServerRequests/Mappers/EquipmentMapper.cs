public static class EquipmentMapper
{
    public static EquipmentData ToEquipmentData(this DtoGetEquipment getData)
    {
        return new EquipmentData(getData.Id, getData.Name);
    }
}
