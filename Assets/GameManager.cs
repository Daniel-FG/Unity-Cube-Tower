using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int ballCount = 0;
    public GameObject[] balls;

    private void Start()
    {
        CreateBall();
    }
    private void Update()
    {
        
    }
    public void CreateBall()
    {
        int randomNumber = Random.Range(0, balls.Length);  //隨機生成數字
        Instantiate(balls[randomNumber]);  //產生球
        ballCount++;
    }
}
