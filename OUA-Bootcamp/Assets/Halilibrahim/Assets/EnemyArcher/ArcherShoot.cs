using System.Collections;
using UnityEngine;

public class ArcherShoot : MonoBehaviour
{
    public GameObject arrowPrefab; // Ok prefab'�
    public Transform arrowSpawnPoint; // Okun ��kaca�� nokta
    public float initialDelay = 2f; // �lk at�� i�in ge�mesi gereken s�re (saniye)
    public float shootInterval = 1.5f; // Ard���k at��lar aras�ndaki zaman fark� (saniye)
    public float force = 1000f; // Okun h�z ve g�c�

    private bool canShoot = true;
    public Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(ShootRoutine());
    }

    private IEnumerator ShootRoutine()
    {
        
            yield return new WaitForSeconds(initialDelay);


        while (true)
        {
            if (canShoot && animator.GetBool("attack"))
            {
                Shoot();
                canShoot = false;
                yield return new WaitForSeconds(shootInterval);
                canShoot = true;
            }
            yield return null;
        }
    }

    private void Shoot()
    {
        
        
             // Ok objesini olu�tur
              GameObject arrow = Instantiate(arrowPrefab, arrowSpawnPoint.position, arrowSpawnPoint.rotation);

             // Oku hareket ettirme veya di�er ayarlar� yapma kodlar� eklenebilir

             // �rne�in, Rigidbody bile�eni varsa hareket ettirelim
             Rigidbody arrowRigidbody = arrow.GetComponent<Rigidbody>();
             if (arrowRigidbody != null)
             {
                 arrowRigidbody.AddForce(arrowSpawnPoint.forward * force);
             }
        
            
    }
}
