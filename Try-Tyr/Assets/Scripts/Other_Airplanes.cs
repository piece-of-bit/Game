using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Other_Airplanes : MonoBehaviour
{
    public Score money;
    public ConfirmationScript text_for_confirm;
    [SerializeField] private GameObject YES;
    [SerializeField] private GameObject ICON;
    [SerializeField] private GameObject GO;
    [SerializeField] private GameObject UPGRADE;
    [SerializeField] private GameObject BUY;
    bool UNLOCK;
    bool yes;
    bool no;
    bool buy;
    bool upgrade;
    bool in_fly;
    int lvl_upgrade = 1;
    double win_scale = 1;
    double price_scale = 1;
    public void ClickUpgradeButton()
    {
        upgrade = true;
        text_for_confirm.message_upgrade = (100 * price_scale).ToString();
    }
    public void ClickGoButton()
    {
        in_fly = true;
        StartCoroutine(Fly_Time());
    }
    public void ClickBuyButton()
    {
        buy = true;
        text_for_confirm.message_buy = (1000 * money.price_buy_scale).ToString();
    }
    public void Yes()
    {
        yes = true;
    }
    public void No()
    {
        no = true;
    }

    void Update()
    {
        //проверка куплен ли самолет
        if (UNLOCK)
        {
            UPGRADE.SetActive(true);
            GO.SetActive(true);
            BUY.SetActive(false);
        }
        else
        {
            UPGRADE.SetActive(false);
            GO.SetActive(false);
            BUY.SetActive(true);
        }
        //ограничение уровня апгрейда
        if (lvl_upgrade > 3)
        {
            UPGRADE.GetComponent<Button>().interactable = false;
            UPGRADE.GetComponent<Button>().enabled = false;
        }

        //Пуск
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

        //подтверждение выбора апгрейда
        if (upgrade)
        {
            if (money.MONEY < 100 * price_scale)
            {
                YES.GetComponent<Button>().interactable = false;
                YES.GetComponent<Button>().enabled = false;
            }
            else if (money.MONEY >= 100 * price_scale)
            {
                YES.GetComponent<Button>().interactable = true;
                YES.GetComponent<Button>().enabled = true;

                if (yes)
                {
                    money.MONEY = money.MONEY - 100 * price_scale;
                    win_scale = lvl_upgrade * 2;
                    lvl_upgrade += 1;   //увеличение цены и награды от уровня
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
        }

        //подтверждение выбора покупки
        if (buy)
        {
            if (money.MONEY < 1000 * money.price_buy_scale)
            {
                YES.GetComponent<Button>().interactable = false;
                YES.GetComponent<Button>().enabled = false;
            }
            else if (money.MONEY >= 1000 * money.price_buy_scale)
            {
                YES.GetComponent<Button>().interactable = true;
                YES.GetComponent<Button>().enabled = true;

                if (yes)
                {
                    money.MONEY = money.MONEY - 1000 * money.price_buy_scale;
                    money.price_buy_scale += 1;
                    yes = false;
                    buy = false;
                    UNLOCK = true;
                }
                else if (no)
                {
                    buy = false;
                    no = false;
                }
            }
        }
    }
    IEnumerator Fly_Time()
    {
        yield return new WaitForSeconds(8.0f);
        money.MONEY = money.MONEY + Random.Range(500, 501) * win_scale;
        in_fly = false;
    }
}