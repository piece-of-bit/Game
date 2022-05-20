using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    bool PressButton;
    void Update()
    {
        if (PressButton)
        {
            Destroy(gameObject);
        }
    }
    public void Click()
    {
        PressButton = true;
    }
}
