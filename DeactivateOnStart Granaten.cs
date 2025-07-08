using System;
using UnityEngine;

public class DeactivateaObjectOnStart : MonoBehaviour
{
    // Öffentliches GameObject, das deaktiviert werden soll
    public GameObject Granate1;
    public GameObject Granate2;

    void Start()
    {
        // Überprüfe, ob das Objekt im Inspektor zugewiesen ist
        if (Granate1&&Granate2 != null)
        {
            // Deaktiviert das Objekt
            Granate1.SetActive(false);
            Granate2.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Granate1/2 is not assigned in the inspector.");
        }
    }
}