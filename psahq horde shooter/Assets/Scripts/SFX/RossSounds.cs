using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RossSounds : MonoBehaviour
{
    [SerializeField] private List<AudioClip> shootSounds = new List<AudioClip>();
    [SerializeField] private AudioSource audio;

    void Start()
    {
        
    }

    public void playShootSound()
    {
        audio.clip = shootSounds[UnityEngine.Random.Range(0,shootSounds.Count)];
        audio.Play();
    }
}
