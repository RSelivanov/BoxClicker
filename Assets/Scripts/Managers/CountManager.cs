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

    public double PercentageOfNumber(int persent, long number)
    {
        double result = ((double)number * persent) / 100;

        return result;
    }

    public int HalfNumber(int number)
    {
        return Convert.ToInt32(number / 2);
    }

    public long IncrementalOfNumber(long number, int pow)
    {
        return Convert.ToInt64(number * Math.Pow(1.07f, pow));
    }

    public int getCurrentTime()
    {
        return (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
    }
}
