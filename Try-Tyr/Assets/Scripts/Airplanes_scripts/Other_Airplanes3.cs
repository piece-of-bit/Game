using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Other_Airplanes3 : MonoBehaviour
{
    public Score money;
    public ConfirmationScript text_for_confirm;
    [SerializeField] private GameObject YES;
    [SerializeField] private GameObject ICON;
    [SerializeField] private GameObject GO;
    [SerializeField] private GameObject UPGRADE;
    [SerializeField] private GameObject BUY;
    bool UNLOCK3;
    bool yes3;
    bool no3;
    bool buy3;
    bool upgrade3;
    bool in_fly3;
    int lvl_upgrade3 = 1;     //СДЕЛАТЬ РАЗНЫЕ ВЕЛИЧИНЫ У РАЗНЫХ САМОЛЕТОВ
    double win_scale3 = 1;    //СДЕЛАТЬ РАЗНЫЕ ВЕЛИЧИНЫ У РАЗНЫХ САМОЛЕТОВ
    double price_scale3 = 1;  //СДЕЛАТЬ РАЗНЫЕ ВЕЛИЧИНЫ У РАЗНЫХ САМОЛЕТОВ
    public void ClickUpgradeButton3()
    {
        upgrade3 = true;
        text_for_confirm.message_upgrade = (100 * price_scale3).ToString();
    }
    public void ClickGoButton3()
    {
        in_fly3 = true;
        StartCoroutine(Fly_Time3());
    }
    public void ClickBuyButton3()
    {
        buy3 = true;
        text_for_confirm.message_buy = (1000 * money.price_buy_scale).ToString();
    }
    public void Yes3()
    {
        yes3 = true;
    }
    public void No3()
    {
        no3 = true;
    }

    void Update()
    {
        //проверка куплен ли самолет
        if (UNLOCK3)
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
        if (lvl_upgrade3 > 3)
        {
            UPGRADE.GetComponent<Button>().interactable = false;
            UPGRADE.GetComponent<Button>().enabled = false;
        }

        //Пуск
        if (in_fly3)
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
        if (upgrade3)
        {
            if (money.MONEY < 100 * price_scale3)
            {
                YES.GetComponent<Button>().interactable = false;
                YES.GetComponent<Button>().enabled = false;
            }
            else if (money.MONEY >= 100 * price_scale3)
            {
                YES.GetComponent<Button>().interactable = true;
                YES.GetComponent<Button>().enabled = true;

                if (yes3)
                {
                    money.MONEY = money.MONEY - 100 * price_scale3;
                    win_scale3 = lvl_upgrade3 * 2;                            //Подогнать величины улучшений
                    lvl_upgrade3 += 1;                                        //Подогнать величины улучшений
                    price_scale3 = lvl_upgrade3 * 2;                          //Подогнать величины улучшений
                    upgrade3 = false;
                    yes3 = false;
                }
                else if (no3)
                {
                    upgrade3 = false;
                    no3 = false;
                }
            }
        }

        //подтверждение выбора покупки
        if (buy3)
        {
            if (money.MONEY < 1000 * money.price_buy_scale)
            {
                YES.GetComponent<Button>().interactable = false;
                YES.GetComponent<Button>().enabled = false;
            }
            else if (money.MONEY >= 100 * price_scale3)
            {
                YES.GetComponent<Button>().interactable = true;
                YES.GetComponent<Button>().enabled = true;

                if (yes3)
                {
                    money.MONEY = money.MONEY - 1000 * money.price_buy_scale;
                    money.price_buy_scale += 1;
                    buy3 = false;
                    yes3 = false;
                    UNLOCK3 = true;
                }
                else if (no3)
                {
                    buy3 = false;
                    no3 = false;
                }
            }
        }
    }
    IEnumerator Fly_Time3()
    {
        yield return new WaitForSeconds(8.0f);
        money.MONEY = money.MONEY + Random.Range(500, 501) * win_scale3;  // ПОРАБОТАТЬ С НАГРАДАМИ
        in_fly3 = false;
    }
}