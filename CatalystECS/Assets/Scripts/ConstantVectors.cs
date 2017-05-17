using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ConstantVectors
{
    #region Direction Dictionary
    public static readonly Dictionary<int, Vector2> Directions = new Dictionary<int, Vector2>()
    {
        { 1, new Vector2(   0,  1)                                  },
        { 2, new Vector2(   1 / Mathf.Sqrt(2),  1 / Mathf.Sqrt(2))  },
        { 3, new Vector2(   1,  0)                                  },
        { 4, new Vector2(   1 / Mathf.Sqrt(2), -1 / Mathf.Sqrt(2))  },
        { 5, new Vector2(   0, -1)                                  },
        { 6, new Vector2(   -1 / Mathf.Sqrt(2), -1 / Mathf.Sqrt(2)) },
        { 7, new Vector2(   -1,  0)                                 },
        { 8, new Vector2(   -1 / Mathf.Sqrt(2),  1 / Mathf.Sqrt(2)) }
    };

    public static readonly Dictionary<int, Vector3> Origins = new Dictionary<int, Vector3>()
    {
        { 1, new Vector3(  0,   1,    0) },
        { 2, new Vector3(  1,   1,    0) },
        { 3, new Vector3(  1,   0,    0) },
        { 4, new Vector3(  1,   -1,   0) },
        { 5, new Vector3(  0,   -1,   0) },
        { 6, new Vector3(  -1,  -1,   0) },
        { 7, new Vector3(  -1,  0,    0) },
        { 8, new Vector3(  -1,  1,    0) }
    };
    #endregion

    #region HelpFunctions

    public static int HandleIndex(int index, int amount)
    {
        if (index + amount > 8)
        {
            return (index + amount) - 8;
        }
        else if (index + amount < 1)
        {
            return (index + amount) + 8;
        }
        else
        {
            return index + amount;
        }
    }

    public static int HandleIndex(int index)
    {
        if (index > 8)
        {
            return index - 8;
        }

        else if (index < 0)
        {
            return index + 8;
        }
        return index;
    }

    #endregion
}
