using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Karabiner98kschiesst : MonoBehaviour
{
    public GameObject projectilePrefab; // Das Projektil-Prefab
    public Transform shootPoint; // Der Startpunkt an der Waffe
    public float shootForce = 50f; // Die Kraft, mit der das Projektil geschossen wird
    public float knockbackForce = 10f; // Die Kraft des Rückstoßes
    public LayerMask layerMask; // LayerMask für das Raycast
    public ParticleSystem Rauch;
    public float distance = 200f;
    public Animator Karabiner98KAnimator;
    public string AbzugTrigger = "Abzug Ziehen";
    public string AbzugZiehenWhileReload = "Abzug Ziehen While Reload";
    public GameObject SchussEinschlag;

    private bool rayActivate = false;
    private bool canShoot = true; // Variable, die angibt, ob geschossen werden kann // am Anfang auf false.
    private Karabiner98KAnimationsController animationsController;
    private Rigidbody rb; // Rigidbody für die Waffe
    private Vector3 knockbackDirection;
    private bool applyKnockback = false;

    void Start()
    {
        Karabiner98KAnimator = GetComponent<Animator>();
        animationsController = GetComponent<Karabiner98KAnimationsController>();
        rb = GetComponent<Rigidbody>();

        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
        if (grabInteractable != null)
        {
            grabInteractable.activated.AddListener(x => TryShoot());
        }

        if (Karabiner98KAnimator == null)
        {
            Debug.LogError("Karabiner98KAnimator nicht gefunden");
        }

        if (rb == null)
        {
            Debug.LogError("Rigidbody nicht gefunden");
        }

        if (animationsController == null)
        {
            Debug.LogError("Karabiner98KAnimationsController nicht gefunden");
        }
    }

    void TryShoot()
    {
        Debug.Log("TryShoot called");
        animationsController.PlayZuenderSound();
        if (canShoot)
        {
            Debug.Log("Can shoot, setting trigger");
            Karabiner98KAnimator.SetTrigger(AbzugTrigger);
        }
        else
        {
            Debug.Log("Cannot shoot, setting reload trigger");
            Karabiner98KAnimator.SetTrigger(AbzugZiehenWhileReload);
        }
    }

    public void Shoot()
    {
        Debug.Log("Shoot called");
        animationsController.SchussSound();
        Rauch.Play();
        ApplyKnockback(); // Rückstoß anwenden
        rayActivate = true;
        canShoot = false; // Schießen sperren, bis ReloadFertig() aufgerufen wird

        // Erstelle ein Projektil und wende eine Kraft an
        GameObject projectileInstance = Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);
        Rigidbody rbProjectile = projectileInstance.GetComponent<Rigidbody>();

        if (rbProjectile != null)
        {
            rbProjectile.AddForce(shootPoint.forward * shootForce);
        }
    }

    void Update()
    {
        if (rayActivate)

        {
            RaycastCheck();
            rayActivate = false; // rayActivate zurücksetzen, damit RaycastCheck nur einmal pro Schuss aufgerufen wird
        }

        if (applyKnockback)
        {
            // Manuelle Anwendung des Rückstoßes
            transform.position += knockbackDirection * Time.deltaTime;
            applyKnockback = false; // Rückstoß nur einmal pro Schuss anwenden
        }
    }

    void RaycastCheck()
    {
        if (shootPoint != null)
        {
            Ray ray = new Ray(shootPoint.position, shootPoint.forward);
            RaycastHit hit;

            Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);

            if (Physics.Raycast(ray, out hit, 100, layerMask))
            {
                Debug.Log("Raycast hat etwas getroffen: " + hit.transform.name);
                hit.transform.gameObject.SendMessage("Getroffen", SendMessageOptions.DontRequireReceiver);

                Vector3 hitPoint = hit.point;
                Vector3 hitNormal = hit.normal;
                Quaternion terrainRotation = Quaternion.FromToRotation(Vector3.up, hitNormal);

                Vector3 rayDirection = new Vector3(ray.direction.x, 0, ray.direction.z).normalized;
                Quaternion combinedRotation = Quaternion.LookRotation(rayDirection) * terrainRotation;
                
                // Instantiate the SchussEinschlag GameObject
                GameObject hitEffect = Instantiate(SchussEinschlag, hitPoint, combinedRotation);

                // Get the AktiviereEinschlag component and call SchussAbpielen method
                AktiviereEinschlag einschlagScript = hitEffect.GetComponent<AktiviereEinschlag>();
                if (einschlagScript != null)
                            {
                einschlagScript.SchussAbpielen();
                }
                else
                {   
                    Debug.LogWarning("AktiviereEinschlag component not found on SchussEinschlag object.");
                }
            }
            else
            {
                Debug.Log("Raycast hat nichts getroffen.");
            }
        }
        else
        {
            Debug.LogWarning("ShootPoint is not assigned.");
        }
    }

    public void ReloadFertig()
    {
        Debug.Log("ReloadFertig called, canShoot set to true");
        canShoot = true; // Schießen wieder erlauben
    }

    public void ApplyKnockback()
    {
        if (rb != null)
        {
            knockbackDirection = -shootPoint.forward * knockbackForce;
            applyKnockback = true;
        }
        Karabiner98KAnimator.SetTrigger(AbzugTrigger);
    }
}
