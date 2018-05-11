using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int ballCount = 0;
    public const int xRange = 16;  //一整圈有16個方塊
    public const int yRange = 12;  //排滿整座塔有12個方塊  第13個造成遊戲結束
    public static int[,] game = new int[xRange, yRange];  //代表遊戲的二維陣列  實質類別預設為0
    public GameObject[] balls;  //用來存放要產生的不同種類的球
    
    private GameObject parent;  //整理用的empty GameObject
    private Tower tower;

    private void Awake()
    {
        //print("Intial matrix:");
        ////game[3, 11] = 1;
        //PrintMatrix();
    }
    private void Start()
    {
        //TODO 重新思考委派結構 目前結構沒必要
        tower = FindObjectOfType<Tower>();
        tower.NewCubeCreated += CheckHeight;  //將CheckHeight()加入委派清單

        parent = GameObject.Find("Balls");  //尋找名稱為Balls的GameObject
        if (parent == null)  //如果沒找到就新建一個
        {
            parent = new GameObject("Balls");
        }
        CreateBall();  //建立第一顆球
    }
    
    public void CreateBall()  //產生球函式
    {
        int randomNumber = Random.Range(0, balls.Length);  //隨機生成數字
        GameObject ball = Instantiate(balls[randomNumber]) as GameObject;  //產生球
        ball.transform.parent = parent.transform;  //將產生的球child到新建的空GamoObject
        ballCount++;  //產生球數+1
    }

    public void PrintMatrix()  //列印出由上到下 (塔的觀點) 的二維陣列
    {
        for(int i = yRange - 1; i >= 0; i--)
        {
            print(game[0, i] + " " + game[1, i] + " " + game[2, i] + " " + game[3, i] + " " + game[4, i] + " " + game[5, i] + " " + game[6, i]
                 + " " + game[7, i] + " " + game[8, i] + " " + game[9, i] + " " + game[10, i] + " " + game[11, i] + " " + game[12, i] + " " + game[13, i]
                  + " " + game[14, i] + " " + game[15, i]);
        }
        print("=======================");
    }


    private void CheckHeight()  //檢查高度是否造成遊戲結束
    {
        for(int i = 0; i < xRange; i++)
        {
            if (game[i, 12] != 0)  //如果最上方有值則造成遊戲結束
            {
                Debug.Log("Game Over");
            }
        }
    }
}
