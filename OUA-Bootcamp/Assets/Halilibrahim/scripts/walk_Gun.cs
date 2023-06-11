using UnityEngine;

public class walk_Gun : MonoBehaviour
{
    private Animator animator;
    private bool walk = false;

    private void Start()
    {
        // Karakterinizdeki Animator bile�enini al�n
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // WASD tu�lar�n�n kullan�m�n� kontrol et
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            // Y�r�me boolean'�n� true yap
            walk = true;
        }
        else
        {
            // Y�r�me boolean'�n� false yap
            walk = false;
        }

        // Animator'deki "walk" parametresini "walk" boolean'�na e�itle
        animator.SetBool("walk", walk);
    }
}
