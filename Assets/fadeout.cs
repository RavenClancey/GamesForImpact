using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class fadeout : MonoBehaviour
{

    public GameObject player;
    public Image image;
    [SerializeField] private bool fade = false;

    private void Update()
    {
        if (player.transform.position.x > 217)
        {
            fade = true; 
        }

        if (fade == true)
        {
            var tempColor = image.color;
            tempColor.a += 0.002f;
            image.color = tempColor;

            player.GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>().m_MaxSpeed = 0;
        }
      
        if (image.color.a > 2)
        {

            SceneManager.LoadScene("AcceptanceScene");
        }
    }

}
