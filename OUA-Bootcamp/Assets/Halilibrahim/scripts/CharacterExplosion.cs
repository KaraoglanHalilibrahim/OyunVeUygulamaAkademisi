using UnityEngine;

public class CharacterExplosion : MonoBehaviour
{
    public Animator animator; // Karakterin animat�r bile�eni
    public GameObject bodyPartPrefab; // Par�a nesnesi prefab'i
    public int numBodyParts = 10; // Olu�turulacak par�a nesnelerinin say�s�
    public float explosionForce = 10f; // Patlama kuvveti
    public float explosionRadius = 5f; // Patlama yar��ap�

    private bool isDead = false; // �l�m durumu kontrol�

    public void Update()
    {
        // �l�m animasyonunun oynat�ld��� durumu kontrol et
        if (animator.GetBool("death") && !isDead)
        {
            isDead = true;
            Explode();
        }
    }

    private void Explode()
    {
        // Karakterin boyutunu k���lt
        transform.localScale = Vector3.one * 0.1f;

        // Par�a nesnelerini olu�tur ve patlama kuvveti uygula
        for (int i = 0; i < numBodyParts; i++)
        {
            GameObject bodyPart = Instantiate(bodyPartPrefab, transform.position, Quaternion.identity);
            Rigidbody rb = bodyPart.GetComponent<Rigidbody>();
            if (rb == null)
            {
                rb = bodyPart.AddComponent<Rigidbody>(); // Rigid body bile�eni ekle
            }

            // Rastgele bir patlama kuvveti uygula
            Vector3 randomForce = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
            rb.AddForce(randomForce * explosionForce, ForceMode.Impulse);
        }

        // Karakteri yok et
        Destroy(gameObject);
    }
}
