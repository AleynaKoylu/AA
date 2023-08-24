using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleCircle : MonoBehaviour
{

    LineRenderer lineRenderer;

    bool ballStop = false;

    Rigidbody2D rb;

    GameObject MainCircle;

    GameObject GameManager;
    GameManager gameManager;

    int ballNo;
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        rb = GetComponent<Rigidbody2D>();
        MainCircle = GameObject.FindGameObjectWithTag("MainCircle");
        GameManager = GameObject.FindGameObjectWithTag("GameManager");
        gameManager = GameManager.GetComponent<GameManager>();


    }

    
    void Update()
    {
        BallStop();

        ChangeScale();

    }
    void ChangeScale()
    {
        ballNo = gameManager.numberBall;
        if (ballNo >= 12 && ballNo <= 16)
        {
           transform.localScale = new Vector3(0.35f, 0.35f, 0.35f);
        }
        else if (ballNo > 16 && ballNo <= 20)
        {

           transform.localScale = new Vector3(0.30f, 0.30f, 0.30f);

        }
        else if (ballNo > 20 && ballNo <= 24)
        {

           transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);

        }
      
    }
    void BallStop()
    {
        if (ballStop == true)
        {
            lineRenderer.SetPosition(0, MainCircle.transform.position);
            lineRenderer.SetPosition(1, gameObject.transform.position);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == MainCircle)
        {
            rb.velocity = Vector2.zero;
            gameObject.transform.SetParent(MainCircle.transform);
            ballStop = true;
            gameManager.UpdateBallsPosition();
           
        }
        else if (collision.gameObject.CompareTag("LittleCircle"))
        {
            gameManager.Lose();
          
        }
    }
}
