using UnityEngine;

public class TeleportScript : MonoBehaviour
{
    public GameObject teleportTarget; // I��nlanma hedefi olarak belirleyece�imiz obje
    public GameObject targetObject; // I��nlanacak objeyi belirleyece�imiz obje

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == targetObject)
        {
            // I��nlanma i�lemi
            targetObject.transform.position = teleportTarget.transform.position;
        }
    }
}
