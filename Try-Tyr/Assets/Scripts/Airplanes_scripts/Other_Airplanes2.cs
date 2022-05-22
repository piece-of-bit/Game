using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Other_Airplanes2 : MonoBehaviour
{
    public Score money; 
    public ConfirmationScript text_for_confirm;
    public GameObject A1GO;
    public GameObject A2GO;
    public GameObject A3GO;
    public GameObject A1BACK;
    public GameObject A2BACK;
    public GameObject A3BACK;
    [SerializeField] private GameObject YES;
    [SerializeField] private GameObject ICON;
    [SerializeField] private GameObject GO;
    [SerializeField] private GameObject UPGRADE;
    [SerializeField] private GameObject BUY;
    bool UNLOCK2; 
    bool yes2;
    bool no2;
    bool buy2;
    bool upgrade2;
    bool in_fly2;
    int lvl_upgrade2 = 1;     //СДЕЛАТЬ РАЗНЫЕ ВЕЛИЧИНЫ У РАЗНЫХ САМОЛЕТОВ
    double win_scale2 = 1;    //СДЕЛАТЬ РАЗНЫЕ ВЕЛИЧИНЫ У РАЗНЫХ САМОЛЕТОВ
    double price_scale2 = 1;  //СДЕЛАТЬ РАЗНЫЕ ВЕЛИЧИНЫ У РАЗНЫХ САМОЛЕТОВ
    public void ClickUpgradeButton2()
    {
        upgrade2 = true;
        text_for_confirm.message_upgrade = (100 * price_scale2).ToString();
    }
    public void ClickGoButton2()
    {
        in_fly2 = true;
        StartCoroutine(Fly_Time2());
        if (lvl_upgrade2 == 1)
        {
            Instantiate(A1GO);
        }
        else if (lvl_upgrade2 == 2)
        {
            Instantiate(A2GO);
        }
        else if (lvl_upgrade2 == 3)
        {
            Instantiate(A3GO);
        }
    }
    public void ClickBuyButton2()
    {
        buy2 = true;
        text_for_confirm.message_buy = (1000 * money.price_buy_scale).ToString();
    }
    public void Yes2()
    {
        yes2 = true;
    }
    public void No2()
    {
        no2 = true;
    }

    void Update()
    {
        //проверка куплен ли самолет
        if (UNLOCK2)
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
        if (lvl_upgrade2 > 2)
        {
            UPGRADE.GetComponent<Button>().interactable = false;
            UPGRADE.GetComponent<Button>().enabled = false;
        }

        //Пуск
        if (in_fly2)
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
        if (upgrade2)
        {
            if (money.MONEY < 100 * price_scale2)
            {
                YES.GetComponent<Button>().interactable = false;
                YES.GetComponent<Button>().enabled = false;
            }
            else if (money.MONEY >= 100 * price_scale2)
            {
                YES.GetComponent<Button>().interactable = true;
                YES.GetComponent<Button>().enabled = true;

                if (yes2)
                {
                    money.MONEY = money.MONEY - 100 * price_scale2;
                    win_scale2 = lvl_upgrade2 * 2;                            //Подогнать величины улучшений
                    lvl_upgrade2 += 1;                                        //Подогнать величины улучшений
                    price_scale2 = lvl_upgrade2 * 2;                          //Подогнать величины улучшений
                    upgrade2 = false;
                    yes2 = false;
                }
                else if (no2)
                {
                    upgrade2 = false;
                    no2 = false;
                }
            }
        }

        //подтверждение выбора покупки
        if (buy2)
        {
            if (money.MONEY < 1000 * money.price_buy_scale)
            {
                YES.GetComponent<Button>().interactable = false;
                YES.GetComponent<Button>().enabled = false;
            }
            else if (money.MONEY >= 100 * price_scale2)
            {
                YES.GetComponent<Button>().interactable = true;
                YES.GetComponent<Button>().enabled = true;

                if (yes2)
                {
                    money.MONEY = money.MONEY - 1000 * money.price_buy_scale;
                    money.price_buy_scale += 1;
                    buy2 = false;
                    yes2 = false;
                    UNLOCK2 = true;
                }
                else if (no2)
                {
                    buy2 = false;
                    no2 = false;
                }
            }
        }
    }
    IEnumerator Fly_Time2()
    {
        yield return new WaitForSeconds(8.0f);
        money.MONEY = money.MONEY + Random.Range(500, 501) * win_scale2;  // ПОРАБОТАТЬ С НАГРАДАМИ
        if (lvl_upgrade2 == 1)
        {
            Instantiate(A1BACK);
        }
        else if (lvl_upgrade2 == 2)
        {
            Instantiate(A2BACK);
        }
        else if (lvl_upgrade2 == 3)
        {
            Instantiate(A3BACK);
        }
        in_fly2 = false;
    }
}