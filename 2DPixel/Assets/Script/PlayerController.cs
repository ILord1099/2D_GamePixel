using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
     Vector2 vel;
     public float speed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
       Move();
    }



    public void Move()
    {
        vel = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")); 
        rb.linearVelocity = speed * vel;
          
    }
}
