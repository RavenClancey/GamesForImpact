using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backwallScript : MonoBehaviour
{
    public Animator player;
    public BoxCollider2D myCollider;


    private void Update()
    {
        //player.GetCurrentAnimatorStateInfo(0).IsTag("1")
        Debug.Log(player.GetCurrentAnimatorStateInfo(0).IsTag("1"));
        if (player.GetCurrentAnimatorStateInfo(0).IsTag("1"))
        {
            myCollider.isTrigger = true;
        }
        else
        {
            myCollider.isTrigger = false;
        }
    }

}
