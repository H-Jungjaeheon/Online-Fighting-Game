using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public enum EMainWndType
{
    RoomCreate,
    OnlinePlay,
    Setting,
    Exit
}
public class MainBtns : MonoBehaviour
{
    private EMainWndType mainWndType;

    [SerializeField] private GameObject wnd;
    readonly float wndStartPosX = -1920;
    readonly float wndEndPosX = 0;

    public void BtnSet(int num)
    {
        mainWndType = (EMainWndType)num;
        wnd.transform.position = new Vector2(wndStartPosX, 0);


        wnd.transform.DOMoveX(wndEndPosX, 2f);

        WndSet();
    }

    private void WndSet()
    {
        switch (mainWndType)
        {
            case EMainWndType.RoomCreate:
                break;
            case EMainWndType.OnlinePlay:
                break;
            case EMainWndType.Setting:
                break;
            case EMainWndType.Exit:
                break;
        }

    }



}
