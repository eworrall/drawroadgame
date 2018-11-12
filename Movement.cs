using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Movement : MonoBehaviour {
    private Rigidbody2D rb;
    public float speed;
    public Transform road;
    public Transform car;
    private RaycastHit hit;
    public Transform to1;
    public Transform to2;
    public Transform initial;
    public float rotationspeed;
    private scoreScript thescoremanager;
    public string menuScene;
    public Button right;
    public Button left;
    float sensitivity = 3f;
    float movementt = 0f;
    public float maxSpeed = 2001111111111111111111111f;
    public float acceleration = 11111111111111111111111111111111115f;
    public float moveHorizontal = 0;
    public GameObject coin;
    //public float rotationSpeed;
    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        thescoremanager = FindObjectOfType<scoreScript>();
    }

    // Update is called once per frame
    void FixedUpdate() {
        //float moveHorizontal = Input.GetAxis("Horizontal");
        if (Input.touchCount >= 1)
        {
            Vector2 touchPosition = Input.GetTouch(0).position;
            if (touchPosition.x < Screen.width / 2 && moveHorizontal > (maxSpeed * -1))
            {
                if (moveHorizontal > 0)
                {
                    moveHorizontal = 0;
                }
                moveHorizontal -= acceleration * Time.deltaTime;
                transform.rotation = Quaternion.Slerp(transform.rotation, to2.rotation, Time.deltaTime / (rotationspeed));

            }
            else if (touchPosition.x > Screen.width / 2 && moveHorizontal < maxSpeed)
            {
                if (moveHorizontal < 0)
                {
                    moveHorizontal = 0;
                }
                moveHorizontal += acceleration * Time.deltaTime;
                transform.rotation = Quaternion.Slerp(transform.rotation, to1.rotation, Time.deltaTime / (rotationspeed));
            }
            else
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, initial.rotation, Time.deltaTime / 0.1f);
            }
            movementt = Mathf.MoveTowards(0f, 1f, 10 * Time.deltaTime);
        }
        else
        {
            if (moveHorizontal < 0)
            {
                moveHorizontal += acceleration * Time.deltaTime;
            } else if (moveHorizontal > 0)
            {
                moveHorizontal -= acceleration * Time.deltaTime;
            }
            //moveHorizontal = 0;
        }
        //float moveVertical = Input.GetAxis("Vertical");
        /* if (Input.GetMouseButtonDown(0))
        {
            Ray xpos = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(xpos, out hit))
            {
                moveHorizontal = hit.point.x;
            }
        } */ //try to get this to work

        Vector3 movement = new Vector3(moveHorizontal, 1.0f, 0.0f);

        if (Input.GetKey("right"))
        {
            //gradually move trail like 0.25f (so it stays in the middle of the 'path')
            if (moveHorizontal < 0)
            {
                moveHorizontal = 0;
            }
            moveHorizontal += acceleration * Time.deltaTime;
            transform.rotation = Quaternion.Slerp(transform.rotation, to1.rotation, Time.deltaTime / rotationspeed);
        }
        else if (Input.GetKey("left"))
        {
            //gradually move trail like -0.25f (so it stays in the middle of the 'path')
            transform.rotation = Quaternion.Slerp(transform.rotation, to2.rotation, Time.deltaTime / rotationspeed);
        }
        else
        {
            //gradually move trail back to 0 (so it stays in the middle of the 'path')
            transform.rotation = Quaternion.Slerp(transform.rotation, initial.rotation, Time.deltaTime / 0.1f);
        }

        rb.velocity = (movement * speed);
    }

    public void turnRight()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, to1.rotation, Time.deltaTime / rotationspeed);
    }

    public void turnLeft()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, to2.rotation, Time.deltaTime / rotationspeed);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("collideBox") || collision.gameObject.CompareTag("wall"))
        {
            transform.gameObject.SetActive(false); //add animation instead of it just disappearing
            thescoremanager.scoreisincreasing = false;
        } else if (collision.gameObject.CompareTag("coin"))
        {
            //set coin active false
            //coinCount += 1
        }
    }
}
