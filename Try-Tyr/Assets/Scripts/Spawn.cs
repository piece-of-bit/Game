using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public void SpawnNeedObj(GameObject ObjPrefab)
    {
        Instantiate(ObjPrefab);
    }
}
