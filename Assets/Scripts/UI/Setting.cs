using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : MonoBehaviour
{
    [SerializeField] private SoundManager SM;

    private bool isFullScreen = true;// true : 전체화면 , false : 창 화면
    [SerializeField] private GameObject fullScreenCheckBox;
    [SerializeField] private GameObject windowScreenCheckBox;
    const int setWidth = 1920;
    const int setHeight = 1080;
    public void WndChangeBtn(bool type)
    {
        isFullScreen = type;

        fullScreenCheckBox.SetActive(isFullScreen);
        windowScreenCheckBox.SetActive(!isFullScreen);

        Screen.SetResolution(setWidth, setHeight, isFullScreen);
    }

    public void BgmSET(float value)
    {
        SM.BGMVolum = value;
    }

    public void SfxSET(float value)
    {
        SM.SFXVolum = value;
    }

}
