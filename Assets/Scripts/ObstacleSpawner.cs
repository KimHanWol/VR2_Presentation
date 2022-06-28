using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner: MonoBehaviour
{
    public Prototype prototype;
    public GameObject obstacles;

    public Prototype Spawn(Vector3 vector)
    {
        Prototype spawnedObject = Instantiate(prototype, vector, Quaternion.identity);
        spawnedObject.transform.parent = obstacles.transform;

        return spawnedObject;
    }

    public void RemoveObjects()
    {
        GameObject oldObjests = obstacles;
        GameObject gameObject = new GameObject
        {
            name = "obstacles"
        };
        gameObject.AddComponent<Obstacles>();
        obstacles = gameObject;
        Destroy(oldObjests);
    }
}
