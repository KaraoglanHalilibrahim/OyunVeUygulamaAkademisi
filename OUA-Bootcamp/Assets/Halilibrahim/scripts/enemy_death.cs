using UnityEngine;

public class enemy_death : MonoBehaviour
{
    public Animator animator; // Animator bile�eni referans�
    public CapsuleCollider capsuleCollider; // CapsuleCollider bile�eni referans�
    private bool isDead = false; // �l�m durumu
    private int hit = 0; // Hit de�eri
    private int health = 100; // Sa�l�k de�eri
    private bool isFrozen = false; // Hareketin durma durumu
    private float freezeDuration = 1f; // Hareketin durma s�resi
    private float freezeTimer = 0f; // Hareketin durma s�resi i�in zamanlay�c�

    private void Start()
    {
    }

    private void Update()
    {
        if (isFrozen)
        {
            // Hareketi durdurma s�resini kontrol et
            freezeTimer += Time.deltaTime;
            if (freezeTimer >= freezeDuration)
            {
                isFrozen = false;
                freezeTimer = 0f;

                // Hareketin tekrar ba�lamas�n� sa�la
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet")) // �arp��an obje "Bullet" tag'ine sahipse
        {
            animator.SetBool("death", isDead); // Animator'deki "death" parametresine �l�m durumunu atar

            // Rastgele hit de�eri
            hit = Random.Range(1, 3);
            animator.SetInteger("hit", hit);

            // Sa�l�k de�erinden rastgele d����
            int damage = Random.Range(40, 51);
            health -= damage;

            if (health <= 0)
            {
                health = 0;
                isDead = true;
            }

          
            // Hit de�erini s�f�rlama
            hit = 0;
            Invoke(nameof(ResetHit), 1f);
        }
    }

    private void ResetHit()
    {
        animator.SetInteger("hit", 0);
    }
}
