public static class JobMapper
{
    public static JobData ToJobData(this DtoGetJob getData)
    {
        return new JobData(getData.Id, getData.Name);
    }
}
