using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : Photon.PunBehaviour
{
    #region
    #endregion
    #region Public Properties
    public PhotonLogLevel logLevel = PhotonLogLevel.Full;
    public byte maxPlayerPerRoom = 4;
    public GameObject controlPanel;
    public GameObject progressPanel;
    #endregion

    #region Private Properties
    string _gameVersion = "1";
    bool isConnecting;
    #endregion

    #region MonoBehaviour Callbacks
    private void Awake()
    {
        PhotonNetwork.autoJoinLobby = false;
        PhotonNetwork.automaticallySyncScene = true;
        PhotonNetwork.logLevel = logLevel;
    }

    private void Start()
    {
        controlPanel.SetActive(true);
        progressPanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Thomas: Player count: " + PhotonNetwork.room.PlayerCount);
        }
    }
    #endregion

    #region Public Methods
    public void Connect()
    {
        Debug.Log("Thomas: Connect Method triggered");
        isConnecting = true;
        controlPanel.SetActive(false);
        progressPanel.SetActive(true);
        Debug.Log("Thomas: PhotonNetwork.connected: " + PhotonNetwork.connected);
        if (PhotonNetwork.connected)
        {
            PhotonNetwork.JoinRandomRoom();
            Debug.Log("Thomas: JoinRandomRoom");
        }
        else
        {
            PhotonNetwork.ConnectUsingSettings(_gameVersion);
            Debug.Log("Thomas: Connect Using Settings");
        }
    }
    #endregion

    #region PUN Callbacks
    public override void OnConnectedToMaster()
    {
        if (isConnecting)
        {
            PhotonNetwork.JoinRandomRoom();
            Debug.Log("Thomas: OnConnectedToMaster, JoinRandomRoom");
        }
    }
    public override void OnPhotonRandomJoinFailed(object[] codeAndMsg)
    {
        Debug.Log("Thomas: OnPhotonRandomJoinFailed");
        PhotonNetwork.CreateRoom(null, new RoomOptions() { MaxPlayers = maxPlayerPerRoom, IsVisible = false }, null);
        
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Thomas: OnJoinedRoom");
        //Debug.Log("Thomas: PhotonNetwork.isMasterClient:" + PhotonNetwork.isMasterClient);
        //if (!PhotonNetwork.isMasterClient)
        //{
        //    return;
        //}
        //else
        //{
        //    PhotonNetwork.LoadLevel(1);
        //}
    }

    public override void OnDisconnectedFromPhoton()
    {
        Debug.LogWarning("Thomas: OnDisconnectedFromPhoton() was called by PUN");
        controlPanel.SetActive(true);
        progressPanel.SetActive(false);
    }
    #endregion
}
