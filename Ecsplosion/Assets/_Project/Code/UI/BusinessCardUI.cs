using System;
using Inaunius.Ecsplosion.Configs;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace Inaunius.Ecsplosion.UI
{
    public class BusinessCardUI : MonoBehaviour
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

        private StringsCfg _stringsConfig;

        public void SetupStrings(StringsCfg config)
        {
            _stringsConfig = config;
        }
    }
}
