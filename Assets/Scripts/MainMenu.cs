using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //added the library which we need to switch from main menu to the game selection channel

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        //loading the current scene and from the build settings on unity we added a queue of scneses. so we just select the next one
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
