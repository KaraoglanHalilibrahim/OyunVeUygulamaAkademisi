using UnityEngine;

public class Punches : MonoBehaviour
{
    public bool LeftPunch;
    public bool RightPunch;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Sol yumruk tu�una bas�l�rsa LeftPunch'� true yap
        if (Input.GetMouseButtonDown(0))
        {
            LeftPunch = true;
            RightPunch = false;
        }

        // Sa� yumruk tu�una bas�l�rsa RightPunch'� true yap
        if (Input.GetMouseButtonDown(1))
        {
            RightPunch = true;
            LeftPunch = false;
        }

        // Animat�rdeki parametreleri g�ncelle
        animator.SetBool("LeftPunch", LeftPunch);
        animator.SetBool("RightPunch", RightPunch);

        // Animasyon tamamland���nda boolean de�erleri s�f�rla
        if (LeftPunch || RightPunch)
        {
            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
            if (stateInfo.IsName("LeftPunch") || stateInfo.IsName("RightPunch"))
            {
                LeftPunch = false;
                RightPunch = false;
            }
        }
    }
}
