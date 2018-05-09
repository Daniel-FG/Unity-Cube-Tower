using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int ballCount = 0;
    public GameObject[] balls;  //用來存放要產生的不同種類的球

    private GameObject parent;  //整理用的empty GameObject
    private void Start()
    {
        parent = GameObject.Find("Balls");  //尋找名稱為Balls的GameObject
        if (parent == null)  //如果沒找到就新建一個
        {
            parent = new GameObject("Balls");
        }
        CreateBall();  //建立第一顆球
    }
    private void Update()
    {
        
    }
    public void CreateBall()  //產生球函式
    {
        int randomNumber = Random.Range(0, balls.Length);  //隨機生成數字
        GameObject ball = Instantiate(balls[randomNumber]) as GameObject;  //產生球
        ball.transform.parent = parent.transform;  //將產生的球child到新建的空GamoObject
        ballCount++;  //產生球數+1
    }
}
