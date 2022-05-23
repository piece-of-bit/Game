using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Photo : MonoBehaviour
{
    [SerializeField] private GameObject Photo1;
    [SerializeField] private GameObject Photo2;
    [SerializeField] private GameObject Photo3;
    bool START;
    bool fo1;
    bool fo2;
    bool fo3;
    int WhatToSpawn;

    // Update is called once per frame
    void Update()
    {
        if(START)
        {
            WhatToSpawn = Random.Range(1, 4);
            StartCoroutine(spawn());
            START = false;
        }
        if (fo1)
        {
            Photo1.SetActive(false);
            fo1 = false;
        }
        if (fo2)
        {
            Photo2.SetActive(false);
            fo2 = false;
        }
        if (fo3)
        {
            Photo3.SetActive(false);
            fo3 = false;
        }
    }

    public void start()
    {
        START = true;
    }
    public void f1()
    {
        fo1 = true;
    }
    public void f2()
    {
        fo2 = true;
    }
    public void f3()
    {
        fo3 = true;
    }
    IEnumerator spawn()
    {
        yield return new WaitForSeconds(13.0f);
        if (WhatToSpawn == 1)
        {
            Photo1.SetActive(true);
        }
        else if (WhatToSpawn == 2)
        {
            Photo2.SetActive(true);
        }
        else if (WhatToSpawn == 3)
        {
            Photo3.SetActive(true);
        }
    }
}
