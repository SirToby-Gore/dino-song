using UnityEngine;

public class isVisibile : MonoBehaviour
{
    public Camera main_camera;

    void Start()
    {
        if (main_camera == null)
            main_camera = Camera.main;
    }

    void Update()
    {
        Vector3 viewPos = main_camera.WorldToViewportPoint(transform.position);
        Vector3 pos = main_camera.transform.position;

        if (viewPos.y < 0)
        {
            Debug.Log("has gone offscreen down");
            pos.y -= 2f * main_camera.orthographicSize;
            main_camera.transform.position = pos;
        }

        if (viewPos.y > 1)
        {
            Debug.Log("has gone offscreen up");
            pos.y += 2f * main_camera.orthographicSize;
            main_camera.transform.position = pos;
        }
    }
}