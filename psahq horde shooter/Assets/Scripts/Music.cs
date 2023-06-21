using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        }
        else
        {
            Destroy(this.gameObject);
        }

        playMusic(2);
    }

    private void OnGUI()
    {
        if (SceneManager.GetActiveScene().name == "game")
        {
            GameObject.Find("Noobspawner").GetComponent<NoobSpawner>().OnGameStart += playGameMusic;
        }

    }
    public void playMusic(int a)
    {
        musicSource.Stop();
        musicSource.clip = musicList[a];
        musicSource.Play();
    }

    public IEnumerator playIntroThenMusic(int introIndex, int musicIndex)
    {
        musicSource.Stop();
        musicSource.clip = musicIntroList[introIndex];
        musicSource.Play();
        yield return new WaitForSeconds(musicIntroList[musicIndex].length);
        musicSource.clip = musicList[musicIndex];
        musicSource.Play();
    }

    private void playGameMusic()
    {
        playMusic(1);
    }

}
