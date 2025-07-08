using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.ParticleSystemJobs;
using UnityEngine.Rendering.PostProcessing;

public class BeiBerührung : MonoBehaviour
{
    public ParticleSystem fog;
    public void Start()
    {
        GetComponent<TriggerZone>().OnEnterEvent.AddListener(WennBerührt);
        if (fog == null)
        {
            Debug.Log("Das Partikelsystem wurde nicht zugewiesen.");
        }
    }
    public void WennBerührt(GameObject go)
    {
        Debug.Log("Wenigstens funktioniert des"); 
        fog.Play();
    }


}