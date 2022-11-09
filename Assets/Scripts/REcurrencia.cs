using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class REcurrencia : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("OBJ"))
        {
            other.transform.Translate(0, 0, -60);
        }
    }
}
