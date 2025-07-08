using System.Collections;
using UnityEngine;

public class Bereithalten : MonoBehaviour
{
    public AudioSource KompaniechefAudioSource;
    public AudioClip BereithaltenClip;

    // Start is called before the first frame update
    void Start()
    {
        if (KompaniechefAudioSource == null)
        {
            Debug.LogError("Kompaniechef AudioSource ist nicht zugewiesen");
            return;
        }
        
        if (BereithaltenClip == null)
        {
            Debug.LogError("Bereithalten Audio Clip ist nicht zugewiesen");
            return;
        }

        // Ruft die Methode auf, die den Clip nach 3 Sekunden abspielt
        StartCoroutine(PlayBereithaltenWithDelay(3f));
    }

    private IEnumerator PlayBereithaltenWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        PlayBereithalten();
    }

    private void PlayBereithalten()
    {
        KompaniechefAudioSource.clip = BereithaltenClip; 
        KompaniechefAudioSource.Play();
    }
}
