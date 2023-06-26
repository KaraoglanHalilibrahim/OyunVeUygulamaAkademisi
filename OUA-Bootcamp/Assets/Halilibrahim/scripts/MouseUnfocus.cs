using UnityEngine;

public class MouseUnfocus : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = true; // Fare imleci g�r�n�r yap�l�yor
        Cursor.lockState = CursorLockMode.None; // Fare imleci serbest b�rak�l�yor
    }
}
