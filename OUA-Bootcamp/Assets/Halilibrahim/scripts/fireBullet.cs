using UnityEngine;

public class fireBullet : MonoBehaviour
{
    public GameObject mermiPrefab; // Kur�un objesinin prefab'�
    public Transform nisangahNoktasi; // Nisangah noktas�n�n Transform bile�eni

    public float atisGucu = 10000f; // Kur�un at�� g�c� (N)
    public float atisHizi = 1000f; // Kur�un at�� h�z� (m/s)

    private int ammo = 10; // Ammo miktar� ve ba�lang�� de�eri
    private bool atisYapilabilir = true; // At�� yap�labilir durumu kontrol etmek i�in
    private float zamanSuresi = 1f; // At��lar aras�ndaki zaman s�n�r�

    private float sonAtisZamani; // Son at���n yap�ld��� zaman

    void Start()
    {
        sonAtisZamani = -zamanSuresi; // Oyun ba�lang�c�nda son at�� zaman�n� s�f�rla
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && atisYapilabilir && ammo > 0 && Time.time > sonAtisZamani + zamanSuresi) // Sol fare tu�una bas�ld���nda, at�� yap�labilir durumdaysa, ammo miktar� 0'dan b�y�kse ve zaman s�n�r� ge�ilmi�se at�� yap
        {
            AtisYap();
            ammo--; // Ammo miktar�n� 1 azalt
            sonAtisZamani = Time.time; // Son at�� zaman�n� g�ncelle

            if (ammo == 0)
            {
                atisYapilabilir = false; // Ammo miktar� 0 oldu�unda at�� yap�labilir durumu false yap
            }
        }
    }

    void AtisYap()
    {
        // Mermi objesini olu�tur ve nisangah noktas�na yerle�tir
        GameObject mermi = Instantiate(mermiPrefab, nisangahNoktasi.position, nisangahNoktasi.rotation);

        // Kur�una h�z uygula
        mermi.GetComponent<Rigidbody>().velocity = nisangahNoktasi.forward * atisHizi;

        // Kur�una bir kuvvet uygula (opsiyonel)
        mermi.GetComponent<Rigidbody>().AddForce(nisangahNoktasi.forward * atisGucu);
    }
}
