using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    //health vars
    public int maxHealth = 100;
    public int currentHealth;
    public GameObject healthObject;
    

    //mouse pointer vars
    public GameObject mouseObject;
    private Vector3 MousePosition;
    public float moveSpeed = 10.0f;
    public LayerMask enemyCollision;
    public bool canFire = false;
    [SerializeField] private GameObject[] enemies;

    //sound objects
    public AudioSource fire;
    public AudioSource scream;

    public Camera mainCamera;
    public bool zooming = false;
    public Vector3 spawn;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        spawn = transform.position;
        Cursor.visible = false;
        mouseObject.GetComponent<SpriteRenderer>().enabled = false;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
 
        MousePosition = Input.mousePosition;
        MousePosition = Camera.main.ScreenToWorldPoint(MousePosition);
        mouseObject.transform.position = Vector2.Lerp(transform.position, MousePosition, moveSpeed);
            
        if (canFire)
        {
            if (Input.GetMouseButtonDown(0))
            {
                fire.Play();
            }

            if (enemies != null)
            {
                for (int i = 0; i < enemies.Length; i++)
                {
                    Debug.Log(enemies[i].gameObject.GetComponent<EnemyHit>().HasCollided());
                    if (enemies[i].gameObject.GetComponent<EnemyHit>().HasCollided() == true && Input.GetMouseButtonDown(0))
                    {
                        scream.Play();
                        enemies[i].transform.position = new Vector3(enemies[i].transform.position.x, enemies[i].transform.position.y - 500);
                    }
                }
            }
            
        }

        if (zooming)
        {
            if (mainCamera.orthographicSize > 3)
            {
                mainCamera.orthographicSize -= 0.05f;
            }
        }
        else
        {
            if (mainCamera.orthographicSize < 7)
            {
                mainCamera.orthographicSize += 0.05f;
            }
        }

    }

  

   public void takeDamage(int Damage)
   {
        currentHealth -= Damage;
   }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(mouseObject.transform.position, 1.0f);
       // Gizmos.color = Color.green;
       // Gizmos.DrawLine(groundDetect.position, new Vector2(groundDetect.position.x - 1.0f, groundDetect.position.y));
    }
}
