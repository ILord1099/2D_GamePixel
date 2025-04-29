using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
     private Rigidbody2D rb;
     Vector2 vel;
     public float speed;
     public float jumpForce;
     
     
     public Transform skin;
     public Transform floorCollider;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       
      Move();
        if (Input.GetButtonDown("Jump") && floorCollider.GetComponent<FloorCollider>().canJump == true)
        {
            skin.GetComponent<Animator>().Play("JumpAnim",-1);
            rb.linearVelocity = Vector2.zero;
            floorCollider.GetComponent<FloorCollider>().canJump = false;
            rb.AddForce(new Vector2(0, jumpForce*100f));
       
        }
    }

    public void Move()
    {
        vel = new Vector2(Input.GetAxisRaw("Horizontal") * speed*2, rb.linearVelocity.y);

        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            skin.localScale = new Vector3(Input.GetAxisRaw("Horizontal"),1, 1);
            skin.GetComponent<Animator>().SetBool("PlayerRun",true);
        }
        else
        {
            skin.GetComponent<Animator>().SetBool("PlayerRun",false);
        }
    }
   
  private void FixedUpdate()
    {
        rb.linearVelocity = vel;
    }
}
