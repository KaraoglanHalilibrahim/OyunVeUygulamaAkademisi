using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parkourcreator : MonoBehaviour
{
    public Transform parkurNesnesi;
    public float rastgeleKonumAral��� = 5f;
    public float hareketHizi = 2f;

    private Vector3[] baslangicKonumlari;
    private bool kaydiriliyor = false;
    private float kaymaZamani = 0f;

    void Start()
    {
        OyunuBa�lat();
    }

    void Update()
    {
        if (kaydiriliyor)
        {
            kaymaZamani += Time.deltaTime * hareketHizi;

            for (int i = 0; i < parkurNesnesi.childCount; i++)
            {
                Transform obje = parkurNesnesi.GetChild(i);
                Vector3 hedefKonum = baslangicKonumlari[i];
                Vector3 yeniKonum = Vector3.Lerp(obje.position, hedefKonum, kaymaZamani);
                obje.position = yeniKonum;
            }

            if (kaymaZamani >= 1f)
            {
                kaydiriliyor = false;
            }
        }
    }

    void OyunuBa�lat()
    {
        int objeSayisi = parkurNesnesi.childCount;
        baslangicKonumlari = new Vector3[objeSayisi];

        // Ba�lang�� konumlar�n� kaydet
        for (int i = 0; i < objeSayisi; i++)
        {
            baslangicKonumlari[i] = parkurNesnesi.GetChild(i).position;
        }

        // Objeleri rastgele konumlara yerle�tir
        for (int i = 0; i < objeSayisi; i++)
        {
            Transform obje = parkurNesnesi.GetChild(i);

            // Rastgele bir konum olu�tur
            Vector3 rastgeleKonum = new Vector3(Random.Range(-rastgeleKonumAral���, rastgeleKonumAral���),
                                                0f,
                                                Random.Range(-rastgeleKonumAral���, rastgeleKonumAral���));

            // Objeyi rastgele konuma ta��
            obje.position = baslangicKonumlari[i] + rastgeleKonum;
        }

        kaydiriliyor = true;
        kaymaZamani = 0f;
    }

    public void Resetle()
    {
        kaydiriliyor = true;
        kaymaZamani = 0f;
    }
}


