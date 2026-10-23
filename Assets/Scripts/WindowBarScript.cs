using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class WindowBarScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject window;
    public GameObject windowLayer;
    public GameObject mouseFollow;
    void Start()
    {
        window = transform.parent.gameObject.transform.parent.gameObject;//Really dumb way of fixing this issue but sure ig
        windowLayer = GameObject.Find("Windows");
        mouseFollow = GameObject.Find("MouseFollow");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        window.transform.SetParent(mouseFollow.transform,true);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        window.transform.SetParent(windowLayer.transform,true); 
    }
}
