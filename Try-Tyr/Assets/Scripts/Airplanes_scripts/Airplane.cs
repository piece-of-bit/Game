using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Airplane : MonoBehaviour
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
    bool yes;
    bool no;
    bool upgrade;
    bool in_fly;
    public Text Score_text;
    int lvl_upgrade = 1;
    double win_scale = 1;
    double price_scale = 1;
    private void ClickUpgradeButton()
    {
        upgrade = true;
        text_for_confirm.message_upgrade = (100 * price_scale).ToString(); // передаваемое сообщение
    }
    private void ClickGoButton()
    {
        in_fly = true;
        StartCoroutine(Fly_Time());
        if (lvl_upgrade == 1)
        {
            Instantiate(A1GO);
        }
        else if (lvl_upgrade == 2)
        {
            Instantiate(A2GO);
        }
        else if (lvl_upgrade == 3)
        {
            Instantiate(A3GO);
        }
    }
    private void Yes()
    {
        yes = true;
    }
    private void No()
    {
        no = true;
    }

    void Update()
    {
        //ограничение уровня апгрейда
        if (lvl_upgrade > 2)
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
            else
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
        money.MONEY = money.MONEY + Random.Range(500, 501) * win_scale;
        if(lvl_upgrade == 1)
        {
            Instantiate(A1BACK);
        }
        else if(lvl_upgrade == 2)
        {
            Instantiate(A2BACK);
        }
        else if (lvl_upgrade == 3)
        {
            Instantiate(A3BACK);
        }
        in_fly = false;
    }
}