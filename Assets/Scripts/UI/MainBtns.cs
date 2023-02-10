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
    private readonly Vector2 wndStartPos = new Vector2(-1920, 0);
    private readonly Vector2 wndEndPos = Vector2.zero;


    public void BtnSet(int num)
    {
        mainWndType = (EMainWndType)num;
        wnd.transform.position = wndStartPos;


        wnd.transform.DOMoveX(wndEndPos.x, 2f);

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
