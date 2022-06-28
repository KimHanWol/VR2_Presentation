using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ControllerInput : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Input();
        //Ray();
    }

    private void Input() 
    {
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            //A-right
        }
        if (OVRInput.GetDown(OVRInput.Button.Two))
        {
            //B-right
        }
        if (OVRInput.GetDown(OVRInput.Button.Three))
        {
            //X-left
            bool active = UIManager.GetInstance().SettingUIOnOff();
            ObstacleManager.GetInstance().ActivePositionDetectSystemOnOff(!active);
            //obstacleManager.ActivePositionDetectSystemOnOff(!active);
        }
        if (OVRInput.GetDown(OVRInput.Button.Four))
        {
            //Y-left
            UIManager.GetInstance().DebugUIOnOff();
        }
        if (OVRInput.Get(OVRInput.Touch.PrimaryThumbstick))
        {
            //stick-left
        }
        if (OVRInput.Get(OVRInput.Touch.SecondaryThumbstick))
        {
            //stick-right
        }
        if (OVRInput.Get(OVRInput.Touch.PrimaryIndexTrigger))
        {
            //trigger-left
        }
        if (OVRInput.Get(OVRInput.Touch.SecondaryIndexTrigger))
        {
            //trigger-right
        }
        if (OVRInput.Get(OVRInput.Button.Start))
        {
            //start-left
        }
    }
}
