using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera playerCamera;

    [SerializeField] RigidbodyFirstPersonController controller; 

    float zoomedIn = 16f;
    float zoomedOut = 60f;

    float zoomOutSensX = 2; 
    float zoomOutSensY = 2; 
    float zoomInSensX = 0.5f; 
    float zoomInSensY = 0.5f; 

    bool zoom = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (!zoom)
            {
                SetSensitivityZoom();
                ZoomInFOV();
            }
            else if (zoom)
            {
                SetSensitivityZoomOut();
                ZoomOutFOV();
            }
        }
    }

    private void OnDisable()
    {
        SetSensitivityZoomOut();
        ZoomOutFOV();
    }

    private void ZoomOutFOV()
    {
        playerCamera.fieldOfView = zoomedOut;
        zoom = false;
    }

    private void ZoomInFOV()
    {
        playerCamera.fieldOfView = zoomedIn;
        zoom = true;
    }

    private void SetSensitivityZoomOut()
    {
        controller.mouseLook.XSensitivity = zoomOutSensX;
        controller.mouseLook.YSensitivity = zoomOutSensY;
    }

    private void SetSensitivityZoom()
    {
        controller.mouseLook.XSensitivity = zoomInSensX;
        controller.mouseLook.YSensitivity = zoomInSensY;
    }
}
