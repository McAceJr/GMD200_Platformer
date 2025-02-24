using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{

    public void Quit()
    {

        Application.Quit();

    }

    public void LevelSelect()
    {

        SceneManager.LoadScene("Level Select");

    }

    public void MainMenu()
    {

        SceneManager.LoadScene("Main Menu");

    }

}
