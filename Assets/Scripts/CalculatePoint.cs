using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculatePoint
{
    //0~1 사이 값 좌표로 조정
    private float weightRatioRatio = 1f;
    public const float weightRatio = 3;

    private float heightRatioRatio = 1f;
    public const float heightRatio = 2;

    private const float sightAngle = 120;

    private float marginRatio = 1f;
    public const float distanceMargin = 0.5f;

    private const int maxDistanceColor = 250;

    public List<Vector3> GetPoint(float[,] data)
    {
        List<Vector3> pointList = new List<Vector3>();

        for(int i = 0; i < data.GetLength(0); i++)
        {
            for(int j = 0; j < data.GetLength(1); j++)
            {
                Vector3 vector3 = GetPoint(data, i, j);
                if(vector3 != Vector3.zero) 
                    pointList.Add(vector3);
            }
        }

        return pointList;
    }

    public Vector3 GetPoint(float[,] data, int h, int w)
    {
        float radian = 360f / data.GetLength(1) * Mathf.Deg2Rad;

        float oneAngle = sightAngle / data.GetLength(0);

        float hightMid = (data.GetLength(0) - 1) / 2;

        if (maxDistanceColor / 255f < data[h, w]) return Vector3.zero;

        float distanceData = data[h, w] + GetDistanceMargin();
        float x = distanceData * Mathf.Sin(radian * w) * GetDistanceRatio();
        float z = distanceData * Mathf.Cos(radian * w) * GetDistanceRatio();

        float y;
        y = distanceData * Mathf.Sin((hightMid - h) * oneAngle * Mathf.Deg2Rad);
        y *= GetHeightRatio();
        return new Vector3(x, y, z);
    }

    public void SetWeightRatio(float ratio)
    {
        weightRatioRatio = ratio;
    }

    public void SetHeightRatio(float ratio)
    {
        heightRatioRatio = ratio;
    }

    public void SetDistanceMargin(float margin)
    {
        marginRatio = margin;
    }



    private float GetDistanceRatio()
    {
        return weightRatio * weightRatioRatio;
    }

    private float GetHeightRatio()
    {
        return heightRatio * heightRatioRatio;
    }

    private float GetDistanceMargin()
    {
        return distanceMargin * marginRatio;
    }
}
