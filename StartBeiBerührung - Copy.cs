using UnityEngine;

public class Berührung : MonoBehaviour
{
    public ParticleSystem fog;

    public void Start()
    {
        // Verknüpft die Methode mit dem Trigger-Event.
        GetComponent<TriggerZone>().OnEnterEvent.AddListener(WennBerührt);
    }

    //wird durch TriggerZone.cs ausgelöst
    public void WennBerührt(GameObject go)
    {
        if (fog != null)
        {
            fog.Play();
        }
    }
}