using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerAudio : MonoBehaviour
{
    [SerializeField] private AudioListener audioListener;
    [SerializeField] private PhotonView pv;
    void Start()
    {
        if(!pv.IsMine)
        {
            audioListener.enabled = false;
        }
    }
}
