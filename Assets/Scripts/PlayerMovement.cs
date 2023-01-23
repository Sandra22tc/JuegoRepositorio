using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 4f;
    public float jumpHeight;
    public Rigidbody2D Rb;

    //animaciones
    public Animator anim;


    void Start()
    {
      
        //animaciones
        anim= GetComponent<Animator>();

    }


    void Update()
    { //movimiento y salto
        if (Input.GetKey(KeyCode.D))
        {
            Rb.velocity = new Vector2(+speed, Rb.velocity.y);
            transform.localScale = new Vector3(1.5f, 1.5f, 1);

            anim.SetBool("IsRunning", true);

        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            anim.SetBool("IsRunning", false);
        }

        if (Input.GetKey(KeyCode.A))
        {
            Rb.velocity = new Vector2(-speed, Rb.velocity.y);
            transform.localScale = new Vector3(-1.5f, 1.5f, 1);

            anim.SetBool("IsRunning", true);

        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            anim.SetBool("IsRunning", false);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);

            anim.SetBool("InFloor", true);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {

            anim.SetBool("InFloor", false);
        }

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





