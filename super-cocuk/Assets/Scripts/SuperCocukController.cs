using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ilkkod : MonoBehaviour
{
	Rigidbody2D player;
	Animator playerAnimator;

	public float moveSpeed = 10f;
    public float jumpSpeed = 10f,jumpFrequency= 1f,nextJumpTime;

    bool facingRight=true; //sağa bakıyor
    public bool isGrounded=false; //zeminde değil

public Transform groundCheckPosition;
public float groundCheckRadius;
public LayerMask groundCheckLayer;

public bool boslukBasiliMi=false;

public GameObject _mermiCikis;
 //public Vector2 mermiYonu = Vector2.right;
public GameObject _mermi;
public float mermiHizi = 10f;
    void Start()
    {
        //print("**Zeynep SERT");
		
		player=this.GetComponent<Rigidbody2D>();
        playerAnimator=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
     
        //print(Input.GetAxis("Horizontal"));
    
        HorizontalMove();
        OnGroundCheck();

	    playerAnimator.SetFloat("playerSpeed",Mathf.Abs(player.velocity.x));
     
        if(player.velocity.x<0 && facingRight) //sola gidiyor
        {
            FlipFace();
        }
        else if(player.velocity.x>0 && !facingRight) //sağa gidiyor
        {
            FlipFace();
        }

        if(Input.GetAxis("Vertical")>0 && isGrounded && (nextJumpTime < Time.timeSinceLevelLoad))
        {
            nextJumpTime = Time.timeSinceLevelLoad+jumpFrequency;
            Jump();
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
             GameObject mermix =Instantiate(_mermi, _mermiCikis.transform.position, Quaternion.identity);

            Rigidbody2D mermiRigidbody = mermix.GetComponent<Rigidbody2D>();
      
         if(facingRight)
            {
           mermiRigidbody.velocity = Vector2.right * mermiHizi;
                
            }
         else
         {
           mermiRigidbody.velocity = Vector2.left * mermiHizi;
            
         }


                            //     player.velocity =  new Vector2(Input.GetAxis("Horizontal")*moveSpeed, player.velocity.y);

        }
    }
	 void FixedUpdate()
	 {

     }

    void HorizontalMove()
    {
        player.velocity =  new Vector2(Input.GetAxis("Horizontal")*moveSpeed, player.velocity.y);
    }
     void FlipFace()
     {
        facingRight=!facingRight;
        Vector3 tempLocalScale=transform.localScale;
        tempLocalScale.x*=-1;
        transform.localScale=tempLocalScale;
     }

     void Jump()
     {
        player.AddForce(new Vector2(0f,jumpSpeed));
        //print("ateş");
     }

     void OnGroundCheck()
      {
        isGrounded=Physics2D.OverlapCircle(groundCheckPosition.position,groundCheckRadius,groundCheckLayer);
        playerAnimator.SetBool("isGroundedAnim",isGrounded);
      }
}

