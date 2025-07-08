using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandControllervonMir : MonoBehaviour
{
    public InputActionReference gripInput;
    public InputActionReference triggerInput;
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    
        void Update()
    {
        if (!animator)return;
        float grip= gripInput.action.ReadValue<float>();   
        float trigger= triggerInput.action.ReadValue<float>();   
        animator.SetFloat("Grip", grip);
        animator.SetFloat("Trigger", trigger);
        /*
        // Überprüfe die Werte der Animator-Parameter
        float animatorGrip = animator.GetFloat("Grip");
        float animatorTrigger = animator.GetFloat("Trigger");
        
        // Gebe die Werte der Animator-Parameter in der Konsole aus
        Debug.Log($"Animator Grip Value: {animatorGrip}");
        Debug.Log($"Animator Trigger Value: {animatorTrigger}");  */ //Brauch ich nicht mehr, will ich aber auch nicht Löschen
    }
}
