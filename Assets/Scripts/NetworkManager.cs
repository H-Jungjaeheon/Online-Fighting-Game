using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    [Tooltip("현재 게임 버전")]
    string gameVersion = "1";

    [SerializeField]
    [Tooltip("생성한 방 제목")]
    string roomName;


    private void Awake()
    {
        JoinMainServer();
    }

    /// <summary>
    /// 메인 서버 접속 함수
    /// </summary>
    void JoinMainServer()
    {
        print("서버 접속");

        PhotonNetwork.AutomaticallySyncScene = true; //LoadLevel함수 호출 가능 및 연결된 플레이어들 씬 동기화
        
        PhotonNetwork.GameVersion = gameVersion; //현재 게임 버전 설정

        PhotonNetwork.ConnectUsingSettings(); //포톤 네트워크 연결
    }

    /// <summary>
    /// 메인 서버 접속 실패 시 재접속 시도 함수
    /// </summary>
    /// <param name="cause"></param>
    public override void OnDisconnected(DisconnectCause cause) => PhotonNetwork.ConnectUsingSettings();

    /// <summary>
    /// 메인 서버 접속 이후 호출
    /// </summary>
    public override void OnConnectedToMaster()
    {
        print("서버 접속 완료");
        PhotonNetwork.JoinLobby();
        //PhotonNetwork.LoadLevel();
        //RoomOptions options = new RoomOptions();
        //options.MaxPlayers = 2;
        //PhotonNetwork.CreateRoom(roomName, options);
    }

    /// <summary>
    /// 로비 접속 성공 시 호출 함수
    /// </summary>
    public override void OnJoinedLobby() => print("로비 접속 성공");

    /// <summary>
    /// 방 생성 함수
    /// </summary>
    public void CreateRoom()
    {
        print("방 생성");

        RoomOptions RoomOption = new RoomOptions();

        RoomOption.IsOpen = true;

        RoomOption.IsVisible = true;

        RoomOption.MaxPlayers = 4;

        PhotonNetwork.CreateRoom(roomName, RoomOption);
    }

    /// <summary>
    /// 선택한 방 접속 실패 함수
    /// </summary>
    /// <param name="returnCode"></param>
    /// <param name="message"></param>
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        print("방 접속 실패");
    }

    /// <summary>
    /// 방 접속 함수
    /// </summary>
    public void JoinRoom()
    {
        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.JoinRoom(roomName); //현재 인자로 넣은 이름의 방 서버에 참여
        }
        else
        {
            print("네트워크 연결 실패");
        }
    }

    /// <summary>
    /// 선택한 방 접속 함수
    /// </summary>
    public override void OnJoinedRoom()
    {
        print("방 접속");
        print(PhotonNetwork.CountOfRooms); //방 이름 설정하는 Input Field에서 방 이름 받아오기
        //PhotonNetwork.LoadLevel("BattleScene");
    }

    /// <summary>
    /// 방 생성 실패 함수
    /// </summary>
    /// <param name="returnCode"></param>
    /// <param name="message"></param>
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        print("방 생성 실패");
    }

    /// <summary>
    /// 연결 끊기
    /// </summary>
    public void Disconnect() => PhotonNetwork.Disconnect();
}
