using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Complete : MonoBehaviour
{
    public AudioClip  Level_Complete_Audio;
    public AudioSource MainAudio;
    private void OnEnable()
    {
        MainAudio.PlayOneShot(Level_Complete_Audio);
    }
}
