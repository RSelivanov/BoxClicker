using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountManager : MonoBehaviour
{
    public static CountManager use = null;

    void Awake()
    {
        use = this;
    }

    //---------------------------------

    public int PercentageOfNumber(int persent, int number)
    {
        return Convert.ToInt32(number * persent / 100);
    }

    public int HalfNumber(int number)
    {
        return Convert.ToInt32(number / 2);
    }

    public int IncrementalOfNumber(int number, int pow)
    {
        return Convert.ToInt32(number * Math.Pow(1.07f, pow));
    }
}
