using UnityEngine;

public class MouseFocus : MonoBehaviour
{
    void Start()
    {
        // Oyun ekran�na odaklan
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Esc tu�una bas�ld���nda fareyi serbest b�rak
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
