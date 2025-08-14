using TMPro;
using UnityEngine;

namespace Inaunius.Ecsplosion.UIView
{
    public class BalanceDisplayUIView : MonoBehaviour
    {
        const string BalanceValueTextTemplate = "{0}$";

        [SerializeField] private TextMeshProUGUI _balanceValueText;

        public void SetBalanceValue(float value) =>
            _balanceValueText.text = string.Format(BalanceValueTextTemplate, value);
    } 
}