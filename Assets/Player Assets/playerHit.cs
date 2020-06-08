using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHit : MonoBehaviour
{
    private bool isShowing = false;
    public Image thisImage;

    private void Start()
    {
        thisImage.enabled = false;
    }

    private void Update()
    {
        if (isShowing)
        {
            thisImage.enabled = true;
            isShowing = false;
        }
        else 
        {
            thisImage.enabled = false;
        }
    }

    public void flashImage()
    {
        isShowing = true;
    }
}
