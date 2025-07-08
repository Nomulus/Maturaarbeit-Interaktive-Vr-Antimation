using UnityEngine;

public class VolumeSchliessen : MonoBehaviour
{
    public GameObject Camvas;

    //wird durch das klicken des X auf Kamvas ausgesöst
    public void Schliessen()
    {
        Camvas.SetActive(false);
    }
}