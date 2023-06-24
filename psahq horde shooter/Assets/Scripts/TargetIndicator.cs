using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetIndicator : MonoBehaviour
{
    public GameObject noob, arrow;
    private float maxDistance = 2f;
    private Camera cam;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        while(PlayerReference.Instance.playerCam == null)
        {
            yield return null;
        }
        cam = PlayerReference.Instance.playerCam; 
    }

    // Update is called once per frame
    void Update()
    {
        this.the();
    }


    public void the()
    {
        Vector3 relative = this.noob.gameObject.transform.position - this.cam.transform.position;

        if (relative.magnitude < this.maxDistance)
            //Magnitude is just the distance.
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
                //Vector3 direction = this.noob.gameObject.transform.position - this.cam.transform.position;

                float angle = Mathf.Atan2(relative.y, relative.x) * Mathf.Rad2Deg - 90f;
                this.arrow.gameObject.transform.rotation = Quaternion.Euler(0, 0, angle);

                //This inner-else statement is when the Noob is off screen and so it shows the pointer.
            }
        }

    }
    
}
