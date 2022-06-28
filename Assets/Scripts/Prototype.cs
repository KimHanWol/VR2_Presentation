using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prototype : MonoBehaviour
{
    static readonly float limitDistance = 3.5f;

    public void PositionUpdate()
    {
        float distance = GetDistance(Player.GetInstance().GetCameraPosition(), this.transform.position);

        //hide or expose object
        this.gameObject.GetComponent<SpriteRenderer>().enabled = (distance <= limitDistance);
        transform.LookAt(Player.GetInstance().GetCameraPosition());
    }

    private float GetDistance(Vector3 position1, Vector3 position2)
    {
        //pythagorean theorem
        float distance = Vector3.Distance(position1, position2);
        return distance;
    }
}
