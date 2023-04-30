using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }
    // Start is called before the first frame update
    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
        
    }

    // Update is called once per frame
   
}
