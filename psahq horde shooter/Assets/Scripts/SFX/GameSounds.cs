using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameSounds : MonoBehaviour
{
    [SerializeField] private AudioClip sendWaveAudio;
    [SerializeField] private AudioSource audio;
    [SerializeField] private AudioClip gameWinAudio;
    [SerializeField] private PhotonView pv;
    void Start()
    {
        NoobSpawner.Instance.OnWaveSent += sendWaveSound;
    }

    private void sendWaveSound()
    {
        pv.RPC("sendWaveSoundRPC", RpcTarget.All);
    }

    [PunRPC]
    private void sendWaveSoundRPC()
    {
        audio.clip = sendWaveAudio;
        audio.Play();
    }
}
