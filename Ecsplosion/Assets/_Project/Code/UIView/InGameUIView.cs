using System.Linq;
using Inaunius.Ecsplosion.Architecture.Services.ProgressSaveLoad;
using Inaunius.Ecsplosion.Configs;
using UnityEngine;

namespace Inaunius.Ecsplosion.UIView
{
    public class InGameUIView : MonoBehaviour
    {
        [SerializeField] private BalanceDisplayUIView _balanceDisplay;

        [SerializeField] private Transform _businessCardsParent;

        [SerializeField] private BusinessCardUIView _businessCardPrefab;

        private BusinessCardUIView[] _cards;

        private InGameCfg _config;

        public void Initialize(InGameCfg config)
        {
            _config = config;
            _cards = config.BusinessConfigs.AsDictionary.Keys
                .Select(_key => Instantiate(_businessCardPrefab, _businessCardsParent))
                .ToArray();
        }

        public void UpdateUIFromSnapshot(ProgressSnapshot snapshot)
        {
            _balanceDisplay.UpdateFromSnapshot(snapshot);
            foreach (var card in _cards)
            {
                card.UpdateFromSnapshot(snapshot);                
            }
        }
    }
}
