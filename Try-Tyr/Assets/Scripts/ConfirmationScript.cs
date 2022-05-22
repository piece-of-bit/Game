using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmationScript : MonoBehaviour
{
    public string message_upgrade;
    public string message_buy;
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
            Choice_Text.text = "Вы действительно хотите приобрести самолет за " + message_buy;
            Confirmation_window.SetActive(true);
            BUY = false;
        }
        else if (UPGRADE)
        {
            Choice_Text.text = "Вы действительно хотите улучшить самолет за " + message_upgrade;
            Confirmation_window.SetActive(true);
            UPGRADE = false;
        }
        if (PressYES)
        {
            Confirmation_window.SetActive(false);
            PressYES = false;
        }
        if (PressNO)
        {
            Confirmation_window.SetActive(false);
            PressNO = false;
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
