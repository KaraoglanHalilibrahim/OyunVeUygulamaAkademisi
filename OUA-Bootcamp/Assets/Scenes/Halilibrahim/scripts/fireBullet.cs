using UnityEngine;

public class fireBullet : MonoBehaviour
{
    public GameObject mermiPrefab; // Kur�un objesinin prefab'�
    public Transform nisangahNoktasi; // Nisangah noktas�n�n Transform bile�eni

    public float atisGucu = 1000f; // Kur�un at�� g�c� (N)
    public float atisHizi = 100f; // Kur�un at�� h�z� (m/s)

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Sol fare tu�una bas�ld���nda at�� yap
        {
            AtisYap();
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
