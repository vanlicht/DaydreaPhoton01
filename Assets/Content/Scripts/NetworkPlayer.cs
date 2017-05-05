using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkPlayer : Photon.MonoBehaviour, IPunObservable
{
    #region
    #endregion

    #region Public Properties
    public GameObject otherPlayerHead;
    public GameObject otherController;
    public GameObject playerController;
    public Camera playerCamera;
    #endregion

    #region Private Properties
    Vector3 correctPlayerPos;
    Quaternion correctPlayerRot = Quaternion.identity;
    #endregion

    #region MonoBehavriour Callbacks
    // Update is called once per frame
    void Update ()
    {
        //Other player's position and head rotation
        if (!photonView.isMine)
        {
            transform.position = Vector3.Lerp(transform.position, this.correctPlayerPos, Time.deltaTime * 5f);
            otherPlayerHead.transform.rotation = Quaternion.Lerp(otherPlayerHead.transform.rotation, this.correctPlayerRot, Time.deltaTime * 5f);
        }
	}
    #endregion

    #region PUN Callbacks
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (photonView.isMine)
        {
            stream.SendNext(transform.position);
            stream.SendNext(playerCamera.transform.rotation);
        }
        else
        {
            this.correctPlayerPos = (Vector3)stream.ReceiveNext();
            this.correctPlayerRot = (Quaternion)stream.ReceiveNext();
        }
    }
    #endregion
}
