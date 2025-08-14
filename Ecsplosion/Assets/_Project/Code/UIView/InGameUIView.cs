using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inaunius.Ecsplosion.UIView
{
    public class InGameUIView : MonoBehaviour
    {
        [SerializeField] private BalanceDisplayUIView _balanceDisplay;

        [SerializeField] private Transform _businessCardsParent;

        [SerializeField] private BusinessCardUIView _businessCardPrefab;
    }
}
