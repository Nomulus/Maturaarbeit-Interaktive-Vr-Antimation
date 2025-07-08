using UnityEngine;
using UnityEngine.SceneManagement;

public class Szennwechsel : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Lädt die Schlachtfeld Szene.
            SceneManager.LoadScene(1);
        }
    }
}