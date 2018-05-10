using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public MyColor ballColor;  //球的顏色
    public float fallingSpeed = 1f;  //落下速度

    private GameManager gameManager;
    private Rigidbody ball;
    private bool isFreeBall = true;  //是否為自由球  有自己的落下速度
    

    private void Start()
    {
        ball = GetComponent<Rigidbody>();
        gameManager = FindObjectOfType<GameManager>();
        ball.useGravity = false;  //有自己的落下速度  不使用重力
        //InvokeRepeating("Drop", 0f, Time.deltaTime);  //球一產生即用固定速度掉落
    }

    private void FixedUpdate()
    {
        if(ball.velocity.y != fallingSpeed)  //使用物理引擎給落下速度
        {
            ball.velocity = new Vector3(0f, -fallingSpeed, 0f);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        //TODO 需要考慮與兩側下方collider碰撞的結果
        Vector3 direction = collision.transform.position - transform.position;  //從球到碰撞到的collider其GameObject的方向向量
        if (Vector3.Dot(Vector3.down, direction) > 0)  //如果方向向量與球落下的方向內積是正數則在下方
        {
            //TODO 考慮加入撞擊後擠壓動畫
            if (isFreeBall)
            {
                gameManager.CreateBall();
                ball.useGravity = true;  //球下方碰到東西之後即受重力控制  不再保有固定落下速度
            }
            isFreeBall = false;  //不是能控制的球了
        }
        if (Vector3.Dot(Vector3.down, direction) == 0)  //如果方向向量與球落下的方向內積是零則在旁邊
        {
            print("Side");
        }
    }

    //private void Drop()  //落下函式
    //{
    //    //TODO 可新增球旋轉動畫
    //    transform.Translate(Vector3.down * fallingSpeed);
    //}
}
