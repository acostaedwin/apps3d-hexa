using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public WinLoose winlooseScript;
    public float velocity;
    private void Update()
    {
        transform.Translate(0, 0, velocity * Time.deltaTime);
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("!!Permiso");
            winlooseScript.LooseLevel();
        }
        Debug.Log("me teletransporto");

    }
    
}
