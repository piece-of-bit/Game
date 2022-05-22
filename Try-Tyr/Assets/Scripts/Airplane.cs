using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Airplane : MonoBehaviour
{
    public Score money;
    public ConfirmationScript text_for_confirm;
    [SerializeField] private GameObject ICON;
    [SerializeField] private GameObject GO;
    [SerializeField] private GameObject UPGRADE;
    bool yes;
    bool no;
    bool buy;
    bool upgrade;
    bool in_fly; //go
    public Text Score_text;
    int lvl_upgrade = 1;
    double win_scale = 1;
    double price_scale = 1;
    public void ClickUpgradeButton()
    {
        upgrade = true;
    }
    public void ClickGoButton()
    {
        in_fly = true;
        StartCoroutine(Fly_Time());
    }

    void Update()
    {
        // ƒќ—“”ѕЌќ—“№  Ќќѕќ 
        //ограничение уровн€ апгрейда
        if(lvl_upgrade < 3)
        {
            //апгрейд
            if (money.MONEY < 100 * price_scale)
            {
                UPGRADE.GetComponent<Button>().interactable = false;
                UPGRADE.GetComponent<Button>().enabled = false;
            }
            else if (money.MONEY >= 100 * price_scale)
            {
                UPGRADE.GetComponent<Button>().interactable = true;
                UPGRADE.GetComponent<Button>().enabled = true;
            }
        }
        else
        {
            UPGRADE.GetComponent<Button>().interactable = false;
            UPGRADE.GetComponent<Button>().enabled = false;
        }

        //ѕуск
        if (in_fly)
        {
            GO.GetComponent<Button>().interactable = false;
            GO.GetComponent<Button>().enabled = false;
        }
        else
        {
            GO.GetComponent<Button>().interactable = true;
            GO.GetComponent<Button>().enabled = true;
        }
        /////////////

        //подтверждение выбора апгрейда
        if (upgrade)
        {
            if (yes)
            {
                money.MONEY = money.MONEY - 100 * price_scale;
                win_scale = lvl_upgrade * 2;
                lvl_upgrade += 1;
                //увеличение цены и награды от уровн€
                price_scale = lvl_upgrade * 2;
                upgrade = false;
                yes = false;
            }
            else if (no)
            {
                upgrade = false;
                no = false;
            }
        }
        
        //красивое отображение счета
        if (money.MONEY < 10)
        {
            Score_text.text = "00000" + System.Math.Round(money.MONEY, 0).ToString();
        }
        else if (money.MONEY < 100)
        {
            Score_text.text = "0000" + System.Math.Round(money.MONEY, 0).ToString();
        }
        else if (money.MONEY < 1000)
        {
            Score_text.text = "000" + System.Math.Round(money.MONEY, 0).ToString();
        }
        else if (money.MONEY < 10000)
        {
            Score_text.text = "00" + System.Math.Round(money.MONEY, 0).ToString();
        }
        else if (money.MONEY < 100000)
        {
            Score_text.text = "0" + System.Math.Round(money.MONEY, 0).ToString();
        }
        else if (money.MONEY < 1000000)
        {
            Score_text.text = System.Math.Round(money.MONEY, 0).ToString();
        }
        else
        {
            Score_text.text = System.Math.Round(money.MONEY, 0).ToString();
        }
    }
    IEnumerator Fly_Time()
    {
        yield return new WaitForSeconds(10.0f);
        money.MONEY = money.MONEY + Random.Range(100, 101) * win_scale;
        in_fly = false;
    }
    public void Yes()
    {
        yes = true;
    }
    public void No()
    {
        no = true;
    }
}