using UnityEngine;

public class enemy_death : MonoBehaviour
{
    public Animator animator; // Animator bile�eni referans�
    public CapsuleCollider capsuleCollider; // CapsuleCollider bile�eni referans�
    private bool isDead = false; // �l�m durumu

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet")) // �arp��an obje "Bullet" tag'ine sahipse
        {
            isDead = true; // �l�m durumunu true yap
            animator.SetBool("death", isDead); // Animator'deki "death" parametresine �l�m durumunu atar
            capsuleCollider.isTrigger = true; // CapsuleCollider'�n isTrigger de�erini true yap
        }
    }
}
