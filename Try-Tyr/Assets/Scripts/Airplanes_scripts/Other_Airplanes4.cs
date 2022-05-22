using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Other_Airplanes4 : MonoBehaviour
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
    bool UNLOCK4;
    bool yes4;
    bool no4;
    bool buy4;
    bool upgrade4;
    bool in_fly4;
    int lvl_upgrade4 = 1;
    double win_scale4 = 1;
    double price_scale4 = 1;
    public void ClickUpgradeButton4()
    {
        upgrade4 = true;
        text_for_confirm.message_upgrade = (100 * price_scale4).ToString();
    }
    public void ClickGoButton4()
    {
        in_fly4 = true;
        StartCoroutine(Fly_Time4());
        if (lvl_upgrade4 == 1)
        {
            Instantiate(A1GO);
        }
        else if (lvl_upgrade4 == 2)
        {
            Instantiate(A2GO);
        }
        else if (lvl_upgrade4 == 3)
        {
            Instantiate(A3GO);
        }
    }
    public void ClickBuyButton4()
    {
        buy4 = true;
        text_for_confirm.message_buy = (1000 * money.price_buy_scale).ToString();
    }
    public void Yes4()
    {
        yes4 = true;
    }
    public void No4()
    {
        no4 = true;
    }

    void Update()
    {
        //проверка куплен ли самолет
        if (UNLOCK4)
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
        if (lvl_upgrade4 > 2)
        {
            UPGRADE.GetComponent<Button>().interactable = false;
            UPGRADE.GetComponent<Button>().enabled = false;
        }

        //Пуск
        if (in_fly4)
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
        if (upgrade4)
        {
            if (money.MONEY < 100 * price_scale4)
            {
                YES.GetComponent<Button>().interactable = false;
                YES.GetComponent<Button>().enabled = false;
            }
            else if (money.MONEY >= 100 * price_scale4)
            {
                YES.GetComponent<Button>().interactable = true;
                YES.GetComponent<Button>().enabled = true;

                if (yes4)
                {
                    money.MONEY = money.MONEY - 100 * price_scale4;
                    win_scale4 = lvl_upgrade4 * 2;
                    lvl_upgrade4 += 1;   //увеличение цены и награды от уровня
                    price_scale4 = lvl_upgrade4 * 2;
                    upgrade4 = false;
                    yes4 = false;
                }
                else if (no4)
                {
                    upgrade4 = false;
                    no4 = false;
                }
            }
        }

        //подтверждение выбора покупки
        if (buy4)
        {
            if (money.MONEY < 1000 * money.price_buy_scale)
            {
                YES.GetComponent<Button>().interactable = false;
                YES.GetComponent<Button>().enabled = false;
            }
            else if (money.MONEY >= 100 * price_scale4)
            {
                YES.GetComponent<Button>().interactable = true;
                YES.GetComponent<Button>().enabled = true;

                if (yes4)
                {
                    money.MONEY = money.MONEY - 1000 * money.price_buy_scale;
                    money.price_buy_scale += 1;
                    buy4 = false;
                    yes4 = false;
                    UNLOCK4 = true;
                }
                else if (no4)
                {
                    buy4 = false;
                    no4 = false;
                }
            }
        }
    }
    IEnumerator Fly_Time4()
    {
        yield return new WaitForSeconds(8.0f);
        money.MONEY = money.MONEY + Random.Range(500, 501) * win_scale4;   // ПОРАБОТАТЬ С НАГРАДАМИ
        if (lvl_upgrade4 == 1)
        {
            Instantiate(A1BACK);
        }
        else if (lvl_upgrade4 == 2)
        {
            Instantiate(A2BACK);
        }
        else if (lvl_upgrade4 == 3)
        {
            Instantiate(A3BACK);
        }
        in_fly4 = false;
    }
}