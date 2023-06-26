using UnityEngine;

public class MouseFocus02 : MonoBehaviour
{
    private bool hasFocus = true;

    private void Start()
    {
        // Ba�lang��ta mouse focus'u aktif hale getir
        SetMouseFocus(true);
    }

    private void Update()
    {
        // Tab tu�una bas�ld���nda focus durumunu de�i�tir
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            hasFocus = !hasFocus;
            SetMouseFocus(hasFocus);
        }
    }

    private void SetMouseFocus(bool focus)
    {
        if (focus)
        {
            Cursor.lockState = CursorLockMode.Locked; // Mouse kilitli
            Cursor.visible = false; // Mouse g�r�nmez
        }
        else
        {
            Cursor.lockState = CursorLockMode.None; // Mouse serbest
            Cursor.visible = true; // Mouse g�r�n�r
        }
    }
}
