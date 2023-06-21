using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Wave : MonoBehaviour
{
    public List<WaveGroup> WaveGroups = new List<WaveGroup>();
    public float WaveDuration;
    public void sendWave()
    {
        foreach (WaveGroup waveGroup in WaveGroups)
        {
            waveGroup.StartCoroutine("sendGroup");
        }
    }
}
