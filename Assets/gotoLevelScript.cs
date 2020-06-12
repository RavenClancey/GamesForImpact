using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class gotoLevelScript : MonoBehaviour
{
    public BoxCollider2D boxCollision;
    public GameObject playerCollider;
    public GameObject mousePointer;

    public string levelName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        mousePointer.GetComponent<SpriteRenderer>().enabled = false;
        playerCollider.gameObject.GetComponent<playerScript>().canFire = false;
        
        if (collision == playerCollider.gameObject.GetComponent<BoxCollider2D>())
        {
            LoadLevel(levelName);
           
        }

    }

    void LoadLevel(string level)
    {
        SceneManager.LoadScene(level);
    }
}
