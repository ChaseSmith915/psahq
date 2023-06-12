using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class NicknameSetter : MonoBehaviour
{
    [SerializeField] private TMP_InputField nicknameField;
    void Start()
    {
        nicknameField.onEndEdit.AddListener(setNickname);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void setNickname(string nickname)
    {
        PhotonNetwork.NickName = nickname;
    }
}
