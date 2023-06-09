using UnityEngine;

public class TeleportScript : MonoBehaviour
{
    public GameObject teleportTarget; // Işınlanma hedefi olarak belirleyeceğimiz obje
    public GameObject targetObject; // Işınlanacak objeyi belirleyeceğimiz obje

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == targetObject)
        {
            // Işınlanma işlemi
            targetObject.transform.position = teleportTarget.transform.position;
        }
    }
}
