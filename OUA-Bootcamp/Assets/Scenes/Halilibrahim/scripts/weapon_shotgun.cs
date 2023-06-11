using UnityEngine;
using UnityEngine.UI;

public class weapon_shotgun : MonoBehaviour
{
    private int ammo = 10;
    private bool reload;
    private bool shoot;
    private bool canShoot = true; // Fareye tekrar bas�labilmesini kontrol etmek i�in bir de�i�ken
    private bool canReload = true; // Reload i�lemi i�in bekleme kontrol�
    private float shootCooldown = 1.5f; // Tekrar ate� edebilmek i�in ge�mesi gereken zaman
    private float reloadCooldown = 4f; // Reload i�lemi i�in ge�mesi gereken zaman
    private float disableShootTime = 5f; // R tu�una bas�ld���nda sol fare d��mesine basman�n engellenece�i s�re
    private Animator animator;
    public Text ammoText; // Ammo de�erini g�sterecek olan UI Text nesnesi

    private static readonly int ReloadHash = Animator.StringToHash("reload");

    private void Start()
    {
        animator = GetComponent<Animator>();
        UpdateAmmoText(); // Ammo de�erini ba�lang��ta g�ncelle
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && canShoot)
        {
            if (ammo > 0)
            {
                shoot = true;
                ammo--;
                canShoot = false; // Ate� edildi�inde tekrar at�� yapabilmek i�in bekleme ba�lar
                Invoke("ResetShoot", shootCooldown); // ShootCooldown s�resi sonunda ResetShoot metodu �a�r�l�r
            }
            else
            {
                reload = true;
            }
        }
        else if (Input.GetKeyDown(KeyCode.R) && ammo < 10 && canReload)
        {
            reload = true;
            canShoot = false; // R tu�una bas�ld���nda sol fare d��mesine basman�n engellenmesi i�in canShoot'u false yapar
            Invoke("ResetReload", reloadCooldown); // ReloadCooldown s�resi sonunda ResetReload metodu �a�r�l�r
            Invoke("EnableShoot", disableShootTime); // disableShootTime s�resi sonunda EnableShoot metodu �a�r�l�r
        }
        else
        {
            shoot = false;
            reload = false;
        }

        animator.SetBool("shoot?", shoot);
        animator.SetBool(ReloadHash, reload);

        if (reload)
        {
            ammo = 10;
            reload = false;
            canShoot = false; // Reload i�lemi ba�lad���nda tekrar at�� yapabilmek i�in bekleme ba�lar
            Invoke("ResetShoot", reloadCooldown); // ReloadCooldown s�resi sonunda ResetShoot metodu �a�r�l�r
        }

        UpdateAmmoText(); // Ammo de�erini g�ncelle
    }

    private void ResetShoot()
    {
        canShoot = true; // Bekleme s�resi bitti�inde tekrar at�� yap�labilir hale gelir
    }

    private void ResetReload()
    {
        canReload = true; // Reload i�lemi tamamland���nda tekrar R tu�una bas�labilmesi i�in canReload'u true yapar
    }

    private void EnableShoot()
    {
        canShoot = true; // R tu�una bas�ld�ktan sonra sol fare d��mesine bas�labilmesi i�in canShoot'u true yapar
    }

    private void UpdateAmmoText()
    {
        ammoText.text = "Ammo: " + ammo.ToString(); // Ammo de�erini UI Text nesnesine aktar
    }
}
