using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 yon = Vector3.left;
    [SerializeField] float speed;

    public GroundSpanner groundSpanner;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
          if(yon.x == 0)
            {
                yon = Vector3.left;
            }
            else
            {
                yon = Vector3.back;
            }
        }
    }

    private void FixedUpdate()
    {
        Vector3 hareket = yon * speed * Time.deltaTime;
        transform.position += hareket; //hareket değerini sürekli pozisyona ekle
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.CompareTag("Zemin"))
        {
            YokEt(collision.gameObject);
            groundSpanner.ZeminOlustur();
        }
    }

    void YokEt(GameObject zemin)
    {
        Destroy(zemin);
    }



}//class
