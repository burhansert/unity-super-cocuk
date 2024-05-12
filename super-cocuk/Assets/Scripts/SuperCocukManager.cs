using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperCocukManager : MonoBehaviour
{
    public float saglik=100f;
    public bool oldum=false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HasarAl(float hasar)
    {
        if((saglik-hasar)>=0)
        {
            saglik=saglik-hasar;
        }
        else{
            saglik=0;
        }
        oluMuyum();
    }

    void oluMuyum()
    {
        if(saglik<=0) oldum=true;
    }
}
