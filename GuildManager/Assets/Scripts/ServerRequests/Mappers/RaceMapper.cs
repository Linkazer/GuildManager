public static class RaceMapper
{
    public static RaceData ToRaceData(this DtoGetRace getData)
    {
        return new RaceData(getData.Id, getData.Name);
    }
}
