using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class RoomListingMenu : MonoBehaviourPunCallbacks
{
    [SerializeField] private Transform content;
    [SerializeField] private GameObject roomListing;

    //private RoomsCanvases roomCanvas;
    private List<RoomListing> roomListings = new List<RoomListing>();

    /*
    public void FirstInitialize(RoomCanvases canvas)
    {
        this.roomCanvas = canvas;
    }

    public override void OnJoinedRoom()
    {
        this.roomCanvas.CurrentRoomCanvas.Show();
    }
    */

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach (RoomInfo roomInfo in roomList)
        {
            if (roomInfo.RemovedFromList)
            {
                int index = roomListings.FindIndex(x => x.RoomInfo.Name == roomInfo.Name);
                if (index != -1)
                {
                    Destroy(roomListings[index].gameObject);
                    roomListings.RemoveAt(index);
                }
            }
            RoomListing listing = Instantiate(roomListing, content).GetComponent<RoomListing>();
            if (listing != null)
            {
                listing.SetRoomInfo(roomInfo);
                roomListings.Add(listing);
            }
        }
    }


}