using UnityEngine;
using UnityEngine.UI;

public class weapon_shotgun : MonoBehaviour
{
    private int ammo = 10;
    private bool shoot;
    private bool canShoot = true;
    private float shootCooldown = 1.0f;
    private Animator animator;
    public Text ammoText;
    public AudioSource audioSource; // AudioSource bile�enini referanslayacak de�i�ken

    private void Start()
    {
        animator = GetComponent<Animator>();
        UpdateAmmoText();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && canShoot)
        {
            if (ammo > 0)
            {
                shoot = true;
                ammo--;
                canShoot = false;
                Invoke("ResetShoot", shootCooldown);
            }
        }
        else
        {
            shoot = false;
        }

        animator.SetBool("shoot?", shoot);

        if (shoot)
        {
            // Sesi �al
            audioSource.Play();
        }

        UpdateAmmoText();
    }

    private void ResetShoot()
    {
        canShoot = true;
    }

    private void UpdateAmmoText()
    {
        ammoText.text = "Ammo: " + ammo.ToString();
    }
}
