using UnityEngine;

public class EnemyActiveStatus : MonoBehaviour
{
    public GameObject enemyObject; // Aktiflik durumu de�i�tirilecek d��man nesnesi
    public float deactivationTime = 3f; // Deaktivasyon s�resi (saniye)

    private void Start()
    {
        DeactivateEnemy();
    }

    private void DeactivateEnemy()
    {
        enemyObject.SetActive(false);
        Invoke("ActivateEnemy", deactivationTime);
    }

    private void ActivateEnemy()
    {
        enemyObject.SetActive(true);
    }
}
