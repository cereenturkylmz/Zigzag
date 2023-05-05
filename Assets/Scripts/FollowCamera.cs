using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject target;
    Vector3 distance;

    private void Start()
    {
        //kamera ile player arasıdnaki mesafe
        distance = transform.position - target.transform.position;     
    }

    private void LateUpdate()
    {
        if(PlayerController.isDead)
        {
            return;
        }

        //kameranın pozisyonunu target pozisyona götür ama distance kadar yani aradaki mesafe kader 
        transform.position = target.transform.position + distance;
    }











}//class
