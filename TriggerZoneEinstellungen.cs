using UnityEngine;
using UnityEngine.Events;

public class TriggerZoneEinstellungen : MonoBehaviour
{
    public string targeTag;
    
    // Aktionen, die ausgeführt werden.
    public UnityEvent<GameObject> OnEnterEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(targeTag))
        {
            OnEnterEvent.Invoke(other.gameObject);
        }
    }
}