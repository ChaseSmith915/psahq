using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

[RequireComponent(typeof(PhotonView))]
public abstract class Noob : MonoBehaviourPunCallbacks, IPunObservable
{
    public float cur_hp, maxHP = 10f, speed = 3f, knockbackTime, knockbackPower;
    [SerializeField] private PhotonView pv;
    public Transform hqXY;
    //hqXY will have a reference to the HQ so that the Noobs know where the HQ is and walk towards it.

    public Vector2 move; 
    public Rigidbody2D rigB;
    public HealthBar healthbar;
    public bool knockedOut;
    public GFXSprite rotater;
    public PlayerReference playRef;

    public void setDirection()
    {
        Vector3 relative = this.hqXY.position - transform.position;
        float angle = Mathf.Atan2(relative.y, relative.x) * Mathf.Rad2Deg;
        //To find the direction to move to the castle, angle is set to the value by using the Math
        //formula of arctan(  (y2 - y1)/(x2 - x1)  )

        this.rigB.rotation = angle;
        relative.Normalize();
        //Normalize adjusts the Vector3 so that when the Noobs move diagonally, it should still move
        //at the same pace as just moving in one direction.

        this.move = relative;
    }

    public void walk(Vector2 angle)
    {
        if (!this.knockedOut && pv.IsMine) //Noobs move twice as fast if we don't only run this on the master client.
            this.rigB.MovePosition((Vector2)transform.position + (angle * this.speed * Time.deltaTime));
    }

    public void walk()
    {
        Vector3 relative = this.hqXY.position - transform.position;
        float angle = Mathf.Atan2(relative.y, relative.x) * Mathf.Rad2Deg;

        relative.Normalize();

        this.rotater.setAngle(angle);

        if (!this.knockedOut && pv.IsMine)
            this.rigB.MovePosition((Vector2)transform.position + ( ((Vector2)relative) * this.speed * Time.deltaTime));
    }

    public void changeHP(float amount)
    {
        this.cur_hp += amount;
        this.healthbar.setHealth(this.cur_hp, this.maxHP);
        //If the amount is a negative number, then the Noob is taking damage.

        if (this.cur_hp <= 0)
            Destroy(this.gameObject);
    }

    public void changeHP(float amount, int id)
    {
        this.cur_hp += amount;
        this.healthbar.setHealth(this.cur_hp, this.maxHP);
        //If the amount is a negative number, then the Noob is taking damage.

        if (this.cur_hp <= 0)
        {
            PlayerMovement obj = this.playRef.getPlayer(id).GetComponent<PlayerMovement>();
            if (obj)
            {
                Debug.Log("Player ID is: " + id);
                obj.setNoobCount(obj.getNoobCount() + 1);
                obj.setText("Noobs: " + obj.getNoobCount());
            }
            Destroy(this.gameObject);
        }
    }

    public virtual void Start()
    {
        //The virtual keyword means that Classes that inherit this Class,
        //can override methods with 'virtual' in it.

        this.playRef = GameObject.FindWithTag("Reference").GetComponent<PlayerReference>();

        this.knockedOut = false;
        this.maxHP += ((PhotonNetwork.CurrentRoom.PlayerCount - 1) * 0.25f * this.maxHP);
        this.cur_hp = this.maxHP;
        this.hqXY = GameObject.Find("HQ").transform;

        //The GetComponentInChildren method gets any component that the child GameObjects that
        //the parent GameObject has.
        //E.g. If you attached the Main Camera into the player and the Main Camera had a script,
        //you can use the GetComponentInChildren method to get that Component the Main Camera had.

        this.healthbar.setHealth(this.cur_hp, this.maxHP);
        //The setHealth method belongs to the Health Bar class. It just displays the current
        //health by dividing the cur_hp and maxHP.
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Projectile") && PhotonNetwork.IsMasterClient)
        {
            Projectiles exist = collision.GetComponent<Projectiles>();
            //exist is used to see if the gameObject that the Noob was hit with has the Projectiles script/component.
            //You can make the if-statement check if exist is not null but the tag "Projectile" should be enough since
            //GetComponent<>() method apparently takes a lot of power.

            exist.setPierce(exist.getPierce() - 1);

            pv.RPC("HurtEnemyRPC", RpcTarget.All, exist.getDamage(), exist.getID());
            //The 3rd parameter of pv.RPC is just the arguments to put into the HurtEnemyRPC() method.

            Vector2 knockAngle = (transform.position - collision.gameObject.transform.position).normalized;
            this.rigB.AddForce(knockAngle * this.knockbackPower, ForceMode2D.Impulse);

            StartCoroutine(this.knockBack());
            //StartCoroutine basically stops everything for knockBackTime seconds and in those seconds,
            //it will push the Noob backwards.
        }
    }

    public IEnumerator knockBack()
    {
        yield return new WaitForSeconds(this.knockbackTime);
        //Pause for knockbackTime seconds.

        this.rigB.velocity = Vector3.zero;
        this.knockedOut = false;
    }

    #region IPunObservable implementation
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(this.cur_hp);
        }
        else
        {
            cur_hp = (float)stream.ReceiveNext();
            if(healthbar == null)
            {
                return;
            }
            this.healthbar.setHealth(this.cur_hp, this.maxHP);
        }
    }

    #endregion

    [PunRPC]
    public void HurtEnemyRPC(float damage, int objID)
    {
        this.changeHP(-1 * damage, objID);
        //It's -1 * damage because the changeHP uses the += operator.

        //The Noob is knocked back, the angle they are knocked back depends on what direction
        //the projectile hit the Noob.
        this.knockedOut = true;
    }

}
