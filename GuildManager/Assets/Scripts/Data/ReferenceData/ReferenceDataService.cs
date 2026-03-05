using GuildManager;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Service that loads and provides access to all ReferenceData.
/// </summary>
public static class ReferenceDataService
{
    private const string RequestRaceUrl = "Race";
    private const string RequestJobUrl = "Job";
    private const string RequestEquipmentUrl = "Equipment";

    private static ReferenceDataHandler<RaceData> races;
    private static ReferenceDataHandler<JobData> jobs;
    private static ReferenceDataHandler<EquipmentData> equipments;

    public static ReferenceDataHandler<RaceData> RaceData => races;
    public static ReferenceDataHandler<JobData> JobData => jobs;
    public static ReferenceDataHandler<EquipmentData> EquipmentData => equipments;

    /// <summary>
    /// Load all the data.
    /// </summary>
    /// <returns></returns>
    public static async Task Load()
    {
        races = new ReferenceDataHandler<RaceData>();
        jobs = new ReferenceDataHandler<JobData>();
        equipments = new ReferenceDataHandler<EquipmentData>();

        await FillRaceDataAsync();
        await FillJobDataAsync();
        await FillEquipmentDataAsync();
    }

    private static async Task FillRaceDataAsync()
    {
        List<RaceDtoGet> getResult = await HttpRequests.Get<List<RaceDtoGet>>(RequestRaceUrl);

        if (getResult != null)
        {
            races.AddData(getResult.Select(r => r.ToRaceData()).ToList());
        }
    }

    private static async Task FillJobDataAsync()
    {
        List<JobDtoGet> getResult = await HttpRequests.Get<List<JobDtoGet>>(RequestJobUrl);

        if (getResult != null)
        {
            jobs.AddData(getResult.Select(j => j.ToJobData()).ToList());
        }
    }

    private static async Task FillEquipmentDataAsync()
    {
        List<EquipmentDtoGet> getResult = await HttpRequests.Get<List<EquipmentDtoGet>>(RequestEquipmentUrl);

        if (getResult != null)
        {
            equipments.AddData(getResult.Select(e => e.ToEquipmentData()).ToList());
        }
    }
}
