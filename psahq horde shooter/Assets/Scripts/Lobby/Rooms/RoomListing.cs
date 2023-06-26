using Photon.Realtime;
using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RoomListing : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    public RoomInfo RoomInfo { get; private set; }

    [SerializeField] private Button button;

    protected void Start()
    {
        button.onClick.AddListener(onButtonClicked);
    }

    public void SetRoomInfo(RoomInfo roomInfo)
    {
        RoomInfo = roomInfo;
        text.text = roomInfo.MaxPlayers + ", " + roomInfo.Name + ", " + roomInfo.PlayerCount;
    }

    /*
    public void OnClick_Button()
    {
        PhotonNetwork.JoinRoom(this.RoomInfo.Name);
    }
    */

    private void onButtonClicked()
    {
        PhotonManager.Instance.JoinRoom(RoomInfo);
    }
}
