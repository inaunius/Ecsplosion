using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Inaunius.Ecsplosion.Common 
{
    [Serializable]
    public class InspectorDictionary<TKey, TValue>
    {
        [SerializeField] private List<KeyValuePairEntry<TKey, TValue>> _entries;
		[SerializeField] private bool _shouldCache = true;
		private Dictionary<TKey, TValue> _cached;

		public Dictionary<TKey, TValue> AsDictionary
        {
			get
            {
                if (!_shouldCache)
                {
                    return _entries.ToDictionary(k => k.Key, v => v.Value);
                }
				_cached ??= _entries.ToDictionary(k => k.Key, v => v.Value);
				return _cached;
			}
		}

		[Serializable]
        private class KeyValuePairEntry<UKey, UValue>
        {
          [field: SerializeField] public UKey Key { get; private set; }
          [field: SerializeField] public UValue Value { get; private set; }
        }
    }
}
