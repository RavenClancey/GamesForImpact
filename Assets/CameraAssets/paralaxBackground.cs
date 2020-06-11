using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paralaxBackground : MonoBehaviour
{
    private Transform cameraTransform;
    public Camera mainCamera;
    [SerializeField] private Vector2 paralaxEffectMultiplyer;
    private Vector3 lastCameraPosition;
    float lastCameraScale;
    // Start is called before the first frame update
    private void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraScale = mainCamera.orthographicSize;
        lastCameraPosition = cameraTransform.position; 
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
        float deltaScale = mainCamera.orthographicSize - lastCameraScale;
        
        transform.position += new Vector3(deltaMovement.x * paralaxEffectMultiplyer.x, deltaMovement.y * paralaxEffectMultiplyer.y);
        transform.localScale += new Vector3(deltaScale * 0.002f, deltaScale * 0.02f);
        lastCameraPosition = cameraTransform.position;
        lastCameraScale = mainCamera.orthographicSize;
    }
}
