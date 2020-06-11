using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{

    public BoxCollider2D thisObject;
    public BoxCollider2D mousePointer;
    

    public bool isCollided = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
           
        if (collision == mousePointer)
        {
            isCollided = true;
        }
            
    }
  


    public bool HasCollided()
    {
        return isCollided;
    }
}
