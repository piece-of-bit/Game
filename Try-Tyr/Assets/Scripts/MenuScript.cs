using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    bool PressOpen;
    bool PressClose;
    public RectTransform slider;
    Vector2 v;
    // Start is called before the first frame update
    void Start()
    {
        v = slider.anchorMax;
    }

    // Update is called once per frame
    void Update()
    {
        if (PressOpen)
        {
            v.y += 0.02f;
            slider.anchorMax = v;
            if (slider.anchorMax.y >= 1f)
            {
                PressOpen = false;
            }
        }
        if (PressClose)
        {
            v.y -= 0.02f;
            slider.anchorMax = v;
            if (slider.anchorMax.y <= 0f)
            {
                PressClose = false;
            }
        }
    }
    public void Open()
    {
        PressOpen = true;
    }
    public void Close()
    {
        PressClose = true;
    }
}
