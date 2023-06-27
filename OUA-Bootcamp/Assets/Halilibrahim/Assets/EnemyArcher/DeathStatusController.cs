using UnityEngine;

public class DeathStatusController : MonoBehaviour
{
    public Animator animator;
    private bool hasRandomizedStatus = false;

    private void Start()
    {
        // Animator bile�enini al
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // "death" parametresi true oldu�unda ve hen�z rastgele de�er al�nmam��sa
        if (animator.GetBool("death") && !hasRandomizedStatus)
        {
            // "DeathStatu" parametresine rastgele bir de�er ata
            int randomStatus = Random.Range(1, 4);
            animator.SetInteger("DeathStatu", randomStatus);
            hasRandomizedStatus = true;
        }
    }
}
