using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prizespawner : MonoBehaviour
{

    public GameObject Prize1, Prize2, Prize3, Prize4, Prize5;
    int WhatToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        WhatToSpawn = Random.Range(1, 5);
        Debug.Log(WhatToSpawn);
        switch (WhatToSpawn)
        {
            case 1:
                Instantiate(Prize1, transform.position, Quaternion.identity);
                break;
            case 2:
                Instantiate(Prize2, transform.position, Quaternion.identity);
                break;
            case 3:
                Instantiate(Prize3, transform.position, Quaternion.identity);
                break;
            case 4:
                Instantiate(Prize4, transform.position, Quaternion.identity);
                break;
            case 5:
                Instantiate(Prize5, transform.position, Quaternion.identity);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
