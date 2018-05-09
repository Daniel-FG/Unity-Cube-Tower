using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int ballCount = 0;
    public GameObject[] balls;

    private GameObject parent;
    private void Start()
    {
        parent = GameObject.Find("Balls");
        if (parent == null)
        {
            parent = new GameObject("Balls");
        }
        CreateBall();
    }
    private void Update()
    {
        
    }
    public void CreateBall()
    {
        int randomNumber = Random.Range(0, balls.Length);  //隨機生成數字
        GameObject ball = Instantiate(balls[randomNumber]) as GameObject;  //產生球
        ball.transform.parent = parent.transform;
        ballCount++;
    }
}
