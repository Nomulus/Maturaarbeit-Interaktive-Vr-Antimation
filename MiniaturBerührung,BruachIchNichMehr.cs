using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniaturiBerührung : MonoBehaviour
{
    public void Start()
    {
        GetComponent<TriggerZone>().OnEnterEvent.AddListener(MiniaturiBerührt);
    }
    public void MiniaturiBerührt(GameObject go)
    {
        Debug.Log("Scene 1 Sollte geladen werden" );
        go.SetActive(false);
    }
}
