using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scratchcarteffect1 : MonoBehaviour
{
    public GameObject maskPrefab1;
    private bool isPressed = false;

    // Update is called once per frame
    void Update()
    {
        var mousePos = Input.mousePosition;
        mousePos.z = 10;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        if(isPressed == true)
        {
            GameObject maskSprite = Instantiate(maskPrefab1, mousePos, Quaternion.identity);
            maskSprite.transform.parent = gameObject.transform;
        }
        else
        {

        }

        if (Input.GetMouseButtonDown(0))
        {
            Invoke("reveal", 5);
            isPressed = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isPressed = false;
        }
    }
    void reveal()
    {
        Destroy(this.gameObject);
    }
}
