﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class acceptanceScript : MonoBehaviour
{
    private int timer = 0;

    public AudioSource sound1;
    

    public AudioSource sound2;
    
    public AudioSource sound3;

    public AudioSource sound4;

    public AudioSource music;

    public Text fin;

    private bool played1 = false;
    private bool played2 = false;
    private bool played3 = false;
    private bool played4 = false;
    // Update is called once per frame
    void FixedUpdate()
    {
        timer += 1;
        Debug.Log(timer);
        if (timer > 100 && played1 == false){
            sound1.Play();
            played1 = true;
        }

        if (timer > 550 && played2 == false)
        {
            sound2.Play();
            played2 = true;
        }

        if (timer > 800 && played3 == false)
        {
            sound3.Play();
            played3 = true;
        }
        if (timer > 1220 && played4 == false)
        {
            sound4.Play();
            played4 = true;
        }
        if (timer > 1650 )
        {
  
            var tempColor = fin.color;
            tempColor.a += 0.02f;
            fin.color = tempColor;

            music.volume -= 0.001f;
            
        }

        if (timer > 2000)
        {
            SceneManager.LoadScene("CreditsScene");
          
        }
    }
}
