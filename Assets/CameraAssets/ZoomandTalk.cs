using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomandTalk : MonoBehaviour
{
    public BoxCollider2D boxCollision;
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

    void OnTriggerEnter2D(Collider2D collision)
    {
 
       if (collision == playerCollider)
        {
            player.GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>().m_MaxSpeed = 2;
            mousePointer.enabled = false;
            expectedZoom = minZoom;
            PlayAudio();
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
    
        if (collision == playerCollider)
        {
            player.GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>().m_MaxSpeed = 5;
            mousePointer.enabled = true;
            expectedZoom = maxZoom;
        }
    }


    private void Update()
    {
        if (mainCamera.orthographicSize < minZoom)
        {
            mainCamera.orthographicSize = minZoom;
        } 
        else if (mainCamera.orthographicSize > maxZoom)
        {
            mainCamera.orthographicSize = maxZoom;
        }
        else  if (expectedZoom > mainCamera.orthographicSize)
        {
            
            mainCamera.orthographicSize += zoomSpeed;
            
        }
        else if (expectedZoom < mainCamera.orthographicSize)
        {
           
            mainCamera.orthographicSize -= zoomSpeed;
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
