using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public static void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    // Update is called once per frame
    public static void QuitGame()
    {

        Application.Quit();
    }
}
