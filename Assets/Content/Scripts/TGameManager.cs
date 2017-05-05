using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TGameManager : Photon.PunBehaviour
{
    public GameObject playerPrefab;

	// Use this for initialization
	void Start ()
    {
	    if(playerPrefab != null)
        {
            PhotonNetwork.Instantiate(playerPrefab.name, new Vector3(0f, 2f, 0f), Quaternion.identity, 0);
           
            //if (TPlayerController.localPlayerInstance != null)
            //{
            //    Debug.Log("Thomas: localPlayerInstance True");
            //    playerPrefab.GetComponent<TPlayerController>().isControllable = true;
            //}
            //else
            //{
            //    Debug.Log("Thomas: localPlayerInstance False");
            //}
        }	
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Thomas: Player count: " + PhotonNetwork.room.PlayerCount);
        }
	}

    #region Public Methods
    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    public void LoadWorld()
    {
        if (PhotonNetwork.isMasterClient)
        {
            PhotonNetwork.LoadLevel("space02");
        }
    }
    #endregion

    #region PUN Callbacks
    public override void OnPhotonPlayerConnected(PhotonPlayer newPlayer)
    {
        if (PhotonNetwork.isMasterClient)
        {
            LoadWorld();
        }
    }

    public override void OnPhotonPlayerDisconnected(PhotonPlayer otherPlayer)
    {
        if (PhotonNetwork.isMasterClient)
        {
            LoadWorld();
        }
    }

    public override void OnLeftRoom()
    {
        Debug.Log("Thomas: OnLeftRoom");
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
    #endregion
}
