using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Other_Airplanes5 : MonoBehaviour
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
    bool UNLOCK5;
    bool yes5;
    bool no5;
    bool buy5;
    bool upgrade5;
    bool in_fly5;
    int lvl_upgrade5 = 1;
    double win_scale5 = 1;
    double price_scale5 = 1;
    public void ClickUpgradeButton5()
    {
        upgrade5 = true;
        text_for_confirm.message_upgrade = (100 * price_scale5).ToString();
    }
    public void ClickGoButton5()
    {
        in_fly5 = true;
        StartCoroutine(Fly_Time5());
        if (lvl_upgrade5 == 1)
        {
            Instantiate(A1GO);
        }
        else if (lvl_upgrade5 == 2)
        {
            Instantiate(A2GO);
        }
        else if (lvl_upgrade5 == 3)
        {
            Instantiate(A3GO);
        }
    }
    public void ClickBuyButton5()
    {
        buy5 = true;
        text_for_confirm.message_buy = (1000 * money.price_buy_scale).ToString();
    }
    public void Yes5()
    {
        yes5 = true;
    }
    public void No5()
    {
        no5 = true;
    }

    void Update()
    {
        //проверка куплен ли самолет
        if (UNLOCK5)
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
        if (lvl_upgrade5 > 2)
        {
            UPGRADE.GetComponent<Button>().interactable = false;
            UPGRADE.GetComponent<Button>().enabled = false;
        }

        //Пуск
        if (in_fly5)
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
        if (upgrade5)
        {
            if (money.MONEY < 100 * price_scale5)
            {
                YES.GetComponent<Button>().interactable = false;
                YES.GetComponent<Button>().enabled = false;
            }
            else if (money.MONEY >= 100 * price_scale5)
            {
                YES.GetComponent<Button>().interactable = true;
                YES.GetComponent<Button>().enabled = true;

                if (yes5)
                {
                    money.MONEY = money.MONEY - 100 * price_scale5;
                    win_scale5 = lvl_upgrade5 * 2;
                    lvl_upgrade5 += 1;   //увеличение цены и награды от уровня
                    price_scale5 = lvl_upgrade5 * 2;
                    upgrade5 = false;
                    yes5 = false;
                }
                else if (no5)
                {
                    upgrade5 = false;
                    no5 = false;
                }
            }
        }

        //подтверждение выбора покупки
        if (buy5)
        {
            if (money.MONEY < 1000 * money.price_buy_scale)
            {
                YES.GetComponent<Button>().interactable = false;
                YES.GetComponent<Button>().enabled = false;
            }
            else if (money.MONEY >= 100 * price_scale5)
            {
                YES.GetComponent<Button>().interactable = true;
                YES.GetComponent<Button>().enabled = true;

                if (yes5)
                {
                    money.MONEY = money.MONEY - 1000 * money.price_buy_scale;
                    money.price_buy_scale += 1;
                    buy5 = false;
                    yes5 = false;
                    UNLOCK5 = true;
                }
                else if (no5)
                {
                    buy5 = false;
                    no5 = false;
                }
            }
        }
    }
    IEnumerator Fly_Time5()
    {
        yield return new WaitForSeconds(8.0f);
        money.MONEY = money.MONEY + Random.Range(500, 501) * win_scale5;
        if (lvl_upgrade5 == 1)
        {
            Instantiate(A1BACK);
        }
        else if (lvl_upgrade5 == 2)
        {
            Instantiate(A2BACK);
        }
        else if (lvl_upgrade5 == 3)
        {
            Instantiate(A3BACK);
        }
        in_fly5 = false;
    }
}