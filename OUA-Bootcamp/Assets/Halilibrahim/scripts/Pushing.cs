using UnityEngine;

public class Pushing : MonoBehaviour
{
    public float pushDistance = 3f; // �leriye itme mesafesi

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            PushCharacter();
        }
    }

    private void PushCharacter()
    {
        // Karakterin bulundu�u y�n� al ve ona g�re itme mesafesini uygula
        Vector3 pushDirection = transform.forward;
        Vector3 targetPosition = transform.position + pushDirection * pushDistance;

        // Karakteri hedef pozisyona ta��
        transform.position = targetPosition;
    }
}
