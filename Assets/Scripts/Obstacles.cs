using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TrackingPlayer());
    }

    IEnumerator TrackingPlayer()
    {
        while (true)
        {
            transform.position = new Vector3(
                Player.GetInstance().GetPosition().x,
                Player.GetInstance().GetPosition().y + 0.3f,
                Player.GetInstance().GetPosition().z);

            //transform.rotation = Player.GetInstance().forwardObject.transform.rotation;

            //Player.GetInstance()

            yield return new WaitForFixedUpdate();
        }
    }
}
