using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    public BoxCollider2D mousePointer;
    public bool isCollided = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if (collision == mousePointer)
        {
            Debug.Log(collision);
            isCollided = true;
        }
            
    }   
    
    private void OnTriggerExit2D(Collider2D collision)
    {   
        if (collision == mousePointer)
        {
            Debug.Log(collision);
            isCollided = false;
        }
            
    }
  


    public bool HasCollided()
    {
        return isCollided;
    }
}
