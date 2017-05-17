using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Interfaces;
using UnityEngine;

public static class WeightedRandomization
{
    public static T Choose<T>(List<T> list, float choice) where T : IWeighted
    {
        if (list.Count == 0)
        {
            return default(T);
        }
        int sum = 0;

        foreach (var obj in list)
        {
            for (int i = sum; i < obj.Weight + sum; i++)
            {
                if (i >= choice)
                {
                    return obj;
                }
            }
            sum += obj.Weight;
        }
        return default(T);
    }

    public static int CalculateTotalWeight<T>(List<T> list) where T : IWeighted
    {
        return list.Sum(c => c.Weight);
    }
}
