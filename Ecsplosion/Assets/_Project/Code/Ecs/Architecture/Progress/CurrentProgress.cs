using System;
using System.Collections.Generic;
using Inaunius.Ecsplosion.Static.Enums;

namespace Inaunius.Ecsplosion.Ecs.Architecture.Progress
{
    [Serializable]
    public struct CurrentProgress : ICurrentProgress
    {
        public float Balance { get; set; }

        public Dictionary<BusinessId, IBusinessProgress> Businesses { get; set; }

        public Dictionary<BusinessId, IUpgradeProgress> Upgrades { get; set; }
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

    public interface ICurrentProgress
    {
        float Balance { get; }

        Dictionary<BusinessId, IBusinessProgress> Businesses { get; }

        Dictionary<BusinessId, IUpgradeProgress> Upgrades { get; }
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