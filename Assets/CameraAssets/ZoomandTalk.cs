using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomandTalk : MonoBehaviour
{
    public BoxCollider2D boxCollision;
    public BoxCollider2D playerCollider;
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
            expectedZoom = minZoom;
            PlayAudio();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision == playerCollider)
        {
            expectedZoom = maxZoom;
        }
    }


    private void Update()
    {
        
        if (expectedZoom > mainCamera.orthographicSize)
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
