using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Controller : MonoBehaviour
{

    public GameObject plane;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        KeyPressed();
        CheckBoundaries();
    }

    void KeyPressed()
    {
        if (Input.GetKeyDown(KeyCode.W) == true)
        {
            plane.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 5f);
        }
        else if (Input.GetKeyDown(KeyCode.S) == true)
        {
            plane.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -5f);
        }
        else if (Input.GetKeyDown(KeyCode.D) == true)
        {
            plane.GetComponent<Rigidbody2D>().velocity = new Vector2(5f, 0f);
        }
        else if (Input.GetKeyDown(KeyCode.A) == true)
        {
            plane.GetComponent<Rigidbody2D>().velocity = new Vector2(-5f, 0f);
        }
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
