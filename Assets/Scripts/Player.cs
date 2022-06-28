using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private static  Player instance;

    public static Player GetInstance()
    {
        if (!instance)
        {
            instance = FindObjectOfType(typeof(Player)) as Player;

            if (instance == null) return null;
        }
        return instance;
    }
    public Vector3 GetPosition()
    {
        return GetGameObjectPosition(this.gameObject);
    }

    public Vector3 GetRotation()
    {
        return GetGameObjectRotation(this.gameObject);
    }

    public GameObject forwardObject;

    public Vector3 GetForwardPosition()
    {
        return GetGameObjectPosition(forwardObject);
    }

    public Vector3 GetForwardRotation()
    {
        return GetGameObjectRotation(forwardObject);
    }

    public GameObject cameraObject;

    private void Start()
    {
        cameraObject.transform.position = new Vector3(0,0,0);
    }

    public Vector3 GetCameraRelativePosition()
    {
        Vector3 cameraRelativePosition = new Vector3(
            (GetPosition().x - GetCameraPosition().x),
            (GetPosition().y - GetCameraPosition().y),
            (GetPosition().z - GetCameraPosition().z));

        return cameraRelativePosition;
    }

    public Vector3 GetCameraPosition()
    {
        return GetGameObjectPosition(cameraObject);
    }

    public Vector3 GetCameraRotation()
    {
        return GetGameObjectRotation(cameraObject);
    }

    
    public GameObject leftControllerObject;

    public Vector3 GetLeftControllerPosition()
    {
        return GetGameObjectPosition(leftControllerObject);
    }

    public Vector3 GetLeftControllerRotation()
    {
        return GetGameObjectRotation(leftControllerObject);
    }

    public GameObject rightControllerObject;

    public Vector3 GetRightControllerPosition()
    {
        return GetGameObjectPosition(rightControllerObject);
    }

    public Vector3 GetRightControllerRotation()
    {
        return GetGameObjectRotation(rightControllerObject);
    }

    public Transform GetRightControllerTransform()
    {
        return rightControllerObject.transform;
    }

    private Vector3 GetGameObjectPosition(GameObject gameObject)
    {
        return gameObject.transform.position;
    }

    private Vector3 GetGameObjectRotation(GameObject gameObject)
    {
        return new Vector3(gameObject.transform.rotation.x, gameObject.transform.rotation.y, gameObject.transform.rotation.z);
    }


    public enum PlayerState
    {
        Idle = 0,
        Moving,
    }

    [SerializeField]
    private PlayerState playerState;
}
