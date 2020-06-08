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

    //mouse move vars
    public GameObject mouseObject;
    private Vector3 MousePosition;
    public float moveSpeed = 10.0f;

    //sound objects
    private AudioSource fire;

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
        Collider2D Collider2D = Physics2D.OverlapCircle(mouseObject.transform.position, 1.0f);

        if (Input.GetMouseButtonDown(0) && Collider2D.gameObject == GameObject.FindGameObjectWithTag("Enemy"))
        {

        }
    }

   public void takeDamage(int Damage)
    {
        currentHealth -= Damage;
        healthBar.SetHealth(currentHealth);
        healthObject.GetComponent<playerHit>().flashImage();
    }
}
