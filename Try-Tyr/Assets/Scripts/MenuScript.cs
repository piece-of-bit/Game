using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    [SerializeField] private GameObject Panel;
    [SerializeField] private GameObject CLOSE;
    bool PressOpen;
    bool PressClose;
    bool PressGO;
    public RectTransform slider;
    Vector2 v;
    // Start is called before the first frame update
    void Start()
    {
        v = slider.anchorMax;
    }

    // Update is called once per frame
    void Update()
    {
        if (PressOpen)
        {
            CLOSE.GetComponent<Button>().interactable = false;
            CLOSE.GetComponent<Button>().enabled = false;
            v.y += 0.04f;
            slider.anchorMax = v;
            if (slider.anchorMax.y >= 1f)
            {
                PressOpen = false;
                CLOSE.GetComponent<Button>().interactable = true;
                CLOSE.GetComponent<Button>().enabled = true;
            }
        }
        if (PressClose)
        {
            v.y -= 0.04f;
            slider.anchorMax = v;
            if (slider.anchorMax.y <= 0f)
            {
                PressClose = false;
            }
        }
        if (PressGO)
        {
            v.y = 0f;
            slider.anchorMax = v;
            if (slider.anchorMax.y <= 0f)
            {
                PressGO = false;
                Panel.SetActive(true);
            }

        }
    }
    public void Open()
    {
        PressOpen = true;
    }
    public void Close()
    {
        PressClose = true;
    }
    public void Go()
    {
        PressGO = true;
        StartCoroutine(CloseObj());
    }
    IEnumerator CloseObj()
    {
        yield return new WaitForSeconds(4.0f);
        Panel.SetActive(false);
    }
}
