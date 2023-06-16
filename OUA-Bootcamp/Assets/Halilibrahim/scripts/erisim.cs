using UnityEngine;

public class Erisim : MonoBehaviour
{
    private GameObject enemy;
    private enemy_death enemyDeathScript;

    private void Start()
    {
        // Enemy01 objesini buluyoruz
        enemy = GameObject.FindWithTag("Enemy");

        if (enemy != null)
        {
            // enemy_death scriptine eri�iyoruz
            enemyDeathScript = enemy.GetComponentInChildren<enemy_death>();

            if (enemyDeathScript != null)
            {
                // health de�i�kenini kullanabilirsiniz
                int health = enemyDeathScript.health;

                // health de�i�kenini kullanarak bir �eyler yapabilirsiniz
                Debug.Log("Enemy01'in ba�lang�� sa�l���: " + health);
            }
            else
            {
                Debug.Log("Enemy01 objesinde EnemyDeath scripti bulunamad�.");
            }
        }
        else
        {
            Debug.Log("Enemy01 objesi bulunamad�.");
        }
    }

    private void Update()
    {
        // Update() fonksiyonu her frame'de �a�r�l�r
        if (enemyDeathScript != null)
        {
            // health de�i�kenini s�rekli olarak g�ncelleyebilirsiniz
            int health = enemyDeathScript.health;

            // health de�i�kenini kullanarak bir �eyler yapabilirsiniz
            Debug.Log("Enemy01'in g�ncel sa�l���: " + health);
        }
    }
}
