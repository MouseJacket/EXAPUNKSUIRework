using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class CycleScript : MonoBehaviour
{
    public Button verNext;
    public Button verLast;
    public Button reset;
    public Button halt;
    public Button step;
    public Button autoStep;
    public Button fastStep;
    public TextMeshProUGUI cycleCount;
    public TextMeshProUGUI versionCount;
    public int cycle;
    public int version;
    public Toggle Objective1;
    public Toggle Objective2;
    public GameObject results;
    public EffectPlayerScript speaker;
    public AudioClip clip;
    public float volume;

    void Start()
    {
        verNext.onClick.AddListener(VerNext);
        verLast.onClick.AddListener(VerLast);
        reset.onClick.AddListener(Reset);
        halt.onClick.AddListener(Halt);
        step.onClick.AddListener(Step);
        autoStep.onClick.AddListener(StartAutostep);
        fastStep.onClick.AddListener(StartFaststep);
        results.SetActive(false);
        speaker = GameObject.Find("EffectPlayer").GetComponent<EffectPlayerScript>();
    }
    void Update()
    {
        cycleCount.text = $"{cycle}";
        versionCount.text = $"{version}/100";
        if (cycle >= 184)
        {
            Objective1.isOn = true;
        }
        else
        {
            Objective1.isOn = false;
        }
        if (cycle >= 215)
        {
            Objective2.isOn = true;
        }
        else
        {
            Objective2.isOn = false;
        }
        if (cycle > 223)
        {
            if (version >= 100)
            {
                StopAllCoroutines();
                cycle = 223;
                version = 100;
                results.SetActive(true);
                results.GetComponent<Button>().onClick.AddListener(SceneLoad);
            }
            else
            {
                version++;
                cycle = 0;
            }
            
        }
    }
    void VerNext()
    {
        speaker.SFX(clip,volume);
        version++;
        if (version > 100)
        {
            version = 1;
        }
    }
    void VerLast()
    {
        speaker.SFX(clip,volume);
        version--;
        if (version < 1)
        {
            version = 100;
        }
    }
    void Reset()
    {
        speaker.SFX(clip,volume);
        cycle = 0;
        version = 0;
        StopAllCoroutines();
    }
    void Halt()
    {
        speaker.SFX(clip,volume);
        StopAllCoroutines();
    }
    void Step()
    {
        speaker.SFX(clip,volume);
        cycle++;
    }
    void StartAutostep()
    {
        speaker.SFX(clip,volume);
        StopAllCoroutines();
        StartCoroutine(Autostep());
    }
    void StartFaststep()
    {
        speaker.SFX(clip,volume);
        StopAllCoroutines();
        StartCoroutine(Faststep());
    }
    IEnumerator Autostep()
    {
        while (true)
        {
            cycle++;
            yield return new WaitForSeconds(0.1f);
        }
    }
    IEnumerator Faststep()
    {
        while (true)
        {
            cycle+=2;
            yield return new WaitForNextFrameUnit();
        }
    }
    void SceneLoad()
    {
        SceneManager.LoadScene("Desktop");
    }
}
