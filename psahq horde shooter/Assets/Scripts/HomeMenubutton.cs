using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomeMenubutton : MonoBehaviour
{
    [SerializeField] private Button btn;
    void Start()
    {
        btn.onClick.AddListener(goIntoLobby);
    }

    private void goIntoLobby()
    {
        SceneManager.LoadScene("Lobby");
    }
}
