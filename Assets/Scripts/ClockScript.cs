using UnityEngine;
using System;
using TMPro;

public class ClockScript : MonoBehaviour
{
    [SerializeField] public string clockTime;
    public TextMeshProUGUI clock;
    void Update()
    {
        clockTime = DateTime.Now.ToString();
        clock.text = clockTime;
    }
}
