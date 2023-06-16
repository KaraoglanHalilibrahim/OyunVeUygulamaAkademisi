using UnityEngine;

public class ParkurOlu�turucu : MonoBehaviour
{
    public GameObject k�pPrefab; // Kullanaca��m�z k�p prefab�
    public GameObject platformPrefab; // Kullanaca��m�z platform prefab�

    public int k�pSay�s� = 10; // Olu�turulacak k�p say�s�
    public float aral�kMesafesi = 2f; // K�pler ve platformlar aras�ndaki mesafe
    public Vector3 k�pBoyutlar� = new Vector3(1f, 1f, 1f); // K�p boyutlar�
    public float y�kseklikAral��� = 1.5f; // K�plerin rastgele y�kseklik aral���

    private void Start()
    {
        ParkurOlu�tur();
    }

    void ParkurOlu�tur()
    {
        Vector3 spawnPozisyonu = transform.position; // Ba�lang�� noktas�

        for (int i = 0; i < k�pSay�s�; i++)
        {
            if (i % 4 == 0) // Her 4. eleman� platform olarak yerle�tir
            {
                GameObject yeniPlatform = Instantiate(platformPrefab, spawnPozisyonu, Quaternion.identity); // Yeni platform olu�tur

                // Platform boyutlar�n� ayarla
                yeniPlatform.transform.localScale = new Vector3(aral�kMesafesi, k�pBoyutlar�.y, aral�kMesafesi);

                // Platformu yere yerle�tir
                yeniPlatform.transform.position = new Vector3(spawnPozisyonu.x, k�pBoyutlar�.y / 2f, spawnPozisyonu.z);
            }
            else
            {
                GameObject yeniK�p = Instantiate(k�pPrefab, spawnPozisyonu, Quaternion.identity); // Yeni k�p olu�tur

                // K�p boyutlar�n� ayarla
                yeniK�p.transform.localScale = k�pBoyutlar�;

                // K�p� yere yerle�tir
                yeniK�p.transform.position = new Vector3(spawnPozisyonu.x, k�pBoyutlar�.y / 2f, spawnPozisyonu.z);

                // Rastgele y�kseklik de�eri uygula
                float rastgeleY�kseklik = Random.Range(0f, y�kseklikAral���);
                yeniK�p.transform.position += new Vector3(0f, rastgeleY�kseklik, 0f);
            }

            spawnPozisyonu.x += aral�kMesafesi; // K�pleri ve platformlar� yatayda birbirinden ay�r
        }
    }
}
