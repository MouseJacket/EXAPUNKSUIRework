using UnityEngine;

public class EffectPlayerScript : MonoBehaviour
{
    public AudioSource speaker;
    void Start()
    {
        speaker = GetComponent<AudioSource>();
    }
    public void SFX(AudioClip file, float volume)
    {
        speaker.volume = volume;
        speaker.clip = file;
        speaker.pitch = UnityEngine.Random.Range(0.75f,1.25f);
        speaker.Play();
    }
}
