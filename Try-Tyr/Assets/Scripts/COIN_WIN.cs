using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class COIN_WIN : MonoBehaviour
{
    public Score money;
    public GameObject Panel;
    bool pressCoin100;
    bool pressCoin200;
    bool pressCoin300;
    bool pressCoin500;
    bool pressCoin5000;

    // Update is called once per frame
    void Update() 
    {
        if (pressCoin100)
        {
            Panel.SetActive(false);
            money.MONEY = money.MONEY + 100;
            pressCoin100 = false;
        }
        else if (pressCoin200)
        {
            Panel.SetActive(false);
            money.MONEY = money.MONEY + 200;
            pressCoin200 = false;
        }
        else if (pressCoin300)
        {
            Panel.SetActive(false);
            money.MONEY = money.MONEY + 300;
            pressCoin300 = false;
        }
        else if (pressCoin500)
        {
            Panel.SetActive(false);
            money.MONEY = money.MONEY + 500;
            pressCoin500 = false;
        }
        else if (pressCoin5000)
        {
            Panel.SetActive(false);
            money.MONEY = money.MONEY + 5000;
            pressCoin5000 = false;
        }
    }
    public void PressCoin100()
    {
        pressCoin100 = true;
    }
    public void PressCoin200()
    {
        pressCoin200 = true;
    }
    public void PressCoin300()
    {
        pressCoin300 = true;
    }
    public void PressCoin500()
    {
        pressCoin500 = true;
    }
    public void PressCoin5000()
    {
        pressCoin5000 = true;
    }
}
