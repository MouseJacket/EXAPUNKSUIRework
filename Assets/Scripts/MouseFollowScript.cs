using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MouseFollowScript : MonoBehaviour
{
    public Vector3 mousePos;
    public Camera cam;
    public Vector3 followPos;
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        followPos = new Vector3(mousePos.x,mousePos.y,0);
        transform.position = followPos;
    }
}
