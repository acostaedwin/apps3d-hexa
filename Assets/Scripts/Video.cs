using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Video : MonoBehaviour
{
    
    void Start()
    {
        StartCoroutine(PlayGame());
    }

   IEnumerator PlayGame()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Menu");

    }

 
}
