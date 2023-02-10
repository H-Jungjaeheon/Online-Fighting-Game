using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public enum EMainWndType
{
    OnlinePlay,
    OfflinePlay,
    Setting,
    PlayGuid,
    Creators,
    Exit
}
public class MainBtns : MonoBehaviour
{
    private EMainWndType mainWndType;

    [SerializeField] private GameObject fadeWnd;
    [SerializeField] private GameObject[] wnd;
    private readonly Vector2 wndStartPos = new Vector2(-1920, 0);
    private readonly Vector2 wndEndPos = Vector2.zero;


    public void BtnSet(int num)
    {
        fadeWnd.SetActive(true);

        mainWndType = (EMainWndType)num;
        wnd[((int)mainWndType)].transform.position = wndStartPos;

        fadeWnd.GetComponent<Image>().DOFade(0.3f, 0.5f).OnComplete(() =>
        {
            wnd[((int)mainWndType)].transform.DOMoveX(wndEndPos.x, 0.5f);
        });
    }

    public void GoBack()
    {
        wnd[((int)mainWndType)].transform.DOMoveX(wndStartPos.x, 0.5f).OnComplete(() =>
        {
            fadeWnd.GetComponent<Image>().DOFade(0f, 0.5f).OnComplete(() => fadeWnd.SetActive(false));
        });
    }

}
