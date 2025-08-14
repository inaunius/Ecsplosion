using System;
using System.Collections.Generic;
using Inaunius.Ecsplosion.Static.Enums;

namespace Inaunius.Ecsplosion.Architecture.Services.ProgressSaveLoad
{
    [Serializable]
    public struct ProgressSnapshot : IProgressSnapshot
    {
        public float Balance { get; set; }

        public Dictionary<BusinessId, BusinessProgress> Businesses { get; set; }

        public Dictionary<UpgradeId, UpgradeProgress> Upgrades { get; set; }
    }

    [Serializable]
    public struct BusinessProgress : IBusinessProgress
    {
        public int DevelopmentLvl { get; set; }

        public float IncomeSecondsLeft { get; set; }
    }

    [Serializable]
    public struct UpgradeProgress : IUpgradeProgress
    {
        public int DevelopmentLvl { get; set; }
    }

    public interface IProgressSnapshot
    {
        float Balance { get; }

        Dictionary<BusinessId, BusinessProgress> Businesses { get; }

        Dictionary<UpgradeId, UpgradeProgress> Upgrades { get; }
    }

    public interface IBusinessProgress
    {
        int DevelopmentLvl { get; }

        float IncomeSecondsLeft { get; }
    }

    public interface IUpgradeProgress
    {
        int DevelopmentLvl { get; }
    }
}