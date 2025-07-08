using UnityEngine;

public class Karabiner98KAnimationsControllerNPCs : MonoBehaviour
{
    public Animator Karabiner98KAnimator;
    public AudioSource Karabiner98KAudio;
    public AudioSource ZuenderAudio;
    public AudioClip SchussAudio;
    public AudioClip ReloadAudio;
    public AudioClip Reload5SchussAudio;
    public AudioClip ZuenderZiehenAudio;

    public bool canReload = true;
    private int reloadCount = 0;

    // Löst das Nachladen aus.
    public void Reload()
    {
        if (canReload)
        {
            canReload = false;
            reloadCount++;

            if ((reloadCount - 1) % 5 == 0)
            {
                OnReload5Schüsse();
            }
            else
            {
                OnReload();
            }
        }
    }
    
    // Wird per Animations-Event aufgerufen.
    public void ReloadFertig()
    {
        canReload = true;
    }

    public void OnReload5Schüsse()
    {
        Karabiner98KAnimator.SetTrigger("Reload 5 Schuss");
        Karabiner98KAudio.clip = Reload5SchussAudio;
        Karabiner98KAudio.Play();
    }

    public void OnReload()
    {
        Karabiner98KAnimator.SetTrigger("Reload");
        Karabiner98KAudio.clip = ReloadAudio;
        Karabiner98KAudio.Play();
    }

    public void SchussSound()
    {
        Karabiner98KAudio.clip = SchussAudio;
        Karabiner98KAudio.Play();
    }
    
    public void PlayZuenderSound()
    {
        ZuenderAudio.clip = ZuenderZiehenAudio;
        ZuenderAudio.Play();
    }

    public void PlayZuenderAnimation()
    {
        Karabiner98KAnimator.SetTrigger("ZuenderZiehen");
    }
}