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
   

    //sound objects
    public AudioSource fire;
    public AudioSource scream;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
        Cursor.visible = false;
        

    }

    // Update is called once per frame
    void Update()
    {
        MousePosition = Input.mousePosition;
        MousePosition = Camera.main.ScreenToWorldPoint(MousePosition);
        mouseObject.transform.position = Vector2.Lerp(transform.position, MousePosition, moveSpeed);
        Collider2D[] enemyCollider = Physics2D.OverlapCircleAll(mouseObject.transform.position, 1.0f, enemyCollision);

        for (int i = 0; i < enemyCollider.Length; i++)
        {
            if (enemyCollider[i].gameObject == GameObject.FindGameObjectWithTag("Enemy"))
            {

                scream.Play();
                
            }
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            fire.Play();
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
