using System.Numerics;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class ShortcutScript : MonoBehaviour
{  
    public string appName;
    public float size;
    public Sprite appImage;
    public RectTransform rectTrans;
    public GameObject currentOpened;
    [SerializeField] public GameObject windowPrefab;
    public GameObject windowLayer;
    public UnityEngine.Vector2 instPadding;
    public GameObject shortcutLayer;
    public RectTransform winSpawn;
    private Camera MainCamera;
    void Start()
    {
        MainCamera = Camera.current;
        windowLayer = GameObject.Find("Windows");
        GetComponent<Button>().onClick.AddListener(OpenWindow);
        rectTrans = GetComponent<RectTransform>();
        winSpawn = GameObject.Find("WindowSpawner").GetComponent<RectTransform>();
    }
    void OpenWindow()
    {
        if (currentOpened != null)
        {
            Destroy(currentOpened);
        }       
        currentOpened = Instantiate(windowPrefab);
        currentOpened.transform.SetParent(windowLayer.transform,true);
        Rect canvas = GameObject.Find("Canvas").GetComponent<RectTransform>().rect;
        WindowScript openedScript = currentOpened.GetComponent<WindowScript>();
        openedScript.scale = size;
        openedScript.appName = appName;
        openedScript.winImage = appImage;
        //rectTrans.SetParent(windowLayer.transform,true);
        winSpawn.position = rectTrans.position;
        openedScript.appPos = winSpawn.localPosition;
        //rectTrans.SetParent(shortcutLayer.transform,true);

        float minX = canvas.width * -instPadding.x;
        float maxX = canvas.width * instPadding.x;
        float minY = canvas.height * -instPadding.y;
        float maxY = canvas.height * instPadding.y;

        float width = Random.Range(minX,maxX);
        float height = Random.Range(minY,maxY);
        openedScript.initPos = new UnityEngine.Vector3(width,height,0);
    }
}
