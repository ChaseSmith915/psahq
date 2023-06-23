using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetIndicator : MonoBehaviour
{
    public Noob noob;
    public GameObject arrow;
    private float maxDistance = 2f;
    [SerializeField] private Camera cam;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.the();
    }


    public void the()
    {
        Vector3 relative = this.noob.gameObject.transform.position - transform.position;
        float distance = relative.magnitude;
        //Magnitude is just the distance.

        if (distance < this.maxDistance)
        {
            
            this.arrow.gameObject.SetActive(false);
            //When the noob is in the screen or at least nearby, it hides the pointer.
        } else
        {
            Vector3 noobPosition = this.cam.WorldToViewportPoint(this.noob.gameObject.transform.position);
            if (noobPosition.z > 0 && noobPosition.x > 0 && noobPosition.x < 1 && noobPosition.y > 0 && noobPosition.y < 1)
            {
                this.arrow.gameObject.SetActive(false);
            } else
            {
                this.arrow.gameObject.SetActive(true);
                Vector3 edge = this.cam.ViewportToWorldPoint(new Vector3(Mathf.Clamp(noobPosition.x, 0.1f, 0.9f), Mathf.Clamp(noobPosition.y, 0.1f, 0.9f), this.cam.nearClipPlane));

                this.arrow.transform.position = new Vector3(edge.x, edge.y, 0);
                Vector3 direction = this.noob.gameObject.transform.position - transform.position;

                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                this.arrow.gameObject.transform.rotation = Quaternion.Euler(0, 0, angle);

                //This inner-else statement is when the Noob is off screen and so it shows the pointer.
            }
        }

    }
    
}