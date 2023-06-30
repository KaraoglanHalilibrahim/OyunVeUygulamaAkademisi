using UnityEngine;

public class BoyScaret : MonoBehaviour
{
    public string belirliKarakterTag;
    public Animator animat�r;
    public string booleanAd�;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(belirliKarakterTag))
        {
            animat�r.SetBool(booleanAd�, true);
        }
    }
}
