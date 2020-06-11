using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomandTalk : MonoBehaviour
{
   
    public BoxCollider2D playerCollider;
    public SpriteRenderer mousePointer;
    public GameObject player;
    public Camera mainCamera;

    public AudioSource VO;
    public float maxZoom;
    public float minZoom;

    private bool triggered = false;

    [Range(0, 1)] [SerializeField] private float zoomSpeed = .36f;

    private float expectedZoom = 7;

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision == playerCollider)
       {
            player.GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>().m_MaxSpeed = 2;

            player.GetComponent<playerScript>().zooming = true;

            PlayAudio();
       }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
    
        if (collision == playerCollider)
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
