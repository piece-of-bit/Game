using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmationScript : MonoBehaviour
{
    [SerializeField] private Text Choice_Text;
    [SerializeField] private GameObject Confirmation_window;
    bool PressYES;
    bool PressNO;
    bool BUY;
    bool UPGRADE;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (BUY)
        {
            Choice_Text.text = "Вы действительно хотите приобрести самолет за 1000?";
            Confirmation_window.SetActive(true);
        }
        else if (UPGRADE)
        {
            Choice_Text.text = "Вы действительно хотите улучшить самолет за 1000";
            Confirmation_window.SetActive(true);
        }
        if (PressYES)
        {
            Choice_Text.text = "кнопка да - рабоатет";
            Confirmation_window.SetActive(false);
            if (BUY)
            {
                Confirmation_window.SetActive(false);
            }
            UPGRADE = false;
        }
        if (PressNO)
        {
            Choice_Text.text = "кнопка нет - рабоатет";
            Confirmation_window.SetActive(false);
            BUY = false;
            UPGRADE = false;
        }
    }
    public void Yes()
    {
        PressYES = true;
    }
    public void No()
    {
        PressNO = true;
    }

    public void Buy()
    {
        BUY = true;
    }
    public void Upgrade()
    {
        UPGRADE = true;
    }
}
