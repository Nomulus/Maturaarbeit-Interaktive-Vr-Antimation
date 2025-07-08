using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    // UI-Slider für die Lautstärke.
    [SerializeField] Slider volumeSlider;

    void Start()
    {
        // Lädt gespeicherte Lautstärke oder setzt einen Standardwert.
        if (!PlayerPrefs.HasKey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
        }
        Load();
    }

    // Ändert die globale Lautstärke.
    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    // Lädt die Einstellung und wendet sie auf den Slider an.
    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    // Speichert die aktuelle Einstellung.
    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
    }
}