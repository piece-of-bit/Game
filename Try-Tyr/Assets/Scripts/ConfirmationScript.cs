using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmationScript : MonoBehaviour
{
    bool PressYES;
    bool PressNO;
    string text_message;
    public RectTransform slider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PressYES)
        {
           
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
}
