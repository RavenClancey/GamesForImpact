using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setFiring : MonoBehaviour
{
    public BoxCollider2D boxCollision;
    public BoxCollider2D playerCollider;
    public SpriteRenderer mousePointer;
    public AudioSource VO;
    public GameObject player;

    private bool triggered = false;


    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision == playerCollider)
        {
            player.GetComponent<playerScript>().canFire = true;
            mousePointer.enabled = true;
            PlayAudio();
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
