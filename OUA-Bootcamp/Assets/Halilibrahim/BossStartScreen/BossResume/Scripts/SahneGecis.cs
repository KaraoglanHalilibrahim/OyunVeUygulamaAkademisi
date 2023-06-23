using UnityEngine;
using UnityEngine.SceneManagement;

public class SahneGecis : MonoBehaviour
{
    public int GecisZamani = 17;
    public string hedefSahneAdi; // Ge�i� yap�lacak hedef sahne ad�

    private void Start()
    {
        Invoke("SahneyeGec", GecisZamani); // 20 saniye sonra "SahneyeGec" metodunu �a��r
    }

    private void SahneyeGec()
    {
        SceneManager.LoadScene(hedefSahneAdi); // Hedef sahneye ge�i� yap
    }
}
