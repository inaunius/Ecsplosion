using System;
using System.Collections;
using System.Collections.Generic;
using Inaunius.Ecsplosion.Static.Enums;
using UnityEngine;

namespace Inaunius.Ecsplosion.Configs
{
    [CreateAssetMenu(menuName = "_Configs/BusinessCfg")]
    public class BusinessCfg : ScriptableObject
    {
        [field: SerializeField] public BusinessId Id { get; private set; }

        [field: SerializeField] public float IncomeDelaySeconds { get; private set; }

        [field: SerializeField] public float BaseCost { get; private set; }

        [field: SerializeField] public float BaseIncome { get; private set; }

        [field: SerializeField] public BusinessUpgrade[] Upgrades { get; private set; }

    }

    [Serializable]
    public struct BusinessUpgrade
    {
        [field: SerializeField] public UpgradeId Id { get; private set; }

        [field: SerializeField] public float Price { get; private set; }

        [field: SerializeField] public float IncomeMultiplierPercent { get; private set; }
    } 
}
