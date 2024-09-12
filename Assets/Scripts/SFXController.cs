
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SFXController : MonoBehaviour
{
    public static SFXController instance;

    [SerializeField] private AudioSource audioSource;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

    }
    public void PlayAudio(AudioClip audioClip)
    {
        audioSource.clip = audioClip;

        audioSource.Play();

    }

}
