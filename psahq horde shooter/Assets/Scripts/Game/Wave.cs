using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Wave : MonoBehaviour
{

    public List<WaveGroup> WaveGroups = new List<WaveGroup>();

    public Wave(List<WaveGroup> waveGroups)
    {
        WaveGroups = waveGroups;
    }

    public void sendWave()
    {
        foreach (WaveGroup waveGroup in WaveGroups)
        {
            waveGroup.StartCoroutine("sendGroup");
        }
    }

    public void generateRandomWaves()
    {
        foreach (WaveGroup waveGroup in WaveGroups)
        {
            waveGroup.generateRandomWave();
        }
    }
}
