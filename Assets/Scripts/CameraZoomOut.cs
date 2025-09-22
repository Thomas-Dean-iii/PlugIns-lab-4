using UnityEngine;

public class CameraZoomOut : MonoBehaviour
{
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("Zooming out");
            if (cam.orthographic)
            {
                // 2D orthographic camera
                cam.orthographicSize += 2f; // zoom out
            }
            else
            {

                cam.fieldOfView += 10f; // zoom out
            }
        }
    }
}
