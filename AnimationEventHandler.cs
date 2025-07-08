    using UnityEngine;

    public class AnimationEventHandler : MonoBehaviour
    {
        // Referenz auf das Objekt, das aktiviert werden soll
        public GameObject objectToActivate1;
        public GameObject objectToActivate2;
        public GameObject objectToDetivate;
        public GameObject objectToReactivate;
        

        // Diese Methode wird durch das Animation-Event aufgerufen
        public void ActivateObject1()
        {
            if (objectToActivate1 != null)
            {
                objectToActivate1.SetActive(true);
            }
            else
            {
                Debug.LogWarning("No object1 assigned to activate.");
            }
        }
        public void ActivateObject2()
        {
            if (objectToActivate2 != null)
            {
                objectToActivate2.SetActive(true);
            }
            else
            {
                Debug.LogWarning("No object2 assigned to activate.");
            }
        }
        public void DeactivateObject()
        {
            if (objectToDetivate != null)
            {
                objectToDetivate.SetActive(false);
            }
            else
            {
                Debug.LogWarning("No objectToDeactivate assigned to deactivate.");
            }
        }
        public void ReactivateObject()
        {
            if (objectToReactivate != null)
            {
                objectToReactivate.SetActive(true);
            }
            else
            {
                Debug.LogWarning("No objectToDeactivate assigned to deactivate.");
            }
        }
    }