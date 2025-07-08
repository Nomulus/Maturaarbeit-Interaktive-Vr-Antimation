using UnityEngine;

public class ExitApplication : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RightHand"))
        {
#if UNITY_EDITOR
            // Wenn im Editor, stoppe das Spiel
            UnityEditor.EditorApplication.isPlaying = false;
#else
            // Wenn im Build, beende die Anwendung
            Application.Quit();
#endif
        }
        else
        {
            Debug.Log("Trigger entered by: " + other.gameObject.name);
        }
    }
}