using UnityEngine;
using UnityEngine.UI;

namespace Inaunius.Ecsplosion
{
    public class ProgressBar : MonoBehaviour
    {
        [SerializeField, Range(0f, 1f)] private float _progress;

        [SerializeField] private Image _fillImage;

        public float Progress
        {
            get => _progress;
            set
            {
                _progress = value;
                _fillImage.transform.localScale = new Vector3
                (
                    _progress,
                    _fillImage.transform.localScale.y,
                    _fillImage.transform.localScale.z
                );
            }
        }

        private void OnValidate() => Progress = _progress;
    }
}