using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ProceduralG : MonoBehaviour
{
    public GameObject[] objetosPosibles;
    [Range(0f,1f)]
    public float pro = 0.60f;

    void Start()
    {
        if(Random.Range(0f,1f)<= pro )
        {
            Instantiate(
                objetosPosibles[Random.Range(0,objetosPosibles.Length)]
                //transform.position,
                //Quaternion.Euler(Vector3.up * (Random.Range(0, 4) * 90))
            );    
        }

        
    }
}
