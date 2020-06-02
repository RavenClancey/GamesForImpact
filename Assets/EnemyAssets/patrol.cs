﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrol : MonoBehaviour
{
    public float speed;

    private bool movingRight = true;

    public Transform groundDetect;

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        if (aggroVision())
        {
            speed = 0;
        } else
        {
            speed = 4;
        }
        
        movementCollision();

            
        
    }

    bool aggroVision()
    {
        RaycastHit2D visionInfoLeft = Physics2D.Raycast(transform.position, Vector2.left, 10f);
        RaycastHit2D visionInfoRight = Physics2D.Raycast(transform.position, Vector2.right, 10f);
        if (movingRight == true && visionInfoRight.collider == true)
        {
            if (visionInfoRight.collider.gameObject == GameObject.FindGameObjectWithTag("Player"))
            {
               
                shoot();
                return (true);
            }


        }
        else if (movingRight == false && visionInfoLeft.collider == true)
        {
            if (visionInfoLeft.collider.gameObject == GameObject.FindGameObjectWithTag("Player"))
            {
              
                shoot();
                return (true);
            }


        }
        else
        {
            speed = 4;
            return (false);
        }
        return (false);
    }

    void movementCollision()
    {
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetect.position, Vector2.down, 0.5f);
        RaycastHit2D rightInfo = Physics2D.Raycast(groundDetect.position, Vector2.right, 1f);
        RaycastHit2D leftInfo = Physics2D.Raycast(groundDetect.position, Vector2.left, 1f);


        if (groundInfo.collider == false || rightInfo.collider == true && rightInfo.collider.gameObject != GameObject.FindGameObjectWithTag("Player") || leftInfo.collider == true && leftInfo.collider.gameObject != GameObject.FindGameObjectWithTag("Player"))
        {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }

    void shoot()
    {
        speed = 0;
        Debug.Log("BANG BANG");

    }
}