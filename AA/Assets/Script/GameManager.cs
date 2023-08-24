using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{

    [SerializeField]
    GameObject LittleCircle;
    int numberBall;
    List<Rigidbody2D> Balls = new List<Rigidbody2D>();

    float ballSpeed=20f;

    float firstBallYPosition = -3f;

    [SerializeField]
    TextMeshProUGUI LevelTxt;

    int lvl;

    void Start()
    {

        LevelControl();
        AddedFirstBalls();
    }
    void LevelControl()
    {
        if(PlayerPrefs.HasKey("lvl"))
        {
            lvl = PlayerPrefs.GetInt("lvl");

        }
        else
        {
            lvl = 1;
            PlayerPrefs.SetInt("lvl", lvl);
        }
        LevelTxt.text = lvl.ToString();
    }
    void AddedFirstBalls()
    {
        numberBall = lvl * 3;
        for(int i = 0; i < numberBall; i++)
        {

            GameObject yBall = Instantiate(LittleCircle);

            if (i == 0)
            {
                yBall.transform.position = new Vector2(0, firstBallYPosition);
            }
            else
            {
                yBall.transform.position = new Vector2(0, Balls[i-1].gameObject.transform.position.y-(Balls[i-1].GetComponent<CircleCollider2D>().bounds.size.y*1.5f));
            }
            yBall.GetComponentInChildren<TextMeshProUGUI>().text = (numberBall - i).ToString() ;
            Balls.Add(yBall.GetComponent<Rigidbody2D>());
        }

        

    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0)&&Balls.Count>0)
        {
            Balls[0].velocity=Vector2.up*ballSpeed;
            Balls.RemoveAt(0);
            
        }
        else if (Balls.Count <= 0)
        {
            Win();
            print("Bitti");
        }
    }
    public void UpdateBallsPosition()
    {
        for (int i = 0; i < Balls.Count; i++)
        {
            if (i == 0)
            {
                Balls[i].gameObject.transform.position = new Vector2(0, firstBallYPosition);
            }
            else
            {
                Balls[i].gameObject.transform.position = new Vector2(0, Balls[i - 1].gameObject.transform.position.y - (Balls[i - 1].GetComponent<CircleCollider2D>().bounds.size.y * 1.5f));
            }
        }
    }
    void Win()
    {
       
    }
    public void Lose()
    {

    }
}
