using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public GameObject[] cubeArray;

    private GameManager gameManager;
    private GameObject parent;
    private Vector3 yOffset = new Vector3(0f, 2.1f, 0f);
    private Vector3[] bottomArray = { new Vector3(6.3f, 1f, 0f), new Vector3(5.87f, 1f, 2.36f), new Vector3(4.5f, 1f, 4.4f), new Vector3(2.4f, 1f, 5.6f),
        new Vector3(0f, 1f, 6.2f), new Vector3(-2.4f, 1f, 5.6f), new Vector3(-4.5f, 1f, 4.4f), new Vector3(-5.87f, 1f, 2.36f),
        new Vector3(-6.3f, 1f, 0f), new Vector3(-5.87f, 1f, -2.36f), new Vector3(-4.5f, 1f, -4.4f), new Vector3(-2.4f, 1f, -5.6f),
        new Vector3(0f, 1f, -6.2f), new Vector3(2.4f, 1f, -5.6f), new Vector3(4.5f, 1f, -4.4f), new Vector3(5.87f, 1f, -2.36f) };

    void Start ()
    {
        gameManager = FindObjectOfType<GameManager>();
        parent = GameObject.Find("Cubes");
        if (parent == null)
        {
            parent = new GameObject("Cubes");
        }
        CreateCubeCircle();
	}
	
	void Update ()
    {
		
	}

    private void CreateCubeCircle()
    {
        float angle = 0f;
        foreach(Vector3 position in bottomArray)
        {
            int randomNumber = Random.Range(0, cubeArray.Length);  //隨機生成數字
            GameObject blob = Instantiate(cubeArray[randomNumber], position, Quaternion.Euler(0f, angle, 0f)) as GameObject;
            blob.transform.parent = parent.transform;
            angle = angle - 22.5f;
        }
    }
}
