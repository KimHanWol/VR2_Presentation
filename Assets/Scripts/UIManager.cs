using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager GetInstance()
    {
        if (!instance)
        {
            instance = FindObjectOfType(typeof(UIManager)) as UIManager;

            if (instance == null) return null;
        }
        return instance;
    }

    private void UIHeadTracking()
    {
        Player player = Player.GetInstance();

        float x = player.transform.position.x + (Mathf.Sin(player.transform.rotation.eulerAngles.y * Mathf.Deg2Rad) * 2);
        float z = player.transform.position.z + (Mathf.Cos(player.transform.rotation.eulerAngles.y * Mathf.Deg2Rad) * 2);

        gameObject.transform.position = new Vector3(x, player.GetCameraPosition().y, z);

        //플레이어를 바라보도록
        gameObject.transform.rotation = player.transform.rotation;
    }

    List<GameObject> UIList = new List<GameObject>();

    private void Start()
    {
        UIList.Add(settingUI);
        UIList.Add(debugUI);
    }

    private void UIClear()
    {
        foreach(GameObject ui in UIList)
        {
            ui.SetActive(false);
        }
    }

    [SerializeField]
    private GameObject settingUI;

    public bool SettingUIOnOff()
    {
        if (!settingUI.activeSelf)
        {
            UIClear();
            UIHeadTracking();
        }
        settingUI.SetActive(!settingUI.activeSelf);

        return settingUI.activeSelf;
    }

    [SerializeField]
    private GameObject debugUI;

    public void DebugUIOnOff()
    {
        if (!debugUI.activeSelf)
        {
            UIClear();
            UIHeadTracking();
        }
        debugUI.SetActive(!debugUI.activeSelf);
    }

    [SerializeField]
    private GameObject pointer;

    public void SetPointerPosition(Vector3 position)
    {
        pointer.transform.position = position;
    }

    public void PoinerOn()
    {
        pointer.SetActive(true);
    }

    public void PoinerOff()
    {
        pointer.SetActive(false);
    }
}
