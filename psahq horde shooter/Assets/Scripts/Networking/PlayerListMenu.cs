using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerListMenu : MonoBehaviourPunCallbacks
{
    [SerializeField] private Transform content;
    [SerializeField] private PlayerList playerLists;

    private List<PlayerList> lists = new List<PlayerList>();

    private void Awake()
    {
        this.GetCurrentRoomPlayers();
    }

    private void GetCurrentRoomPlayers()
    {
        foreach (KeyValuePair<int, Player> playerInfo in PhotonNetwork.CurrentRoom.Players)
        {
            this.AddPlayerListing(playerInfo.Value);
        }
        
    }

    private void AddPlayerListing(Player player)
    {
        PlayerList listing = Instantiate(this.playerLists, content);
        if (listing != null)
        {
            listing.setPlayerInfo(player);
            this.lists.Add(listing);
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        this.AddPlayerListing(newPlayer);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        int index = this.lists.FindIndex(x => x.Player == otherPlayer);
        if (index != -1)
        {
            Destroy(this.lists[index].gameObject);
            this.lists.RemoveAt(index);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
