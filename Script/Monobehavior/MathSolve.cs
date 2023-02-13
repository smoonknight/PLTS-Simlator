using UnityEngine;
using System.Collections.Generic;

public class MathSolve
{
    public static float MathPercentage(float valueToPercentage, float maxRange = 1, float minRange = 0.5f)
    {
        float percentage = Mathf.Clamp((valueToPercentage - minRange) / (maxRange - minRange), 0f, 1f);
        return percentage;
    }

    public static float MathAverageOnlyNotNull(List<float> datas)
    {
        float sum = 0;
        float count = 0;

        foreach (float data in datas)
        {
            if (data != 0)
            {
                sum += data;
                count++;
            }
        }

        float average = sum/count;

        return average;
    }
}