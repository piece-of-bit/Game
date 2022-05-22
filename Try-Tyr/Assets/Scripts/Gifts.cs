using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gifts : MonoBehaviour
{
    [SerializeField] private GameObject Ticket;
    [SerializeField] private GameObject Scratch;
    [SerializeField] private GameObject C10;
    [SerializeField] private GameObject C5;
    [SerializeField] private GameObject C2;
    public Text score;
    int koll;
    public Score money;
    bool ticket;
    bool scratch;
    bool c10;
    bool c5;
    bool c2;
    //для примера
    bool lock1;
    bool lock2;
    bool lock3;
    // Start is called before the first frame update
    void Start()
    {
        koll= 0;
    }

    // Update is called once per frame
    void Update()
    {
        score.text = koll.ToString();

        if (money.MONEY < 1000)
        {
            Ticket.GetComponent<Button>().interactable = false;
            Ticket.GetComponent<Button>().enabled = false;

            Scratch.GetComponent<Button>().interactable = false;
            Scratch.GetComponent<Button>().enabled = false;

            C10.GetComponent<Button>().interactable = false;
            C10.GetComponent<Button>().enabled = false;

            C5.GetComponent<Button>().interactable = false;
            C5.GetComponent<Button>().enabled = false;

            C2.GetComponent<Button>().interactable = false;
            C2.GetComponent<Button>().enabled = false;
        }
        else
        {
            if (lock1)
            {
                C10.GetComponent<Button>().interactable = false;
                C10.GetComponent<Button>().enabled = false;
            }
            else
            {
                C10.GetComponent<Button>().interactable = true;
                C10.GetComponent<Button>().enabled = true;
            }
            if (lock2)
            {
                C5.GetComponent<Button>().interactable = false;
                C5.GetComponent<Button>().enabled = false;
            }
            else
            {
                C5.GetComponent<Button>().interactable = true;
                C5.GetComponent<Button>().enabled = true;
            }
            if (lock3)
            {
                C2.GetComponent<Button>().interactable = false;
                C2.GetComponent<Button>().enabled = false;
            }
            else
            {
                C2.GetComponent<Button>().interactable = true;
                C2.GetComponent<Button>().enabled = true;
            }

            Ticket.GetComponent<Button>().interactable = true;
            Ticket.GetComponent<Button>().enabled = true;

            Scratch.GetComponent<Button>().interactable = true;
            Scratch.GetComponent<Button>().enabled = true;

            if (ticket)
            {
                money.MONEY = money.MONEY - 1000;
                ticket = false;
                koll++;
            }
            if (scratch)
            {
                money.MONEY = money.MONEY - 1000;
                scratch = false;
            }
            if (c10)
            {
                C10.GetComponent<Button>().interactable = false;
                C10.GetComponent<Button>().enabled = false;
                money.MONEY = money.MONEY - 1000;
                c10 = false;
                lock1 = true;
            }
            if (c5)
            {
                money.MONEY = money.MONEY - 1000;
                C5.GetComponent<Button>().interactable = false;
                C5.GetComponent<Button>().enabled = false;
                c5 = false;
                lock2 = true;
            }
            if (c2)
            {
                C2.GetComponent<Button>().interactable = false;
                C2.GetComponent<Button>().enabled = false;
                money.MONEY = money.MONEY - 1000;
                c2 = false;
                lock3 = true;
            }
        }
    }
    public void TICKET()
    {
        ticket = true;
    }
    public void SCRATCH()
    {
        scratch = true;
    }
    public void COUP10()
    {
        c10 = true;
    }
    public void COUP5()
    {
        c5 = true;
    }
    public void COUP2()
    {
        c2 = true;
    }
}
