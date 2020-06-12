using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playbutton : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("DenialScene");
    }

    public void QuitGame()
    {
        Debug.Log("quitting");

        Application.Quit();

    }
}
