using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LosLosLosrufen : MonoBehaviour
{
    public AudioSource KompaniechefAudioSource;
    public AudioClip LosLosLosClip;

    public
    // Start is called before the first frame update
    void Start()
    {
        if (KompaniechefAudioSource == null)
        {
            Debug.LogError("Kompaniechef AudioSource ist nicht zugewiesen");
        }
            if (LosLosLosClip == null)
        {
            Debug.LogError("LosLosLos Audio Clip ist nicht zugewiesen");
        }
    }

    public void PlayLosLosLos() //wird über Animation Event ausgelöst
    {
        KompaniechefAudioSource.clip = LosLosLosClip; 
        KompaniechefAudioSource.Play();
        Debug.Log("LosLosLos wurde gerufen");
    }
}
