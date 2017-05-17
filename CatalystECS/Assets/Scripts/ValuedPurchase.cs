using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Interfaces;
using UnityEngine;
using UnityEngine.EventSystems;

public static class ValuedPurchase
{
    public static bool ValidatePurchase<T>(T obj, int points) where T : IValued
    {
        return obj.Value <= points;
    }

    public static T FindValidPurchase<T>(List<T> list, int points) where T : IValued
    {
        foreach (var obj in list)
        {
            if (obj.Value <= points)
            {
                return obj;
            }
        }

        return default(T);
    }
}
