using Inaunius.Ecsplosion.Static.Enums;
using UnityEngine;

namespace Inaunius.Ecsplosion.Configs
{
    [CreateAssetMenu(menuName = "_Configs/UpgradeCfg")]
    public class BusinessUpgradeCfg : ScriptableObject
    {
        [field: SerializeField] public UpgradeId Id { get; private set; }

        [field: SerializeField] public float Cost { get; private set; }

        [field: SerializeField] public float IncomeMultiplierPercent { get; private set; }
    } 
}