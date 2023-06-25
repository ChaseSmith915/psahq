using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NoobType4 : Noob
{
    [SerializeField] private float teleportCooldown, cur_teleTime;
    private bool curTeleport;

    public override void Start()
    {
        this.playRef = GameObject.FindWithTag("Reference").GetComponent<PlayerReference>();

        this.maxHP += ((PhotonNetwork.CurrentRoom.PlayerCount - 1) * 0.25f * this.maxHP);
        this.knockedOut = false;
        this.cur_hp = this.maxHP;
        this.hqXY = GameObject.Find("HQ").transform;
        this.healthbar.setHealth(this.cur_hp, this.maxHP);

        this.cur_teleTime = this.teleportCooldown;
        this.curTeleport = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!this.curTeleport) {
            this.pv.RPC("walk", RpcTarget.All);
        }
        this.cur_teleTime -= Time.deltaTime;
    }

    private void distance(float amount)
    {
        Vector3 relative = this.hqXY.position - transform.position;
        if (!this.knockedOut)
            this.rigB.MovePosition((Vector2)transform.position + ( ((Vector2)relative) * amount * Time.deltaTime));
        //This is honestly just the Noob's walk method but with this.speed replaced with amount.
    }

    [PunRPC]
    private void teleport()
    {
        this.distance(15f);
        StartCoroutine(this.time());
        //For 0.05 seconds, basically move really fast. It just gives the interpretation that
        //the Noob is teleporting.
    }

    private void FixedUpdate()
    {
        //FixedUpdate is called every 0.02 seconds, slightly slower than Update().

        if (this.cur_teleTime <= 0 && !this.knockedOut)
        {
            this.pv.RPC("teleport", RpcTarget.All);
            this.cur_teleTime = this.teleportCooldown;
            //The Noob can only teleport is enough time has passed AND the Noob is not
            //currently being knocked back.
        }
    }

    private IEnumerator time()
    {
        yield return new WaitForSeconds(0.05f);
        //Pauses for 0.05 seconds (3 frames).

        this.rigB.velocity = Vector3.zero;
    }
}
