using UnityEngine;

public class ArcherFocus : MonoBehaviour
{
    public Transform target; // Karakterin bakmas� gereken hedef obje
    public float rotationSpeed = 5f; // D�n�� h�z�

    private void Update()
    {
        if (target != null)
        {
            // Karakterin hedef objeye do�ru d�nmesini sa�la
            Vector3 direction = target.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction);
            rotation.eulerAngles = new Vector3(rotation.eulerAngles.x, rotation.eulerAngles.y, 0f); // Z ekseni (ileri-geri) s�f�rlan�r
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        }
    }
}
