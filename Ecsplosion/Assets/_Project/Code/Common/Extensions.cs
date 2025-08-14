using System;
using Leopotam.EcsLite;

public static class EcsExtensions
{
    public static int GetSingle(this EcsFilter filter)
    {
        if (filter.GetEntitiesCount() != 1)
        {
            throw new InvalidOperationException($"There are more than 1 component!");
        }

        return filter.GetEnumerator().Current;
    }
}