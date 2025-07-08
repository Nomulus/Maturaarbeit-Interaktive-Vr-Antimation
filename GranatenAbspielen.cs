using UnityEngine;

    public class GranatenAbspielen : MonoBehaviour
    {
        // Referenz auf das Objekt, das aktiviert werden soll
        public GameObject AudioSprechen;
        public GameObject Granate1;
        public GameObject Granate2;
        public GameObject Mensch;
        public GameObject Cube;
        public GameObject fog;
        public GameObject GranateInHand;
        public GameObject Zündschlüsselhin;
        public GameObject Zündschlüsselweg;
        public GameObject GranatenHalter;
        public AudioSource ZündschlüsselSound;


        // Diese Methoden werden durch die Animation-Events aufgerufen
        public void Sprechenbeginnen()
        {
            if (AudioSprechen != null)
            {
                AudioSprechen.SetActive(true);
            }
            else
            {
                Debug.LogWarning("No Audio to speak assigned to activate.");
            }
        }
        public void ActivatGranate1()
        {
            if (Granate1 != null)
            {
                Granate1.SetActive(true);
            }
            else
            {
                Debug.LogWarning("No Granate1 assigned to activate.");
            }
        }
        public void DeactivatGranate1()
        {
            if (Granate1 != null)
            {
                Granate1.SetActive(false);
            }
            else
            {
                Debug.LogWarning("No Granate1 assigned to deactivate.");
            }
        }
        public void ActivatGranate2()
        {
            if (Granate2 != null)
            {
                Granate2.SetActive(true);
            }
            else
            {
                Debug.LogWarning("No Granate2 assigned to activate.");
            }
        }
        public void Activatefog()
        {
            if (fog != null)
            {
                fog.SetActive(true);
            }
            else
            {
                Debug.LogWarning("No fog assigned to activate.");
            }
        }
        public void DeactivateCube()
        {
            if (Cube != null)
            {
                Cube.SetActive(false);
            }
            else
            {
                Debug.LogWarning("no Cube assigned to activate.");
            }
        }
        public void Deactivatefog()
        {
            if (fog != null)
            {
                fog.SetActive(false);
            }
            else
            {
                Debug.LogWarning("No fog assigned to deactivate.");
            }
        }
        public void DeactivatGranate2()
        {
            if (Granate2 != null)
            {
                Granate2.SetActive(false);
            }
            else
            {
                Debug.LogWarning("No Granate2 assigned to deactivate.");
            }
        }
        public void DeaktiviereAnimation()
        {
            if (Mensch != null)
            {
                Mensch.SetActive(false);
                Cube.SetActive(false);
                fog.SetActive(false);
            }
            else
            {
                Debug.LogWarning("No Mensch assigned to deactivate.");
            }
        }
        public void versteckeGranate()
        {
            if (GranateInHand != null)
            {
                MeshRenderer meshRenderer = GranateInHand.GetComponent<MeshRenderer>();  //Der Komponent Mesh Renderer wird abgerufen und dannach Deaktiviert
                if (meshRenderer != null)
                {
                    meshRenderer.enabled = false;
                }
                else
                {
                    Debug.LogWarning("MeshRenderer component not found on " + GranateInHand.name);
                }
            }
            else
            {
                Debug.LogWarning("GranateInHand is not assigned in the inspector.");
            }
        }

        public void zeigeGranate()
        {
            if (GranateInHand != null)
            {
                MeshRenderer meshRenderer = GranateInHand.GetComponent<MeshRenderer>();  //Der Komponent Mesh Renderer wird abgerufen und dannach Deaktiviert
                if (meshRenderer != null)
                {
                    meshRenderer.enabled = true;
                }
                else
                {
                    Debug.LogWarning("MeshRenderer component not found on " + GranateInHand.name);
                }
            }
            else
            {
                Debug.LogWarning("GranateInHand is not assigned in the inspector.");
            }
        }
        public void aktiviereZündschlüsselhin()
        {
            if (Zündschlüsselhin != null)
            {
                Zündschlüsselhin.SetActive(true);
            }
            else
            {
                Debug.LogWarning("No Zündschlüsselhin assigned to activate.");
            }
        }
        public void versteckeZündschlüssel()
        {
            if (GranateInHand != null)
            {
                MeshRenderer meshRenderer = Zündschlüsselweg.GetComponent<MeshRenderer>();  //Der Komponent Mesh Renderer wird abgerufen und dannach Deaktiviert
                if (meshRenderer != null)
                {
                    meshRenderer.enabled = false;
                }
                else
                {
                    Debug.LogWarning("MeshRenderer component not found on " + Zündschlüsselweg.name);
                }
            }
            else
            {
                Debug.LogWarning("GranateInHand is not assigned in the inspector.");
            }
        }
        public void versteckeHalter()
        {
            if (GranateInHand != null)
            {
                MeshRenderer meshRenderer = GranatenHalter.GetComponent<MeshRenderer>();  //Der Komponent Mesh Renderer wird abgerufen und dannach Deaktiviert
                if (meshRenderer != null)
                {
                    meshRenderer.enabled = false;
                }
                else
                {
                    Debug.LogWarning("MeshRenderer component not found on " + GranatenHalter.name);
                }
            }
            else
            {
                Debug.LogWarning("GranateInHand is not assigned in the inspector.");
            }
        }
        public void Zündschlüsselhören()
        {
            ZündschlüsselSound.PlayOneShot(ZündschlüsselSound.clip);
        }
    }