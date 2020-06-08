using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class gotoLevelScript : MonoBehaviour
{
    public BoxCollider2D boxCollision;
    public BoxCollider2D playerCollider;

    public string levelName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == playerCollider)
        {
            LoadLevel(levelName);
           
        }

    }

    void LoadLevel(string level)
    {
        SceneManager.LoadScene(level);
    }
}
