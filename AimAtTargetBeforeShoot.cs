using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimAtTargetBeforeShoot : MonoBehaviour
{
    public Transform target; // Das Ziel, auf das die Waffe ausgerichtet werden soll
    private Karabiner98kschiesstfürNPCs karabinerScript;

    // Start is called before the first frame update
    void Start()
    {
        karabinerScript = GetComponent<Karabiner98kschiesstfürNPCs>();

        if (karabinerScript == null)
        {
            Debug.LogError("Karabiner98kschiesstfürNPCs Skript nicht gefunden!");
            return;
        }

        if (target == null)
        {
            Debug.Log("Kein Ziel zugewiesen! Bitte ein Zielobjekt zuweisen.");
            return;
        }
    }

    public void AimAtTarget() // Diese Methode richtet die Waffe auf das Ziel aus
    {
        // Berechnet die Richtung vom aktuellen Position des shootPoints zum Ziel
        Vector3 directionToTarget = target.position - karabinerScript.shootPoint.position;

        // Berechnet die Rotation, um das Parent-Objekt in Richtung des Ziels auszurichten
        Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);

        // Erstellt eine zusätzliche Rotation um -90 Grad auf der X-Achse weil ich die Waffe falsch importiert habe und j́etzt einfach damit leben muss
        Quaternion additionalRotation = Quaternion.Euler(-90f, 0f, 0f);

        // Kombiniert die Rotationen
        Quaternion finalRotation = targetRotation * additionalRotation;

        // Setzt die Rotation des gesamten Parent-Objekts (also des Karabiners)
        transform.rotation = finalRotation;
    }
}
