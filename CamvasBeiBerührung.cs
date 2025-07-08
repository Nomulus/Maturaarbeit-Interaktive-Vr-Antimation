// CamvasBeiBeruhrung.cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamvasBeiBeruhrung : MonoBehaviour
{
    public GameObject Camvas;

    public void Start()
    {
        Camvas.SetActive(false);
        // Wenn das 'OnEnterEvent' von TriggerZoneEinstellungen ausgelost wird, ruft es WennBerührt auf.
        GetComponent<TriggerZoneEinstellungen>().OnEnterEvent.AddListener(WennBeruhrt);
    }

    public void WennBeruhrt(GameObject go)
    {
        Camvas.SetActive(true);
    }
}