using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoose : MonoBehaviour
{
    private bool gameEnded;

    //Cuando el pj, completa las fichas llama esta función
    public void WinLevel() 
    {
        if (!gameEnded)
        {
            Debug.Log("You win");
            //Aquí ponen el puzzle o el reto que comentaron
            SceneManager.LoadScene("Trivia1");
            gameEnded = true;
        }
    }

    public void LooseLevel()
    {
        if (!gameEnded)
        {
            Debug.Log("Perdiste pinche peggo");
            SceneManager.LoadScene("Game");
            gameEnded = true;

        }
    }

    
}
