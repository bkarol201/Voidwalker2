using UnityEngine;
using UnityEngine.InputSystem; // Wymagane dla nowego Input System w VR
using UnityEngine.XR.Interaction.Toolkit; // Wymagane dla interakcji XR

public class VRBulletFire : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 20f;
    public float bulletLifetime = 5f; // seconds before bullet is destroyed

    public AudioClip clip;
    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();

        // Jeœli zapomnisz dodaæ AudioSource w inspektorze, skrypt doda go sam
        if (source == null)
        {
            source = gameObject.AddComponent<AudioSource>();
        }
    }

    public void FireBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        if (source != null && clip != null)
        {
            source.PlayOneShot(clip);
        }

        if (rb != null)
        {
            // W Unity 6 u¿ywamy linearVelocity zamiast velocity dla wiêkszej precyzji
            rb.linearVelocity = firePoint.forward * bulletSpeed;
        }

        // Zniszcz pocisk po okreœlonym czasie, aby nie zaœmiecaæ pamiêci
        Destroy(bullet, bulletLifetime);
    }
}