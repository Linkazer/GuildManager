public static class EquipmentMapper
{
    //EquipmentDtoGet to EquipmentData.
    public static EquipmentData ToEquipmentData(this EquipmentDtoGet getData)
    {
        return new EquipmentData(getData.Id, getData.Name);
    }
}
