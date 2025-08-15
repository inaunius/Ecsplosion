using System;
using System.Collections.Generic;
using Inaunius.Ecsplosion.Static.Enums;
using Inaunius.Ecsplosion.Common.Extensions;
using System.Linq;

namespace Inaunius.Ecsplosion.Architecture.Services.ProgressSaveLoad
{
    [Serializable]
    public struct ProgressSnapshot
    {
        public float Balance { get; set; }

        public SortedDictionary<BusinessId, BusinessProgress> Businesses { get; set; }

        public SortedDictionary<UpgradeId, UpgradeProgress> Upgrades { get; set; }

        public bool IsEqualTo(ProgressSnapshot other)
        {
            if (Balance != other.Balance || Businesses.Count != other.Businesses.Count || Upgrades.Count != other.Upgrades.Count)
            {
                return false;
            }

            return Businesses
                .Zip(other.Businesses, (a, b) => a.Key == b.Key && a.Value.IsEqualToNotAccountingSecondsLeft(b.Value))
                .All(isEqual => isEqual)
                &&
                Upgrades
                .Zip(other.Upgrades, (a, b) => a.Key == b.Key && a.Value.IsEqualTo(b.Value))
                .All(isEqual => isEqual);
        }
    }

    [Serializable]
    public struct BusinessProgress
    {
        public int DevelopmentLvl { get; set; }

        public float IncomeSecondsLeft { get; set; }

        public bool IsEqualToNotAccountingSecondsLeft(BusinessProgress other) => DevelopmentLvl == other.DevelopmentLvl;
    }

    [Serializable]
    public struct UpgradeProgress
    {
        public int DevelopmentLvl { get; set; }

        public bool IsEqualTo(UpgradeProgress other) => DevelopmentLvl == other.DevelopmentLvl;
    }


}