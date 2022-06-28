using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class FileIO
{
    //readonly string filePath = "C:/workspace/workspace-spider/VR2/point.txt";

    public float[,] ReadFile()
    {
        /*DirectoryInfo fileDirectoryInfo = new DirectoryInfo(Path.GetDirectoryName(filePath));

        Resources.Load<Texture>


        //need to prevent null return
        if (!fileDirectoryInfo.Exists)
        {
            Debug.LogError("file path is incorrect");
            return null;
        }

        StreamReader streamReader = new StreamReader(filePath);
        string contents = streamReader.ReadToEnd();
        streamReader.Close();*/

        TextAsset contentTextAsset = Resources.Load("point") as TextAsset;
        string contents = "" + contentTextAsset;


        string[] lineArray = contents.Split('\n');

        int index = lineArray[0].Split(',').Length;

        float[,] dataArray = new float[lineArray.Length, index];
        for (int i = 0; i < lineArray.Length; i++)
        {
            string[] commaArray = lineArray[i].Split(',');
            for (int j = 0; j < index; j++)
            {
                try
                {
                    dataArray[i,j] = float.Parse(commaArray[j]);
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                }
            }
        }
        return dataArray;
    }

    public float[,] TestFileOut()
    {
        float[,] data = new float[10, 100];
       
        for (int i = 0; i < data.GetLength(0); i++)
        {
            for(int j = 0; j < data.GetLength(1); j++)
            {
                data[i, j] = UnityEngine.Random.Range(0.7f, 1);
            }
        }

        return data;
    }
}
