using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public GameObject[] cubeArray;  //用來存放要產生的不同方塊
    public delegate void OnNewCubes();
    public event OnNewCubes NewCubeCreated;

    private GameManager gameManager;
    //最底層那圈的各個方塊位置
    private Vector3[] bottomArray = { new Vector3(6.3f, 1f, 0f), new Vector3(5.87f, 1f, 2.36f), new Vector3(4.5f, 1f, 4.4f), new Vector3(2.4f, 1f, 5.6f),
        new Vector3(0f, 1f, 6.2f), new Vector3(-2.4f, 1f, 5.6f), new Vector3(-4.5f, 1f, 4.4f), new Vector3(-5.87f, 1f, 2.36f),
        new Vector3(-6.3f, 1f, 0f), new Vector3(-5.87f, 1f, -2.36f), new Vector3(-4.5f, 1f, -4.4f), new Vector3(-2.4f, 1f, -5.6f),
        new Vector3(0f, 1f, -6.2f), new Vector3(2.4f, 1f, -5.6f), new Vector3(4.5f, 1f, -4.4f), new Vector3(5.87f, 1f, -2.36f) };
    private Vector3 yOffset = new Vector3(0f, 2.1f, 0f);  //每次要增加的y值
    private GameObject parent;  //整理用的empty GameObject

    void Start ()
    {
        gameManager = FindObjectOfType<GameManager>();
        parent = GameObject.Find("Cubes");  //尋找名稱為Cubes的GameObject
        if (parent == null)  //如果沒找到就新建一個
        {
            parent = new GameObject("Cubes");
        }
        CreateCubeCircle();  //產生一圈方塊
    }
	
	void Update ()
    {
		
	}

    private void CreateCubeCircle()  //產生一圈方塊函式
    {
        float angle = 0f;  //產生角度
        foreach(Vector3 position in bottomArray)
        {
            int randomNumber = Random.Range(0, cubeArray.Length);  //隨機生成數字
            GameObject blob = Instantiate(cubeArray[randomNumber], position, Quaternion.Euler(0f, angle, 0f)) as GameObject;
            blob.transform.parent = parent.transform;  //將產生的方塊child到整理用的GamoObject
            angle = angle - 22.5f;  //每產生一個方塊之後轉-22.5度
        }
        
        for (int i = GameManager.yRange - 1; i >= 1; i--)
        {
            for (int j = 0; j < GameManager.xRange; j++)
            {
                GameManager.game[j, i] = GameManager.game[j, i - 1];
            }
        }
        for (int i = 0; i < GameManager.xRange; i++)
        {
            GameManager.game[i, 0] = 1;
        }
        gameManager.PrintMatrix();
        NewCubeCreated();
    }
}
