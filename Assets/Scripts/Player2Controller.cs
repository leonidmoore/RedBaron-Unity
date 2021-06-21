using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player2Controller : MonoBehaviour
{
    public GameObject plane;

    public Player1Controller Player1Controller;

    public Player Player;

    private float speed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        RandomMovement();
    }

    // Update is called once per frame
    void Update()
    {
        CheckBoundaries();
        if (SceneManager.GetActiveScene().name == "Game3")
        {
            Chase();
        }
    }

    void RandomMovement()
    {
        if (SceneManager.GetActiveScene().name == "Game1" || SceneManager.GetActiveScene().name == "Game2")
        {
            plane.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, speed);
        }
        else
        {
            Chase();
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
        
        Player.Shoot();
    }

    void Chase()
    {
        /*
        if (plane.transform.position.y < Player1Controller.plane.transform.position.y)
        {
            StartCoroutine(ExecuteAfterTime(0.25f, "UP"));
        }

        else if (plane.transform.position.y > Player1Controller.plane.transform.position.y)
        {
            StartCoroutine(ExecuteAfterTime(0.25f, "DOWN"));
        }*/

        if ((plane.transform.position.y < Player1Controller.plane.transform.position.y) && (plane.transform.position.x > Player1Controller.plane.transform.position.x))
        {
            StartCoroutine(ExecuteAfterTime(0.25f, "LEFT and UP"));
        }


        else if ((plane.transform.position.y < Player1Controller.plane.transform.position.y) && (plane.transform.position.x < Player1Controller.plane.transform.position.x))
        {
            StartCoroutine(ExecuteAfterTime(0.25f, "RIGHT and UP"));
        }

        else if ((plane.transform.position.y > Player1Controller.plane.transform.position.y) && (plane.transform.position.x > Player1Controller.plane.transform.position.x))
        {
            StartCoroutine(ExecuteAfterTime(0.25f, "LEFT and DOWN"));
        }

        else if ((plane.transform.position.y > Player1Controller.plane.transform.position.y) && (plane.transform.position.x < Player1Controller.plane.transform.position.x))
        {
            StartCoroutine(ExecuteAfterTime(0.25f, "RIGHT and DOWN"));
        }
    }
    IEnumerator ExecuteAfterTime(float time, string direction)
    {
        yield return new WaitForSeconds(time);

        
        if (direction == "UP")
        {
            plane.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, speed);
        }

        else if (direction == "DOWN")
        {
            plane.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, -speed);
        }

        else if (direction == "LEFT and UP")
        {
            plane.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, speed);
            plane.transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        else if (direction == "LEFT and DOWN")
        {
            plane.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, -speed);
            plane.transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        else if (direction == "RIGHT and UP")
        {
            plane.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, speed);
            plane.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        else if (direction == "RIGHT and DOWN")
        {
            plane.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, -speed);
            plane.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
