using System;
using System.Linq;
using Inaunius.Ecsplosion.Architecture.Services.ProgressSaveLoad;
using Inaunius.Ecsplosion.Configs;
using Inaunius.Ecsplosion.Static;
using Inaunius.Ecsplosion.Static.Enums;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace Inaunius.Ecsplosion.UIView
{
    public class BusinessCardUIView : MonoBehaviour
    {
        const string LvlTextTemplate = "LVL:\n{0}";

        const string IncomeTextTemplate = "Доход:\n{0}";

        const string LvlUpBuittonTextTemplate = "LVL UP:\n{0}";

        const string UpgradeButtonsTextTemplate = "{0}\nДоход: +{1}%";

        const string UpgradeButtonsPriceTextTemplate = "Цена: {0}$";

        const string UpgradeButtonsBoughtTextTemplate = "Куплено";

        [SerializeField] private TextMeshProUGUI _nameText;

        [SerializeField] private TextMeshProUGUI _lvlText;

        [SerializeField] private TextMeshProUGUI _incomeText;

        [SerializeField] private TextMeshProUGUI _lvlUpButtonText;

        [SerializeField] private TextMeshProUGUI _upgrade1ButtonText;

        [SerializeField] private TextMeshProUGUI _upgrade2ButtonText;

        [SerializeField] private Button _lvlUpButton;

        [SerializeField] private Button _upgrade1Button;

        [SerializeField] private Button _upgrade2Button;

        private BusinessId _businessId;

        private StringsCfg _stringsConfig;

        private InGameCfg _inGameConfig;

        public void Initialize(BusinessId id, StringsCfg config, InGameCfg inGameConfig)
        {
            _businessId = id;
            _stringsConfig = config;
            _inGameConfig = inGameConfig;
        }

        public void UpdateFromSnapshot(ProgressSnapshot progress)
        {
            int currentBusinessLvl = progress.Businesses[_businessId].DevelopmentLvl;
            UpgradeId upgrade1Id = _inGameConfig.BusinessConfigs.AsDictionary[_businessId].Config.Upgrade1;
            UpgradeId upgrade2Id = _inGameConfig.BusinessConfigs.AsDictionary[_businessId].Config.Upgrade2;

            _nameText.text = _stringsConfig.BusinessNames.AsDictionary[_businessId];
            _lvlText.text = string.Format(LvlTextTemplate, currentBusinessLvl);
            _incomeText.text = GetIncomeText(progress, currentBusinessLvl);
            _lvlUpButtonText.text = string.Format
            (
                LvlUpBuittonTextTemplate,
                InGameCalculations.CalculateLvlUpCost(currentBusinessLvl, _inGameConfig.BusinessConfigs.AsDictionary[_businessId].Config.BaseCost)
            );
            _upgrade1ButtonText.text = GetUpgradeButtonText(progress, upgrade1Id);
            _upgrade2ButtonText.text = GetUpgradeButtonText(progress, upgrade2Id);
        }

        private string GetIncomeText(ProgressSnapshot progress, int currentBusinessLvl) => string.Format
            (
                IncomeTextTemplate,
                InGameCalculations.CalculateIncome
                (
                    currentBusinessLvl,
                    _inGameConfig.BusinessConfigs.AsDictionary[_businessId].Config.BaseIncome,
                    progress.Upgrades
                        .Where(upgradeKv => upgradeKv.Value.DevelopmentLvl > 0)
                        .Select(upgradeKv => _inGameConfig.UpgradesConfigs.AsDictionary[upgradeKv.Key].IncomeMultiplierPercent)
                        .ToArray()
                )
            );

        private string GetUpgradeButtonText(ProgressSnapshot progress, UpgradeId upgrade1Id) => string.Format
            (
                UpgradeButtonsTextTemplate,
                _stringsConfig.UpgradeNames.AsDictionary[upgrade1Id],
                progress.Upgrades[upgrade1Id].DevelopmentLvl == 0
                    ? string.Format(UpgradeButtonsPriceTextTemplate, _inGameConfig.UpgradesConfigs.AsDictionary[upgrade1Id].Cost)
                    : UpgradeButtonsBoughtTextTemplate
            );
    }
}
