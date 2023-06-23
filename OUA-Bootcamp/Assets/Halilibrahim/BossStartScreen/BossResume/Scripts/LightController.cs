using UnityEngine;

public class LightController : MonoBehaviour
{
    public Light pointLight;
    public float minColorValue = 35.0f; // Minimum renk de�eri
    public float maxColorValue = 255.0f; // Maksimum renk de�eri
    public float changeSpeed = 50.0f; // De�er de�i�tirme h�z�

    private Color currentColor;
    private float targetR;
    private float targetG;
    private float targetB;

    void Start()
    {
        // Ba�lang�� de�erlerini atama
        currentColor = new Color(Random.Range(minColorValue, maxColorValue) / 255.0f, Random.Range(minColorValue, maxColorValue) / 255.0f, Random.Range(minColorValue, maxColorValue) / 255.0f);
        targetR = Random.Range(minColorValue, maxColorValue) / 255.0f;
        targetG = Random.Range(minColorValue, maxColorValue) / 255.0f;
        targetB = Random.Range(minColorValue, maxColorValue) / 255.0f;
    }

    void Update()
    {
        // Renk de�erlerini hedeflere do�ru de�i�tirme
        currentColor.r = Mathf.MoveTowards(currentColor.r, targetR, changeSpeed * Time.deltaTime / 255.0f);
        currentColor.g = Mathf.MoveTowards(currentColor.g, targetG, changeSpeed * Time.deltaTime / 255.0f);
        currentColor.b = Mathf.MoveTowards(currentColor.b, targetB, changeSpeed * Time.deltaTime / 255.0f);

        // Hedef renklere ula��ld���nda yeni hedefler belirleme
        if (currentColor.r == targetR && currentColor.g == targetG && currentColor.b == targetB)
        {
            targetR = Random.Range(minColorValue, maxColorValue) / 255.0f;
            targetG = Random.Range(minColorValue, maxColorValue) / 255.0f;
            targetB = Random.Range(minColorValue, maxColorValue) / 255.0f;
        }

        // Renk de�erlerini de�i�tirme
        ChangeLightColor(currentColor);
    }

    void ChangeLightColor(Color color)
    {
        // I��k rengini de�i�tirme
        pointLight.color = color;
    }
}
