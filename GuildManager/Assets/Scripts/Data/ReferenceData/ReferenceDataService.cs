using GuildManager;
using NUnit.Framework.Internal;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

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
        List<DtoGetRace> getResult = await HttpRequests.Get<List<DtoGetRace>>(RequestRaceUrl);

        races.SetData(getResult.Select(r => r.ToRaceData()).ToList());
    }

    private static async Task FillJobDataAsync()
    {
        List<DtoGetJob> getResult = await HttpRequests.Get<List<DtoGetJob>>(RequestJobUrl);

        jobs.SetData(getResult.Select(j => j.ToJobData()).ToList());
    }

    private static async Task FillEquipmentDataAsync()
    {
        List<DtoGetEquipment> getResult = await HttpRequests.Get<List<DtoGetEquipment>>(RequestEquipmentUrl);

        equipments.SetData(getResult.Select(e => e.ToEquipmentData()).ToList());
    }
}
