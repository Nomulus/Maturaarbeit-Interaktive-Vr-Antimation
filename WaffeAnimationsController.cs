using UnityEngine;

public class Karabiner98KAnimationsController : MonoBehaviour
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
    private Karabiner98kschiesstV2 karabiner98kschiesstV2;

    void Start()
    {
        karabiner98kschiesstV2 = GetComponent<Karabiner98kschiesstV2>();
    }

    // Spielt die volle 5-Schuss-Nachladeanimation ab.
    public void OnReload5Schüsse()
    {
        Karabiner98KAnimator.SetTrigger("Reload 5 Schuss");
        Karabiner98KAudio.clip = Reload5SchussAudio;
        Karabiner98KAudio.Play();
        karabiner98kschiesstV2.SetCanShootFalse(); // Schiessen während Animation deaktivieren.
    }

    // Spielt die einzelne Nachladeanimation ab.
    public void OnReload()
    {
        Karabiner98KAnimator.SetTrigger("Reload");
        Karabiner98KAudio.clip = ReloadAudio;
        Karabiner98KAudio.Play();
        karabiner98kschiesstV2.SetCanShootFalse();
    }
    
    // Wird am Ende der Nachladeanimation aufgerufen.
    public void ReloadFertig()
    {
        if (karabiner98kschiesstV2 != null)
        {
            karabiner98kschiesstV2.ReloadFertig();
            canReload = true;
        }
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