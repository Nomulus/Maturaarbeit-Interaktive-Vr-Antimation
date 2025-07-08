using UnityEngine;

public class LookToActivate : MonoBehaviour

{
    public GameObject objectToActivate; // Objekt, das aktiviert werden soll
    public Camera vrCamera;             // VR-Kamera
    public float activationAngle = 30f; // Aktivierungswinkel (in Grad)
    public float activationDistance = 10f; // Max. Distanz für Aktivierung

    // Ein Tag zur Identifikation des Zielobjekts
    public string targetTag = "ActivateTarget";
    void Start()
    {
        objectToActivate.SetActive(false);
    }
    void Update()
    {
        // Sende einen Raycast aus der Position der VR-Kamera geradeaus
        Ray ray = new Ray(vrCamera.transform.position, vrCamera.transform.forward);
        RaycastHit hit;


        // Überprüfe, ob der Raycast etwas trifft
        if (Physics.Raycast(ray, out hit, activationDistance))
        {
            // Überprüfe, ob das getroffene Objekt das Zielobjekt ist
            if (hit.transform.CompareTag(targetTag))
            {
                // Überprüfe den Winkel zwischen der Blickrichtung und dem Zielobjekt
                Vector3 directionToTarget = hit.transform.position - vrCamera.transform.position;
                float angle = Vector3.Angle(vrCamera.transform.forward, directionToTarget);

                // Aktiviert das Objekt, wenn der Blickwinkel innerhalb des Aktivierungswinkels liegt
                if (angle < activationAngle)
                {
                    objectToActivate.SetActive(true);               
                }
            }
        }
    }
}