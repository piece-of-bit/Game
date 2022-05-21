using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmationScript : MonoBehaviour
{
    private Text ScoreText;
    bool PressYES;
    bool PressNO;
    bool START;
    bool BUY;
    bool UPGRADE;
    string text_message;
    public RectTransform slider;
    // Start is called before the first frame update
    void Start()
    {
        ScoreText = GameObject.Find("Canvas/Choiñe/Choiñe_text").GetComponent<Text>().text = CursorsText;
    }

    // Update is called once per frame
    void Update()
    {
        if (PressYES)
        {
            if (START)
            {

            }
            else if (BUY)
            {

            }
            else if (UPGRADE)
            {

            }
        }
        if (PressNO)
        {
            
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
