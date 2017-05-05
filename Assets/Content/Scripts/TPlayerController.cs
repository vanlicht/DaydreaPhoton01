using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPlayerController : Photon.MonoBehaviour
{
    #region
    #endregion

    #region Public Properties
    public GameObject otherPlayerHead;
    public GameObject otherPlayerController;
    public GameObject gvrControllerPointer;
    public GameObject playerCamera;

    public bool isControllable;
    static public GameObject localPlayerInstance;
    #endregion

    private void Awake()
    {
        localPlayerInstance = this.gameObject;
    }

    void Update ()
    {
        if (photonView.isMine)
        {
            isControllable = true;
            playerCamera.SetActive(true);
            gvrControllerPointer.SetActive(true);
            otherPlayerHead.SetActive(false);
            otherPlayerController.SetActive(false);
        }
        else
        {
            isControllable = false;
            playerCamera.SetActive(false);
            gvrControllerPointer.SetActive(false);
            otherPlayerHead.SetActive(true);
            otherPlayerController.SetActive(true);
        }
	}
}
