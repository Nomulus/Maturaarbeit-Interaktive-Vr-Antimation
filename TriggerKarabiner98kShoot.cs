using System.Collections;
using UnityEngine;

public class TriggerKarabiner98kShoot : MonoBehaviour
{
    public float delay = 16f;
    public Transform targetPoint;

    private AimAtTargetBeforeShoot takeAim;
    private Karabiner98kschiesstfürNPCs karabinerScript;

    void Start()
    {
        takeAim = GetComponent<AimAtTargetBeforeShoot>();
        karabinerScript = GetComponent<Karabiner98kschiesstfürNPCs>();

        // Startet die Schuss-Sequenz.
        StartCoroutine(TriggerShootAfterDelay(delay));
    }

    // Coroutine für den Ablauf: Warten, Zielen, Schiessen.
    private IEnumerator TriggerShootAfterDelay(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        
        takeAim.AimAtTarget();
        
        if (karabinerScript != null)
        {
            karabinerScript.ShootAtTarget(targetPoint.position, 0f);
        }
    }
}