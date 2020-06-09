using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrol : MonoBehaviour
{
    public float speed;
    public AudioSource audioSource;
    private bool movingRight = true;
    public float bulletDelay = 100.0f;
    private float bulletDelayTimer = 0.0f;
    public GameObject playerObject;
    public LayerMask whatIsGroud;
    public LayerMask toDetect;
    
    

    public Transform groundDetect;

    void FixedUpdate()
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
        RaycastHit2D visionInfoLeft = Physics2D.Raycast(transform.position, Vector2.left, 10f, toDetect);
        RaycastHit2D visionInfoRight = Physics2D.Raycast(transform.position, Vector2.right, 10f, toDetect);

        if (movingRight == true && visionInfoRight.collider == true && visionInfoRight.collider.gameObject != GameObject.FindGameObjectWithTag("Platform"))
        {
            if (visionInfoRight.collider.gameObject == GameObject.FindGameObjectWithTag("Player"))
            {
                shoot();
                return (true);
            }

        }
        else if (movingRight == false && visionInfoLeft.collider == true && visionInfoLeft.collider.gameObject != GameObject.FindGameObjectWithTag("Platform"))
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
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetect.position, Vector2.down, 0.5f, whatIsGroud);
        RaycastHit2D rightInfo = Physics2D.Raycast(groundDetect.position, Vector2.right, 0.1f, whatIsGroud);
        RaycastHit2D leftInfo = Physics2D.Raycast(groundDetect.position, Vector2.left, 0.1f, whatIsGroud);


        if (groundInfo.collider == false || groundInfo.collider == true && leftInfo.collider == true || groundInfo.collider == true && rightInfo.collider == true)
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
        if (bulletDelayTimer >= bulletDelay)
        {
            audioSource.Play();
            playerObject.GetComponent<playerScript>().takeDamage(20);
            bulletDelayTimer = 0;
        }
        else
        {
            bulletDelayTimer++;
        }
        speed = 0;
        Debug.Log("BANG BANG");

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(groundDetect.position, new Vector2(groundDetect.position.x + 1.0f, groundDetect.position.y));
        Gizmos.color = Color.green;
        Gizmos.DrawLine(groundDetect.position, new Vector2(groundDetect.position.x - 1.0f, groundDetect.position.y));
        
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(groundDetect.position, new Vector2(groundDetect.position.x, groundDetect.position.y - 0.1f));
    }
}