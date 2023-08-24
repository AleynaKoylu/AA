using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleCircle : MonoBehaviour
{

    LineRenderer lineRenderer;

    bool ballStop = false;

    Rigidbody2D rigidbody2D;

    GameObject MainCircle;

    GameObject GameManager;
    GameManager gameManager;
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        MainCircle = GameObject.FindGameObjectWithTag("MainCircle");
        GameManager = GameObject.FindGameObjectWithTag("GameManager");
        gameManager = GameManager.GetComponent<GameManager>();


    }

    
    void Update()
    {
        BallStop();
        
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
            rigidbody2D.velocity = Vector2.zero;
            gameObject.transform.SetParent(MainCircle.transform);
            ballStop = true;
            gameManager.UpdateBallsPosition();
            print("Degdi");
        }
        else if (collision.gameObject.CompareTag("LittleCircle"))
        {
            gameManager.Lose();
            print("Kaybettin");
        }
    }
}
