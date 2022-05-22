using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butn_FX : MonoBehaviour
{
    public AudioSource My_Fx;
    public AudioClip ClickFx;
    
    public void ClickSound()
    {
        My_Fx.PlayOneShot(ClickFx);
    }
    
}
