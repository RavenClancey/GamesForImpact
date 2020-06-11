using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    //health vars
    public int maxHealth = 100;
    public int currentHealth;
    public GameObject healthObject;
    public HealthBar healthBar;

    //mouse pointer vars
    public GameObject mouseObject;
    private Vector3 MousePosition;
    public float moveSpeed = 10.0f;
    public LayerMask enemyCollision;
    public bool canFire = false;
    private GameObject[] enemies;

    //sound objects
    public AudioSource fire;
    public AudioSource scream;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
        Cursor.visible = false;
        mouseObject.GetComponent<SpriteRenderer>().enabled = false;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
 
        MousePosition = Input.mousePosition;
        MousePosition = Camera.main.ScreenToWorldPoint(MousePosition);
        mouseObject.transform.position = Vector2.Lerp(transform.position, MousePosition, moveSpeed);
            
        if (canFire)
        {

            if (Input.GetMouseButtonDown(1))
            {
                fire.Play();
            }

            for (int i = 0; i < enemies.Length; i++)
            {
                if (enemies[i].GetComponent<EnemyHit>().HasCollided() == true)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        scream.Play();
                    }
                }
            }
        }
    }

   public void takeDamage(int Damage)
    {
        currentHealth -= Damage;
        healthBar.SetHealth(currentHealth);
        healthObject.GetComponent<playerHit>().flashImage();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(mouseObject.transform.position, 1.0f);
       // Gizmos.color = Color.green;
       // Gizmos.DrawLine(groundDetect.position, new Vector2(groundDetect.position.x - 1.0f, groundDetect.position.y));
    }
}
