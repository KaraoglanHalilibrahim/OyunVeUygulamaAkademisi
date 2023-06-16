using UnityEngine;

public class ParkurOlusturucu : MonoBehaviour
{
    public GameObject parkurParcasiPrefab; // Parkur par�as� prefab�
    public Transform parkurParent; // Parkur par�alar�n�n eklenece�i ebeveyn transform

    public int genislik = 10; // Parkurun geni�li�i
    public int uzunluk = 20; // Parkurun uzunlu�u
    public int yukseklik = 5; // Parkurun y�ksekli�i

    void Start()
    {
        OyunParkurunuOlustur();
    }

    void OyunParkurunuOlustur()
    {
        for (int x = 0; x < genislik; x++)
        {
            for (int z = 0; z < uzunluk; z++)
            {
                for (int y = 0; y < yukseklik; y++)
                {
                    GameObject parkurParcasi = Instantiate(parkurParcasiPrefab, new Vector3(x, y, z), Quaternion.identity);
                    parkurParcasi.transform.parent = parkurParent;
                }
            }
        }
    }
}
