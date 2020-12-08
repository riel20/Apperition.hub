using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{

    public float Speed;     //移動速度
    public float jumpForce; //ジャンプ力
    private bool isGround;  //接地判定

    Rigidbody2D rb2d;


    public string State;                // プレイヤーの状態管理

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

    }


    void Update()
    {
        Move();     //移動
        JumpMove();     //ジャンプ
    }

    void Move()     //移動メソッド
    {
        float xSpeed = 0.0f;
        if(Input.GetKeyDown(KeyCode.LeftShift))     //走る
        {
            Speed += 3;
        }
        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            Speed -= 3;
        }

        if (Input.GetKey(KeyCode.A))    //左
        {
            transform.localScale = new Vector3(-1, 1, 1);   //左向き変更
            xSpeed = -Speed;
            State = "RUN";

        }
        else if (Input.GetKey(KeyCode.D))   //右
        {
            transform.localScale = new Vector3(1, 1, 1);    //右向き変更
            xSpeed = Speed;
            State = "RUN";
        }
        else   //止
        {
            xSpeed = 0.0f;
            State = "IDLE";
        }
        rb2d.velocity = new Vector2(xSpeed, rb2d.velocity.y);

    }

    void JumpMove()     //ジャンプメソッド
    {
        if (isGround == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))    //spaceキーでジャンプ
            {
                this.rb2d.AddForce(transform.up * this.jumpForce);
                isGround = false;
            }
        }
        if (rb2d.velocity.y > 0)     //上昇
        {
            State = "JUMP";
            isGround = false;
        }
        if (rb2d.velocity.y < 0)    //降下
        {
            State = "FALL";
            isGround = false;
        }
    }



    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")   //地面との当たり判定
        {
            isGround = true;    //接地しているときtrue
        }
    }
}
