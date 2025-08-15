using System;
using System.Collections.Generic;
using System.Linq;
using Leopotam.EcsLite;


namespace Inaunius.Ecsplosion.Common.Extensions
{
    public static class EcsExtensions
    {
        public static int GetSingle(this EcsFilter self)
        {
            if (self.GetEntitiesCount() != 1)
            {
                throw new InvalidOperationException($"There are more than 1 component!");
            }

            return self.GetEnumerator().Current;
        }
    }

}
