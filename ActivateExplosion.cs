using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateExplosion : MonoBehaviour
{
    public GameObject Explosion;
    public GameObject Splitter;
    public AudioSource GranateExplosion;
    public void ActivatetheExplosion()
    {
        if (Explosion != null)
        {
            Explosion.SetActive(true);
            Splitter.SetActive(true);
        }
        else
        {
            Debug.LogWarning("no Explosion for Grenade was assigned");
        }
    }

    public void ExplosionSound()
    {
        GranateExplosion.PlayOneShot(GranateExplosion.clip);
    }
}
