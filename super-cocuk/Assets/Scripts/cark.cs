using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cark : MonoBehaviour
{
    public Rigidbody2D _rigidBody;
    public float rotationSpeed = 50f;
    void Start()
    {
        _rigidBody= GetComponent<Rigidbody2D>();
        _rigidBody.AddForce(new Vector2(30,0));
       
    }

    // Update is called once per frame
    void Update()
    {
           transform.Rotate(0,0,rotationSpeed);
    }
}
