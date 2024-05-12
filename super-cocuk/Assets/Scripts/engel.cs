using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class engel : MonoBehaviour
{
    public float saglik=100f; //engelin sağlğı
    public float hasar=25f; //engele çarpıldığında alınacak hasar
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Player")
        {
            //print("1"+other.name);
            other.GetComponent<SuperCocukManager>().HasarAl(hasar);
        }
         else if(other.tag=="mermi")
        {
            HasarAl(other.GetComponent<Mermi>().zarar);
            Destroy(other.gameObject);
        }
    }
     private void OnTriggerStay2D(Collider2D other)
    {
        // print("2"+other.name);
    }
     private void OnTriggerExit2D(Collider2D other )
    {
      //   print("3"+other.name);
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
       if(saglik<=0) Destroy(gameObject);

    }
}
