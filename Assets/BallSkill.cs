using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSkill : MonoBehaviour
{
    private Rigidbody2D ball_rigid;
    public Vector2 start;
    public Vector2 testvec;//彈珠飛行過程的向量

    void Start()
    {
        this.ball_rigid = GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
        testvec = ball_rigid.velocity;//計算向量

        if (Input.GetKey(KeyCode.A))//把彈珠發射出去的測試力道
        {
            ball_rigid.AddForce(start, ForceMode2D.Impulse);
        }
        if (Input.GetKey(KeyCode.X))//加速彈珠
        {
            ball_rigid.velocity = 2 * testvec;
        }
        if (Input.GetKey(KeyCode.V))//減速彈珠
        {
            ball_rigid.velocity = 0.4f * testvec;
        }
    }
    
}