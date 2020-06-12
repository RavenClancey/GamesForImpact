using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadNextLevel : MonoBehaviour
{
   
    private void OnEnable ()
	{
        try
        {
            SceneManager.LoadScene("DenialScene");
        } catch
		{
            Debug.LogError("DenialScene does not exist");
		}
    }

    
}
