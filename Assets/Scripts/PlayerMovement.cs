using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 4f;
    public float jumpHeight;
    private Rigidbody2D Rb;
    public float horizontalMovement = 4f;

    [Header("Jump")]
    [SerializedField] private float jumpForce;

    [SerializedField] private LayerMask whatIsFloor;

    [SerializedField] private Transform floorControler;

    [SerializedField] private Vector3 boxDimensions;

    [SerializedField] private bool inFloor;

    private bool jump = false;
    //animaciones
  [Header("Animation")]
    private Animator animator;


    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();

        //animaciones
        animator = GetComponent<Animator>();

    }
    
 
    void Update()
    { //movimiento y salto
        if (Input.GetKey(KeyCode.D))
        {
            Rb.velocity = new Vector2(+speed, Rb.velocity.y);
            transform.localScale = new Vector3(1.5f, 1.5f, 1);
        }

        if (Input.GetKey(KeyCode.A))
        {
            Rb.velocity = new Vector2(-speed, Rb.velocity.y);
            transform.localScale = new Vector3(-1.5f, 1.5f, 1);

        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Rb.velocity = new Vector2(Rb.velocity.x, +jumpHeight);
        }

        //animaciones 
        
        horizontalMovement = Input.GetAxisRaw("Horizontal") * speed;
        animator.SetFloat("Horizontal",Mathf.Abs(horizontalMovement));

        
    }
    private void FixedUpdate()
    {
        
        animator.SetBool("InFloor", inFloor);
    }
    //plataforma
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            transform.parent = collision.transform;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        transform.parent = null;
    }

  


}




