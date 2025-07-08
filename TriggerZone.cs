using UnityEngine;
using UnityEngine.Events;

public class TriggerZone : MonoBehaviour
{
    public string targeTag;
    
    public UnityEvent<GameObject> OnEnterEvent;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(targeTag))
        {
            OnEnterEvent.Invoke(other.gameObject);
        }
    }
}