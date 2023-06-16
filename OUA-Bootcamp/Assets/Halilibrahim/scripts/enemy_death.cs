using UnityEngine;

public class enemy_death : MonoBehaviour
{
    public Animator animator; // Animator bile�eni referans�
    public CapsuleCollider capsuleCollider; // CapsuleCollider bile�eni referans�
    public GameObject enemySphere; // EnemySphere objesinin referans�
    private bool isDead = false; // �l�m durumu
    private int hit = 0; // Hit de�eri
    [SerializeField] public int health = 100; // Sa�l�k de�eri
    private bool isFrozen = false; // Hareketin durma durumu
    private float freezeDuration = 0f; // Hareketin durma s�resi
    private float freezeTimer = 0f; // Hareketin durma s�resi i�in zamanlay�c�


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

        if (isDead)
        {
            // �l�m sonras� 3 saniye bekledikten sonra karakteri sahneden sil
            Invoke(nameof(DestroyCharacter), 3f);
        }
    }

    private void DestroyCharacter()
    {
        // Karakteri sahneden sil
        Destroy(gameObject);
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

            if (health <= 0 && !isDead)
            {
                health = 0;
                isDead = true;
                // �l�m durumuna ge�i� i�lemleri burada yap�labilir
                animator.SetBool("death", isDead); // Animator'deki "death" parametresine �l�m durumunu atar

                // EnemySphere objesini devre d��� b�rak
                if (enemySphere != null)
                {
                    enemySphere.SetActive(false);
                }
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Punch"))
        {
            
                animator.SetBool("punching?", true); // Animator'deki "punching?" parametresini true yap
                
                if(animator.GetBool("punching?") == true)
            {
                health -= 7; // punching? true oldu�unda health de�erinden  azalt
                animator.SetBool("punching?", false); // Animator'deki "punching?" parametresini false yap

            }

            if (health <= 0 && !isDead)
            {
                health = 0;
                isDead = true;
                animator.SetBool("death", isDead); // Animator'deki "death" parametresine �l�m durumunu atar
                                                   // �l�m durumuna ge�i� i�lemleri burada yap�labilir
                if (enemySphere != null)
                {
                    enemySphere.SetActive(false);
                }
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Punch"))
        {
            animator.SetBool("punching?", false); // Animator'deki "punching?" parametresini false yap

        }
    }
}
