using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mermi : MonoBehaviour
{
    public float zarar=50f;
    public float omur=3f;
    // Start is called before the first frame update
    void Start()
    {
       Destroy(gameObject,omur);
    }

    // Update is called once per frame
    void Update()
    {
        //   transform.position+=new Vector3(0.05f,0.0f,0.0f);
    }
}
