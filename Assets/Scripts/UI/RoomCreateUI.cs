using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public struct RoomValues
{
    public int playerNum;
    public int passward;
    public bool privateRoom;
}

public class RoomCreateUI : MonoBehaviour
{
    [SerializeField] GameObject menuBasicBtns;
    [SerializeField] GameObject menuRoomBtns;
    [SerializeField] MainBtns mainBtns;

    private RoomValues roomValues;

    [SerializeField] private TextMeshProUGUI playerNumTxt;


    [SerializeField] private TMP_InputField passField;

    [SerializeField] private GameObject roomCreateChoiceWnd;   
    [SerializeField] private GameObject roomCreateWnd;   
    [SerializeField] private GameObject roomSearchWnd;   

    private void OnEnable()
    {
        StartSet();
    }

    private void StartSet()
    {
        menuBasicBtns.SetActive(false);
        menuRoomBtns.SetActive(true);
        roomValues.playerNum = 2;
        roomValues.privateRoom = false;
        roomCreateChoiceWnd.SetActive(true);
    }

    #region RoomCreateChoice
    public void GoToRoomCreateChoiceBack()
    {
        menuRoomBtns.SetActive(false);
        menuBasicBtns.SetActive(true);
    }

    #endregion

    #region RoomCreate

    public void NumberOfPeoplePluseSetBtn()
    {
        if (roomValues.playerNum >= 4) roomValues.playerNum = 2   ;
        else roomValues.playerNum++;

        playerNumTxt.text = roomValues.playerNum.ToString();
    }
    public void NumberOfPeopleMinusSetBtn()
    {
        if (roomValues.playerNum <= 2) roomValues.playerNum = 4;
        else roomValues.playerNum--;
        playerNumTxt.text = roomValues.playerNum.ToString();
    }
    public void PrivateRoomCheckBtn()
    {
        roomValues.privateRoom = !roomValues.privateRoom;
    }

    public void Passward(string pass)
    {
        if (pass.Length < 6 || pass.Length > 6) passField.text = null;

        roomValues.passward = int.Parse(pass);
    }

    public void RoomCreateBtn()
    {
        // roomValues 가져다 쓰셈


        menuBasicBtns.SetActive(true);
        menuRoomBtns.SetActive(false);
        mainBtns.GoBack();
    }
    public void RoomCreateBackBtn()
    {
        roomCreateWnd.SetActive(false);
    }
    #endregion

    #region RoomSearch



    #endregion

}
