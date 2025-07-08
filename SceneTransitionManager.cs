using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    // Startet den Szenenwechsel.
    public void GoToScene(int sceneIndex)
    {
        StartCoroutine(GoToSceneRoutine(sceneIndex));
    }

    // Lädt die Szene asynchron im Hintergrund.
    IEnumerator GoToSceneRoutine(int sceneIndex)
    {
        yield return new WaitForSeconds(2.0f);

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        operation.allowSceneActivation = false;

        yield return new WaitForSeconds(4.0f);
        
        // Aktiviert die fertig geladene Szene.
        operation.allowSceneActivation = true;
    }
}