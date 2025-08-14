using System;
using UnityEngine;

namespace Inaunius.Ecsplosion.Common
{
    public class TickTimer
    {
        private float _timeLeftSeconds;

        public bool IsTimeOut => _timeLeftSeconds == 0f;

        public float TimeLeftSeconds => _timeLeftSeconds;

        public void PassTime(float passedTimeSeconds) =>
            _timeLeftSeconds = Mathf.Max(_timeLeftSeconds - passedTimeSeconds, 0f);

        public void ResetTimer(float timeSeconds)
        {
            if (timeSeconds < 0)
            {
                throw new ArgumentException($"Set time must be >= 0 but it is {timeSeconds}!");
            }
            _timeLeftSeconds = timeSeconds;
        }
    }
}