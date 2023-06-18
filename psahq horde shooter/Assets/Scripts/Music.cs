using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    [SerializeField] private List<AudioClip> musicIntroList = new List<AudioClip>();
    [SerializeField] private List<AudioClip> musicList = new List<AudioClip>();
    [SerializeField] private AudioSource musicSource;
    public Music Instance;

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        if (Instance == null)
        {
            Instance = this;
            Debug.Log("parody");
        }
        else
        {
            Destroy(this.gameObject);
        }

        playMusic(0);
    }
    public void playMusic(int a)
    {
        musicSource.clip = musicList[a];
        musicSource.Play();
    }

    public IEnumerator playIntroThenMusic(int introIndex, int musicIndex)
    {
        musicSource.clip = musicIntroList[introIndex];
        musicSource.Play();
        yield return new WaitForSeconds(musicIntroList[musicIndex].length);
        musicSource.clip = musicList[musicIndex];
        musicSource.Play();
    }
}
