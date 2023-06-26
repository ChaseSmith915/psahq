using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerList : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    public Player Player { get; private set; }

    public void setPlayerInfo(Player player)
    {
        this.Player = player;
        this.text.text = player.NickName;
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
