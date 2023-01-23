using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastJump : MonoBehaviour
{
    bool booler;

    RaycastHit2D rchit;
    [SerializeField] float distance;


    private void Update()
    {
        rchit = Physics2D.Raycast(gameObject.transform.position, Vector2.down, distance);
        if(rchit.collider != null)
        {
            Debug.DrawRay(gameObject.transform.position, Vector2.down * distance, Color.green);
            booler = true;
        }
        
        if(rchit.collider == null)
        {
            Debug.DrawRay(gameObject.transform.position, Vector2.down * distance, Color.red);
            booler = false;
        }

        if (booler)
        {
            if(booler == true)
            {
                
            }
        }


    }

}
