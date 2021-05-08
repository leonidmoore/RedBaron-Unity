using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour
{
    public GameObject plane;
    // Start is called before the first frame update
    void Start()
    {
        RandomMovement();
    }

    // Update is called once per frame
    void Update()
    {
        CheckBoundaries();
    }

    void RandomMovement()
    {
        plane.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 5f);
    }
    void CheckBoundaries()
    {
        if (plane.transform.position.y > 4.5)
        {
            plane.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -5f);
            //plane.transform.position = new Vector2(plane.transform.position.x, 4);
        }

        else if (plane.transform.position.y < -4.5)
        {
            plane.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 5f);
        }

        if (plane.transform.position.x < -8.5)
        {
            plane.GetComponent<Rigidbody2D>().velocity = new Vector2(5f, 0f);
        }

        else if (plane.transform.position.x > 8.5)
        {
            plane.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -5f);
        }
    }
}
