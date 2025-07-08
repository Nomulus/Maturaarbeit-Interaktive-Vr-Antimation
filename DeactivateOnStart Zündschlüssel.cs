using System;
using UnityEngine;

public class DeactivateObjectOnStart : MonoBehaviour
{
    // Öffentliches GameObject, das deaktiviert werden soll
    public GameObject Zündschlüssel;

    void Start()
    {
        // Überprüfe, ob das Objekt im Inspektor zugewiesen ist
        if (Zündschlüssel != null)
        {
            // Deaktiviert das Objekt
            Zündschlüssel.SetActive(false);       
        }
        else
        {
            Debug.LogWarning("Zündschlüssel Deactivate is not assigned in the inspector.");
        }
    }
}