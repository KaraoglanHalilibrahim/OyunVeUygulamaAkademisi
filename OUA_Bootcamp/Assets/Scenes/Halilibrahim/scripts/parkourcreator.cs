using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parkourcreator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        OyunuBa�lat();
    }

    void OyunuBa�lat()
    {
        for (int i = 0; i < parkurNesnesi.childCount; i++)
        {
            Transform obje = parkurNesnesi.GetChild(i);

            // Rastgele bir konum olu�tur
            Vector3 rastgeleKonum = new Vector3(Random.Range(-rastgeleKonumAral���, rastgeleKonumAral���),
                                                0f,
                                                Random.Range(-rastgeleKonumAral���, rastgeleKonumAral���));

            // Objeyi rastgele konuma ta��
            obje.position = obje.position + rastgeleKonum;
        }
    }
}

