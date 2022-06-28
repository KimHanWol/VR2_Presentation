using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextDebug : MonoBehaviour
{
    private static TextDebug instance;
    public static TextDebug GetInstance()
    {
        if (!instance)
        {
            instance = FindObjectOfType(typeof(TextDebug)) as TextDebug;

            if (instance == null) return null;
        }
        return instance;
    }

    private string text;

    public Text debugText;

    // Start is called before the first frame update
    void Start()
    {
        debugText.text = "";
    }

    public void OnEnable()
    {
        StartCoroutine(GetFPS());
    }

    // Update is called once per frame
    void Update()
    {
        text = "";
        Player player = Player.GetInstance();
        text += "Player : " + player.GetPosition() + "/" + player.GetRotation() + "\n";

        text += player.transform.rotation.x + "/" + player.transform.rotation.y + "/" + player.transform.rotation.z + "\n";

        text += "CameraRelative : " + player.GetCameraRelativePosition() + "/" + player.GetCameraRotation() + "\n";

        text += "Camera : " + player.GetCameraPosition() + "/" + player.GetCameraRotation() + "\n";

        text += "RightController : " + player.GetRightControllerPosition() + "/" + player.GetRightControllerRotation() + "\n";

        text += "LeftController : " + player.GetLeftControllerPosition() + "/" + player.GetLeftControllerRotation() + "\n";

        if(!testText.Equals("")) text += "testText : " + testText + "\n";

        int FPS = (int)(1f / Time.deltaTime);
        text += "FPS : " + FPS + "\n";
    }

    private string testText = "";

    public void SetText(string text)
    {
        testText = text;
    }

    IEnumerator GetFPS()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);
            debugText.text = text;
        }
    }
}
