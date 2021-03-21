using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarWorldSpaceController : MonoBehaviour
{
    public Transform playerCam;

    void Start()
    {
        playerCam = GameObject.Find("PlayerCam").transform;
    }
    void LateUpdate()
    {
        transform.LookAt(transform.position + playerCam.forward);
    }
}