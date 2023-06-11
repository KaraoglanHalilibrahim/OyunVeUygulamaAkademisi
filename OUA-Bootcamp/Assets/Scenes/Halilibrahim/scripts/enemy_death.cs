using UnityEngine;

public class enemy_death : MonoBehaviour
{
    public Animator animator; // Animator bile�eni referans�
    public bool death = false; // �l�m durumu

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet")) // �arp��ma objesi "Bullet" tag'ine sahipse
        {
            death = true; // �l�m durumunu true yap
            animator.SetBool("death", death); // Animator'deki "death" parametresine �l�m durumunu atar
        }
    }
}
