using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class JoinRoomBtn : MonoBehaviour
{
    RoomValues roomValues;
    [SerializeField] private TextMeshProUGUI roomName;
    [SerializeField] private GameObject privateRoomImage;
    [SerializeField] private TextMeshProUGUI playerNumTxt;

    public void RoomSet(string name,int headcount, int playerNum, int pass, bool privateRoom)
    {
        roomValues.roomName = name;
        roomValues.privateRoom = privateRoom;
        roomValues.playerNum = playerNum;
        roomValues.passward = pass;

        roomName.text = name;
        privateRoomImage.SetActive(roomValues.privateRoom);
        playerNumTxt.text = $"{headcount}/{roomValues.playerNum}";
    }

    public bool PassInput(string pass)
    {
        if(roomValues.passward == int.Parse(pass)) return true;
        else return false;
    }
}
