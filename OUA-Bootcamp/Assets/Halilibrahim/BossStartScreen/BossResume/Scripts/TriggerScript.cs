using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    public GameObject[] objectsToDisable;
    public AudioSource audioSource;

    private void OnTriggerEnter(Collider other)
    {
        // E�er obje triger alan�na girdiyse ve "Character" etiketine sahipse
        if (other.CompareTag("Character"))
        {
            foreach (GameObject obj in objectsToDisable)
            {
                // Objelerin aktifli�ini kapat
                obj.SetActive(false);
            }

            // AudioSource'i oynat
            if (audioSource != null)
            {
                audioSource.Play();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // E�er obje triger alan�ndan ��kt�ysa ve "Character" etiketine sahipse
        if (other.CompareTag("Character"))
        {
            foreach (GameObject obj in objectsToDisable)
            {
                // Objelerin aktifli�ini a�
                obj.SetActive(true);
            }

            // AudioSource'i durdur
            if (audioSource != null && audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }
}
