using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerNameInputField : MonoBehaviour
{
    #region
    #endregion

    #region Private Properties
    static string playerNamePrefKey = "PlayerName";
    #endregion

    // Use this for initialization
    void Start ()
    {
        string defaultName = " ";
        InputField inputField = this.GetComponent<InputField>();
        if(inputField != null)
        {
            if (PlayerPrefs.HasKey(playerNamePrefKey))
            {
                defaultName = PlayerPrefs.GetString(playerNamePrefKey);
                inputField.text = defaultName;
            }
        }

        PhotonNetwork.playerName = defaultName;

    }

    #region Public Method
    public void SetPlayerName(string value)
    {
        PhotonNetwork.playerName = value + " ";
        PlayerPrefs.SetString(playerNamePrefKey, value);

    }
    #endregion
}
