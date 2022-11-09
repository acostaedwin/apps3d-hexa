using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerTriggers : MonoBehaviour
{
    public WinLoose winlooseScript;
    public Inventario inventariohooo;


    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -1f)
        {
            winlooseScript.LooseLevel();
        }        
        else if (inventariohooo.Cantidad == 5f)
        {
            //Debug.Log("Ganaste en el pt");
            winlooseScript.WinLevel();
        }
        
        
    }
}
