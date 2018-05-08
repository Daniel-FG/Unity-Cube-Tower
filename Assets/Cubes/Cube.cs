using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private Vector3 bigSize = new Vector3(1.2f, 1.2f, 1.2f);
    private Rigidbody rigidBody;
    private bool hasBall = false;  //方塊內部是否有球
    

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(gameObject.layer == collision.gameObject.layer && !hasBall)  //如果撞到一樣顏色而且內部沒有球的話
        {
            Destroy(collision.gameObject);  //摧毀球
            GrowBall();  //讓方塊內部生出球
        }
    }

    void GrowBall()
    {
        //TODO 方塊長出球的動畫
        Transform cubeRenderer = transform.GetChild(0);  //取得方塊的Renderer
        cubeRenderer.localScale = bigSize;  //讓方塊看起來變大但不讓collider也跟著變大
        hasBall = true;  //內部有球
    }

    private void OnMouseDown()
    {
        //pressed cube
    }
}
