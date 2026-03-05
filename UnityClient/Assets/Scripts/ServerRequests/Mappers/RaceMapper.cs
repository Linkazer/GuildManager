public static class RaceMapper
{
    //RaceDtoGet to RaceData.
    public static RaceData ToRaceData(this RaceDtoGet getData)
    {
        return new RaceData(getData.Id, getData.Name);
    }
}
