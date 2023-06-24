using UnityEngine;
using TMPro;

public class DeadEnemy : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public Animator animator;
    public string parameterName;

    void Update()
    {
        // Animator'daki parametrenin de�erini al
        int value = animator.GetInteger(parameterName);

        // TextMeshPro bile�enine de�eri aktar
        textMeshPro.text = value.ToString();
    }
}
