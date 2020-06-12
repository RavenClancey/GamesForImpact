using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class timer : MonoBehaviour
{
    int time = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        time += 1;

        if (time > 300)
        {
            if (SceneManager.GetActiveScene().name == "CreditsScene"){
                SceneManager.LoadScene("CreditsScene2");
            } else if (SceneManager.GetActiveScene().name == "CreditsScene2")
            {
                SceneManager.LoadScene("MenuScene");
            }
        }
    }
}
