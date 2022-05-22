using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prizespawner : MonoBehaviour
{

    public GameObject Prize1, Prize2, Prize3, Prize4, Prize5;
    int WhatToSpawn;
    //Instantiate(Prize5, transform.position, Quaternion.identity);
    // Start is called before the first frame update
    void Start()
    {
        WhatToSpawn = Random.Range(1, 6);
        Debug.Log(WhatToSpawn);
        switch (WhatToSpawn)
        {
            case 1:
                Prize1.SetActive(true);
                break;
            case 2:
                Prize2.SetActive(true);
                break;
            case 3:
                Prize3.SetActive(true);
                break;
            case 4:
                Prize4.SetActive(true);
                break;
            case 5:
                Prize5.SetActive(true);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
