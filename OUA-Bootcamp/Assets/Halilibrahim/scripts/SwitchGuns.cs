using UnityEngine;

public class SwitchGuns : MonoBehaviour
{
    public GameObject MainCharacterArms;
    public GameObject Arm_remington;

    void Start()
    {
        // Ba�lang��ta Arm_remington objesini deaktif hale getir
        Arm_remington.SetActive(false);
    }

    void Update()
    {
        // 1 tu�una bas�ld���nda MainCharacterArms deaktif, Arm_remington aktif hale gelsin
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            MainCharacterArms.SetActive(true);
            Arm_remington.SetActive(false);
        }

        // 2 tu�una bas�ld���nda MainCharacterArms aktif, Arm_remington deaktif hale gelsin
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            MainCharacterArms.SetActive(false);
            Arm_remington.SetActive(true);
        }
    }
}
