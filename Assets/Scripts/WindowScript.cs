using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WindowScript : MonoBehaviour
{
    public Button closeButton;
    public TextMeshProUGUI title;
    public Vector2 size;
    public float scale;
    public Sprite winImage;
    public string appName;
    public Vector3 initPos;
    public Vector3 appPos;
    public Image winDisplay;
    public RectTransform winBackground;
    public GameObject winBar;
    public RectTransform rectTrans;
    public RectTransform textTrans;
    public RectTransform closeTrans; //Super messy way of doing this, but quick and clean enough.
    public EffectPlayerScript speaker;
    public AudioClip effect;
    public float volume;
    void Start()
    {
        speaker = GameObject.Find("EffectPlayer").GetComponent<EffectPlayerScript>();
        rectTrans = GetComponent<RectTransform>();
        closeButton.onClick.AddListener(CloseWindow);
        title.text = appName;
        winDisplay.sprite = winImage;
        speaker.SFX(effect,volume);

        float aspectRatio = winDisplay.sprite.rect.width / winDisplay.sprite.rect.height;
        size = new Vector3(aspectRatio * scale, scale, 1);
        winDisplay.GetComponent<RectTransform>().sizeDelta = size;
        winBackground.sizeDelta = new Vector3(size.x+18, size.y+50, 1);
        winBar.GetComponent<RectTransform>().sizeDelta = new Vector3(size.x*1.02f,40,1);
        winBar.transform.parent.GetComponent<RectTransform>().sizeDelta=new Vector3(size.x+18, size.y+50, 1);
        textTrans.sizeDelta = new Vector3(size.x+18,40,1);
        closeTrans.sizeDelta = new Vector3(size.x+18,40,1);
        if (appName == "Contracts"||appName == "Contract Info")
        {
            Button nextScene = winDisplay.gameObject.AddComponent<Button>();
            nextScene.onClick.AddListener(SceneTransition);
        }

        StartCoroutine(ExpandWindow());
    }

    IEnumerator ExpandWindow()
    {
        float timer = 0.15f;
        float timeElapsed = 0f;
        while (timeElapsed < timer)
        {
            float percentage = timeElapsed/timer;
            rectTrans.localPosition = Vector2.Lerp(appPos, initPos, percentage);
            rectTrans.localScale = new Vector2(1,1)*Mathf.Lerp(0f, 1f, percentage);
            timeElapsed += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }
    public void CloseWindow()
    {
        StartCoroutine(CloseAnim());
    }
    IEnumerator CloseAnim()
    {
        Animator buttonAnim = closeButton.gameObject.GetComponent<Animator>();
        while (buttonAnim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
        {
            yield return null;
        }
        Destroy(gameObject);
    }
    public void OnDestroy()
    {
        speaker.SFX(effect,volume);
    }
    public void SceneTransition()
    {
        Debug.Log(SceneManager.GetActiveScene().name);
        if (SceneManager.GetActiveScene().name == "Desktop")
        {
            SceneManager.LoadScene("Level");
        }
        else
        {
            SceneManager.LoadScene("Desktop");
        }
    }

}
