using UnityEngine;

public class PunchColliderRight : MonoBehaviour
{
    public GameObject PunchColliderLeftObject;
    private Animator animator;
    private bool isColliderActive;

    private void Start()
    {
        // Ba�lang��ta objeyi deaktif hale getir
        PunchColliderLeftObject.SetActive(false);
        animator = GetComponent<Animator>();
        isColliderActive = false;
    }

    private void Update()
    {
        // Animat�rdeki RightPunch de�eri true ise
        if (animator.GetBool("RightPunch"))
        {
            // PunchColliderLeft objesini aktif hale getir ve zamanlay�c�y� ba�lat
            if (!isColliderActive)
            {
                PunchColliderLeftObject.SetActive(true);
                isColliderActive = true;
                Invoke("DeactivateCollider", 0.1f);
            }
        }
        else
        {
            // PunchColliderLeft objesini deaktif hale getir
            PunchColliderLeftObject.SetActive(false);
            isColliderActive = false;
        }
    }

    private void DeactivateCollider()
    {
        // PunchColliderLeft objesini deaktif hale getir
        PunchColliderLeftObject.SetActive(false);
        isColliderActive = false;
    }
}
