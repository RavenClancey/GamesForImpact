using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomandTalk : MonoBehaviour
{
   
    
    public GameObject player;


    public AudioSource VO;


    private bool triggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision == player.gameObject.GetComponent<BoxCollider2D>())
       {
            player.GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>().m_MaxSpeed = 2;

            player.GetComponent<playerScript>().zooming = true;

            PlayAudio();
       }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
    
        if (collision == player.gameObject.GetComponent<BoxCollider2D>())
        {
            player.GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>().m_MaxSpeed = 5;

            player.GetComponent<playerScript>().zooming = false;
        }
    }


    

    private void PlayAudio()
    {
        if (triggered == false)
        {
            VO.Play();
            triggered = true;
        }
    }
}
