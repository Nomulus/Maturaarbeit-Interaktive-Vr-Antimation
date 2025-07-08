// AktiviereEinschlag.cs
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AktiviereEinschlag : MonoBehaviour
{
    public AudioSource schussEinschlagAudio;
    public ParticleSystem schussEinschlagDreck;
    public ParticleSystem rauchUnten;
    public ParticleSystem rauchOben;

    public void SchussAbpielen()
    {
        // Diese Methode wird voraussichtlich Karabiner98kschiesstfurNPCs oder Spieler-Schiess-Skript aufgerufen,

        // Audioquelle abspielen
        if (schussEinschlagAudio != null)
        {
            Debug.Log("Schuss Audio wird abgespielt");
            schussEinschlagAudio.Play();
        }

        // Partikelsysteme abspielen
        if (schussEinschlagDreck != null)
        {
            schussEinschlagDreck.Play();
        }

        if (rauchUnten != null)
        {
            rauchUnten.Play();
        }

        if (rauchOben != null)
        {
            rauchOben.Play();
        }
    }
}