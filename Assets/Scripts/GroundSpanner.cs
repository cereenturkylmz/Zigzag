using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpanner : MonoBehaviour
{
    [SerializeField] GameObject sonZemin;


    private void Start()
    {
        for(int i = 1; i<10; i++)
        {
            ZeminOlustur();
        }
    }

    void ZeminOlustur()
    {
        sonZemin = Instantiate(sonZemin, sonZemin.transform.position +
            Vector3.back, sonZemin.transform.rotation);
    }
















}//class
