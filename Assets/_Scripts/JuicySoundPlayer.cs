using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class JuicySoundPlayer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    AudioSource audioSource;
    [SerializeField]
    AudioClip[] audioClips;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    public void PlayClip()
    {
        audioSource.clip = audioClips[Random.Range(0, audioClips.Length)];
        audioSource.pitch = Random.Range(0.8f, 1.2f);
        audioSource.Play();
    }
}
