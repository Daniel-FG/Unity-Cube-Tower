using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    //TODO 考慮改成重力往下降
    public MyColor cubeColor;  //方塊顏色

    [SerializeField] private Vector3 biggerScale = new Vector3(1.2f, 1.2f, 1.2f);  //變大之後的scale值
    //private Rigidbody rigidBody;
    private bool hasBall = false;  //方塊內部是否有球
    
    

    private void Start()
    {
        //rigidBody = GetComponent<Rigidbody>();
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();
        if (ball)
        {
            if (cubeColor == ball.ballColor && !hasBall)  //如果撞到一樣顏色而且內部沒有球的話
            {
                Destroy(collision.gameObject);  //摧毀球
                GrowBall();  //讓方塊內部生出球
            }
        }
    }

    void GrowBall()
    {
        //TODO 方塊長出球的動畫
        Transform cubeRenderer = transform.GetChild(0);  //取得方塊的Renderer
        cubeRenderer.localScale = biggerScale;  //讓方塊看起來變大但不讓collider也跟著變大
        hasBall = true;  //內部有球
    }

    private void OnMouseDown()
    {
        //pressed cube
        //TODO 回傳被按下方塊位置給GameManager
        if(hasBall)  //如果內部有球
        {
            Destroy(gameObject);  //點擊之後摧毀該方塊
        }
    }
}
