using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //added the library which we need to switch from main menu to the game selection channel

public class PlayMinikartGame : MonoBehaviour
{
    
    public float timeoftransition = 1f;

    public void playMinikartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

   
}
