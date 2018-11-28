using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public int levelToLoad;

    // Use this for initialization
    public void LoadLevel()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void LevelExit()
    {
        Application.Quit();
    }
}
