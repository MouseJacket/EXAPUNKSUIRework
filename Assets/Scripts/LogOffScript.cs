using UnityEngine;
using UnityEngine.UI;

public class LogOffScript : MonoBehaviour
{
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(Quit);
    }
    void Quit()
    {
        Debug.LogError("Application Quit");
        Application.Quit();
    }

}
