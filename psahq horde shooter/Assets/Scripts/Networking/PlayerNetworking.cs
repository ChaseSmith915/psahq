using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using System;
using TMPro;
using UnityEngine;

public class PlayerNetworking : MonoBehaviour
{
    public MonoBehaviour[] scriptsToIgnore;
    public Camera rossCamera;
    [SerializeField] private SpriteRenderer rend;
    [SerializeField] private TextMeshProUGUI playerNickName;
    [SerializeField] private GameObject mousePointerPrefab;

    private PhotonView photonView;
    void Start()
    {

        photonView = GetComponent<PhotonView>();
        playerNickName.text = photonView.Owner.NickName;

        if (!photonView.IsMine)
        {
            foreach (var script in scriptsToIgnore)
            {
                script.enabled = false;
            }
            rossCamera.enabled = false;
        }
        else
        {
            GameObject mouserPointer = Instantiate(mousePointerPrefab);
            mouserPointer.GetComponent<MousePointer>().Cam = rossCamera;
        }

    }
    [PunRPC]
    private void destroyProjectile(GameObject projectile)
    {
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.Destroy(projectile);
        }
    }
}
