using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    private void Awake()
    {
        JoinMainServer();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void JoinMainServer()
    {
        print("서버 접속");

        PhotonNetwork.AutomaticallySyncScene = true; //자동 씬 동기화

        PhotonNetwork.ConnectUsingSettings(); //포톤 네트워크 연결
    }

    /// <summary>
    /// 연결 끊기
    /// </summary>
    public void Disconnect() => PhotonNetwork.Disconnect();

    /// <summary>
    /// 서버 접속 이후 호출
    /// </summary>
    public override void OnConnectedToMaster()
    {
        print("서버 접속 완료");
        PhotonNetwork.JoinLobby();
        //RoomOptions options = new RoomOptions();
        //options.MaxPlayers = 2;
        //PhotonNetwork.JoinOrCreateRoom("Room1", options, null);
    }

    /// <summary>
    /// 로비 접속 이후 호출
    /// </summary>
    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
    }
}
