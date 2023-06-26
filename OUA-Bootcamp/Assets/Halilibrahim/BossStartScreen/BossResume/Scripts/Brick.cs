using UnityEngine;

public class Brick : MonoBehaviour
{
    public GameObject character; // Karakter objesini tutmak i�in de�i�ken
    public GameObject otherObject; // Di�er objeyi tutmak i�in de�i�ken
    public float collisionDelay = 2f;
    public float collisionDelay2;// Tetiklemeden sonra sesin �alaca�� gecikme s�resi
    public AudioSource audioSource; // D��ar�dan atanacak olan AudioSource bile�eni

    private bool collided;

    private void Start()
    {
        collided = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == character)
        {
            collided = true;
            
            Invoke("PlayAudio", collisionDelay);
            Invoke("Destroy", collisionDelay2);


        }
    }

    private void PlayAudio()
    {
        if (collided && audioSource != null)
        {
            audioSource.Play();
        }
    }
    private void Destroy()
    {
        Destroy(gameObject);
    }
}
