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
    bool START;
    bool BUY;
    bool UPGRADE;
    // Start is called before the first frame update
    void Start()
    {
        Confirmation_window.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (START)
        {
            Choice_Text.text = "ТУТ ДОДЕЛАТЬ КОД";
        }
        else if (BUY)
        {
            Choice_Text.text = "Вы действительно хотите приобрести самолет за 1000?";
        }
        else if (UPGRADE)
        {
            Choice_Text.text = "Вы действительно хотите улучшить самолет за 1000";
        }
        if (PressYES)
        {
            Choice_Text.text = "кнопка да - рабоатет";
        }
        if (PressNO)
        {
            Choice_Text.text = "кнопка нет - рабоатет";
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
    public void Go()
    {
        START = true;
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
