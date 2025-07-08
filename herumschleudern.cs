using System.Collections.Generic; 

using UnityEngine; 

using UnityEngine.Animations; 

  
// hab ich nicht Selber geschrieben, verstehe ich auch nicht komplett, habs einfach zu Spass ausprobiert
public class AccelerateRigidbodyWithBias : MonoBehaviour 

{ 

    public float forceAmount = 10f; 

    public float interval = 1f; // Intervall in Sekunden 

    private Rigidbody rb; 

  

    void Start() 

    { 

        // Rigidbody-Komponente abrufen 

        rb = GetComponent<Rigidbody>(); 

  

        // Sicherstellen, dass der Rigidbody gefunden wurde 

        if (rb == null) 

        { 

            Debug.LogError("Rigidbody-Komponente nicht gefunden."); 

            return; 

        } 
        // Überprüfen, ob das Skript aktiviert ist
        if (!this.enabled)
        {
            Debug.LogError("Das Skript ist deaktiviert.");
        }
  

        // Wiederholtes Aufrufen der ApplyRandomForce Methode 

        InvokeRepeating("ApplyRandomForce", 0f, interval); 

    } 

  

    void ApplyRandomForce() 

    { 

        if (transform.position.y <= 30 ) 

        { 

                        // Füge eine Kraft nach oben hinzu 

            rb.AddForce(Vector3.up * forceAmount * 4 , ForceMode.Acceleration); 

  

        } 

        else 

        { 

            // Generiere eine zufällige Richtung 

            Vector3 randomDirection = GetBiasedRandomDirection(); 

  

            // Wende die Kraft in der zufälligen Richtung an 

            rb.AddForce(randomDirection * forceAmount, ForceMode.Acceleration); 

        } 

    } 

  

    Vector3 GetBiasedRandomDirection() 

    { 

        // Generiere einen zufälligen Vektor 

        Vector3 randomDirection = Random.onUnitSphere; 

  

        // Wenn die Richtung nach unten zeigt, invertiere sie mit einer Wahrscheinlichkeit von 2/3 

        if (randomDirection.y < 0) 

        { 

            if (Random.value < 0.5) // 1/2 Wahrscheinlichkeit 

            { 

                randomDirection.y = -randomDirection.y; // Invertiere die y-Komponente, um sie nach oben zu zeigen 

            } 

        } 

  

        // Normiere den Vektor, um sicherzustellen, dass er eine Einheitslänge hat 

        return randomDirection.normalized; 

    } 

} 