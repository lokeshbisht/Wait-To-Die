using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Player : MonoBehaviour
{

    public MovementController movement;

    public float runSpeed = 40f;

    float horizontalMove = 0f;

    public bool jump = false;

    public GameObject pause;

    public GameObject gameOver;

    public GameObject blood;

    bool inside;
    bool leftWall;
    bool rightWall;

    GameObject button;

    // Use this for initialization
    void Start()
    {
        inside = false;
        leftWall = false;
        rightWall = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (leftWall && rightWall)
        {
            FindObjectOfType<AudioManager>().Stop("Theme");
            FindObjectOfType<AudioManager>().Play("Dead");
            Instantiate(blood, transform.position, Quaternion.identity);
            gameOver.SetActive(true);
            FindObjectOfType<BoxScript>().gameOn = false;
            Destroy(gameObject);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            FindObjectOfType<AudioManager>().Pause("Theme");
            Time.timeScale = 0f;
            FindObjectOfType<BoxScript>().gameOn = false;
            pause.SetActive(true);
        }

        if (inside)
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                button.GetComponent<Switch>().ChangeColor();
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            MakeJump();
        }

        horizontalMove = Input.GetAxis("Horizontal");    
    }

    private void FixedUpdate()
    {

        movement.Move(horizontalMove * runSpeed * Time.fixedDeltaTime, jump);
        jump = false;
    }

    public void MakeJump()
    {
        if (transform.rotation.z != 0)
        {

            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        jump = true;

    }
    
    public void Resume()
    {
        FindObjectOfType<AudioManager>().Resume("Theme");
        FindObjectOfType<AudioManager>().Play("Click");
        FindObjectOfType<BoxScript>().gameOn = true;
        pause.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Restart()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        Application.Quit();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Switch"))
        {
            button = collision.gameObject;
            inside = true;
            
            
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Switch"))
        {
            inside = false;

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("LeftWall"))
        {
            leftWall = true;
        }

        if (collision.gameObject.CompareTag("RightWall"))
        {
            rightWall = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("LeftWall"))
        {
            leftWall = false;
        }

        if (collision.gameObject.CompareTag("RightWall"))
        {
            rightWall = false;
        }
    }
}
