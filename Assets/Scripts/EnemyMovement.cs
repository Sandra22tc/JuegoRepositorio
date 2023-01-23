using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{


    public float speed;
    public bool isRight;

    public float timer;
    public float timeForChange = 4f;
    
  


    void Start()
    {
        timer = timeForChange;
    }

 
    void Update()
    {
       if (isRight== true)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (isRight == false)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            transform.localScale = new Vector3(1, 1, 1);
        }

        timer -= Time.deltaTime; 
        if(timer <= 0)
        {
            timer = timeForChange;
            isRight = !isRight; 
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }




}



