using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public GameObject ObjectToMove;

    public Transform StartPoint;
    public Transform EndPoint;

    public float velocity;

    private Vector3 MoveTo;

    public float scaleFactor = 1.5f;

    void Start()
    {
        MoveTo = EndPoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        ObjectToMove.transform.position = Vector3.MoveTowards(ObjectToMove.transform.position, MoveTo, velocity * Time.deltaTime);

        if (ObjectToMove.transform.position == EndPoint.position)
        {
            MoveTo = StartPoint.position;
        }

        if (ObjectToMove.transform.position == StartPoint.position)
        {
            MoveTo = EndPoint.position;
        }

        {
            transform.localScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);

        }
    }
}

