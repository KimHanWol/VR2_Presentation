using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Setting : MonoBehaviour
{
    private bool obstacleOn = false;
    private float margin;
    private float ratio;
    private float center;

    public Button ObstacleButton;
    public Slider MarginSlider;
    public Slider RatioSlider;
    public Slider CenterSlider;

    public ObstacleManager obstacleManager;

    void Start()
    {
        ObstacleButtonClick();
        MarginSliderChanged();
        RatioSliderChanged();
        CenterSliderChanged();
    }

    public void ObstacleButtonClick()
    {
        obstacleOn = !obstacleOn;
        string onOff;
        if (obstacleOn) onOff = "On";
        else onOff = "Off";
        ObstacleButton.transform.GetChild(0).GetComponent<Text>().text = onOff;
        obstacleManager.ActiveObjects(obstacleOn);
    }

    //처음 실행 시 실행되는거 막아야함.
    //center 변경 후 margin, ratio 변경 시 center 초기화되는거 수정

    public void MarginSliderChanged()
    {
        margin = MarginSlider.value;
        obstacleManager.SpawnObject(margin, ratio);
        CenterSliderChanged();
    }

    public void RatioSliderChanged()
    {
        ratio = RatioSlider.value;
        obstacleManager.SpawnObject(margin, ratio);
        CenterSliderChanged();
    }

    public void CenterSliderChanged()
    {
        center = CenterSlider.value;
        obstacleManager.obstacleSpawner.obstacles.transform.rotation = Quaternion.Euler(0, center, 0);
    }
}
