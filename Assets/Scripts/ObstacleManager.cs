using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    private static ObstacleManager instance;

    public static ObstacleManager GetInstance()
    {
        if (!instance)
        {
            instance = FindObjectOfType(typeof(ObstacleManager)) as ObstacleManager;

            if (instance == null) return null;
        }
        return instance;
    }

    readonly FileIO fileIO = new FileIO();

    public ObstacleSpawner obstacleSpawner;

    private readonly List<Prototype> spawnedObjectList = new List<Prototype>();

    private float[,] data;
    private CalculatePoint calculatePoint = new CalculatePoint();

    // Start is called before the first frame update
    void Start()
    {
        data = fileIO.ReadFile();
        SpawnObject();

        ActiveObjects(true);
        ActivePositionDetectSystemOnOff(true);
    }

    public void SpawnObject()
    {
        StopAllCoroutines();
        StartCoroutine(SpawnObjectLoop(1, 1));
    }

    public void SpawnObject(float ratio, float margin)
    {
        if(data == null) data = fileIO.ReadFile();
        StopAllCoroutines();
        StartCoroutine(SpawnObjectLoop(ratio, margin));
    }

    private IEnumerator SpawnObjectLoop(float ratio, float margin)
    {
        spawnedObjectList.Clear();
        obstacleSpawner.RemoveObjects();
        calculatePoint.SetWeightRatio(ratio);
        calculatePoint.SetDistanceMargin(margin);

        for(int i = 0; i < data.GetLength(0); i++)
        {
            for(int j = 0; j < data.GetLength(1); j++)
            {
                Vector3 vector3 = calculatePoint.GetPoint(data, i, j);
                if (vector3 != Vector3.zero)
                {
                    Prototype gameObject = obstacleSpawner.Spawn(calculatePoint.GetPoint(data, i, j));
                    gameObject.GetComponent<SpriteRenderer>().enabled = objectActive;
                    spawnedObjectList.Add(gameObject);
                }
            }
            if(i % 10 == 0) yield return new WaitForSeconds(0.000001f);
        }
    }

    public List<Prototype> GetSpawnedObjects()
    {
        return spawnedObjectList;
    }

    [SerializeField]
    private bool objectActive = true;

    public bool IsObjectsActive()
    {
        return objectActive;
    }

    public void ActiveObjects(bool active)
    {
        for (int i = 0; i < spawnedObjectList.Count; i++)
        {
            spawnedObjectList[i].GetComponent<SpriteRenderer>().enabled = active;
        }
        objectActive = active;
    }

    //PositionUpdate에서 거리에 따른 enable에서 문제가 있음. 

    private bool positionDetectSystemOn = false;

    public void ActivePositionDetectSystemOnOff()
    {
        if (positionDetectSystemOn) {
            positionDetectSystemOn = true;
            StartCoroutine(PositionUpdateLoop());
        }
        else
        {
            positionDetectSystemOn = false;
        }
    }

    public void ActivePositionDetectSystemOnOff(bool active)
    {
        positionDetectSystemOn = active;
        if (positionDetectSystemOn) StartCoroutine(PositionUpdateLoop());
        else ActiveObjects(true);
    }

    private IEnumerator PositionUpdateLoop()
    {
        while (positionDetectSystemOn)
        {
            yield return new WaitForSeconds(0.1f);
            for (int i = 0; i < spawnedObjectList.Count; i++)
            {
                spawnedObjectList[i].PositionUpdate();
                if (!positionDetectSystemOn) break;
            }
        }
    }
}
