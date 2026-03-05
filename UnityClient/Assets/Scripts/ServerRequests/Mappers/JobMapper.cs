public static class JobMapper
{
    //JobDtoGet to JobData.
    public static JobData ToJobData(this JobDtoGet getData)
    {
        return new JobData(getData.Id, getData.Name);
    }
}
