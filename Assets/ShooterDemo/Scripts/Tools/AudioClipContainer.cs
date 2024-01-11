using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class AudioClipContainer : MonoBehaviour
{
    [Tooltip("We can use addressable clip also with some changes in loading them before use.")]
    [SerializeField] AudioClip[] audioClips;
    [SerializeField] AudioSource audioSource;
    public AudioClip GetRandomClip()=> audioClips[Random.Range(0, audioClips.Length - 1)]; 
    public AudioClip GetClip(int val) => audioClips[val];

    public void PlayClip(int val)
    {
        if (audioSource)
        { 
            audioSource.clip = GetClip(val); 
            audioSource.Play();
        }
    }
    public void PlayRandomClip()
    {
        if (audioSource)
        { 
            audioSource.clip = GetRandomClip(); 
            audioSource.Play();
        }
    }
}
