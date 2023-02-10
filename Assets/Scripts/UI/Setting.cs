using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Setting : MonoBehaviour
{
    [SerializeField] private SoundManager SM;
    [SerializeField] private TextMeshProUGUI volumValue;

    const int setWidth = 1920;
    const int setHeight = 1080;
    private bool isFullScreen = true;// true : 전체화면 , false : 창 화면
    [SerializeField] private TextMeshProUGUI screenType;

    public void WndChangeBtn()
    {
        isFullScreen = (isFullScreen == true) ? false : true;

        screenType.text = (isFullScreen == true) ? "FullScreen" : "WndScreen" ;

        Screen.SetResolution(setWidth, setHeight, isFullScreen);
    }

    public void VolumSET(float value)
    {
        SM.MasterVolum = value;
        volumValue.text = value.ToString();
    }

}
