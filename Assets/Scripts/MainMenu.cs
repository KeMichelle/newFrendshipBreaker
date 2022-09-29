using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //added the library which we need to switch to the chosen scene

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        //loading the current scene and from the build settings on unity we added a queue of scneses. so we just select the next one
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
