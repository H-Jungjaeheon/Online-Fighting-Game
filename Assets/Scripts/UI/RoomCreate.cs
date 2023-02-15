using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RoomCreate : MonoBehaviour
{
    private int playerNum;
    private bool privateRoom;
    private int passward;


    private void OnEnable()
    {
        StartSet();
    }

    private void StartSet()
    {
        playerNum = 2;
        privateRoom = false;
    }
}
