using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class Player1Controller : MonoBehaviour
{

    public GameObject plane;

    public Player Player;

    private float speed = 6f;


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
        if (Input.GetKeyDown(KeyCode.UpArrow) == true)
        {
            plane.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, speed);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) == true)
        {
            plane.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -speed);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) == true)
        {
            plane.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0f);
            plane.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) == true)
        {
            plane.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0f);
            plane.transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            Player.Shoot();
        }
        
    }

    void CheckBoundaries()
    {
        if (plane.transform.position.y > 4.5)
        {
            plane.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -speed);
            //plane.transform.position = new Vector2(plane.transform.position.x, 4);
        }

        else if (plane.transform.position.y < -4.5)
        {
            plane.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, speed);
        }

        if (plane.transform.position.x < -8.5)
        {
            plane.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0f);
        }

        else if (plane.transform.position.x > 8.5)
        {
            plane.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -speed);
        }
    }
}
