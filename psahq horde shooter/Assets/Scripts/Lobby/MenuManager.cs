using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject connectingScreen;
    [SerializeField] private GameObject lobby;
    [SerializeField] private GameObject characterSelectMenu;

    protected void Start()
    {
        connectingScreen.SetActive(true);
        lobby.SetActive(false);
        characterSelectMenu.SetActive(false);
        PhotonManager.Instance.OnConnectedToGame += OnConnectedToMaster;
    }

    private void OnConnectedToMaster()
    {
        connectingScreen.SetActive(false);
        lobby.SetActive(true);
    }

    public void toCharacterSelect()
    {
        lobby.SetActive(false);
        characterSelectMenu.SetActive(true);
    }

    public void backToLobby()
    {
        lobby.SetActive(true);
        characterSelectMenu.SetActive(false);
    }

}
