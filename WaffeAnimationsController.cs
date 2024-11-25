using UnityEngine;

public class WaffeAnimationsController : MonoBehaviour
{
    public Animator Karabiner98KAnimator;

    // Ich benutze AnimationEvents um die Animationen sowie Sounds zu starten
    public void OnReload5Shots()
    {
        Debug.Log("Reload 5 Schuss");
        Karabiner98KAnimator.SetTrigger("Reload 5 Schuss");
    }

    // Diese Funktion wird vom Animation Event aufgerufen
    public void OnReload()
    {
        Debug.Log("Reload");
        Karabiner98KAnimator.SetTrigger("Reload");
    }
}