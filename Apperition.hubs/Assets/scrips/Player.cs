using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{

    Rigidbody2D rigi2D;
    Animator animator;
    float jumpForce = 700.0f;
    float walkForce = 30.0f;
    float maxWalkSpeed = 5.0f;


    // Use this for initialization
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        this.rigi2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //斬る
        if (Input.GetKeyDown(KeyCode.Space) && this.rigi2D.velocity.y == 0)
        {
            this.animator.SetTrigger("kiruTrigger");
        }

        //左右移動
        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow)) key = 1;
        if (Input.GetKey(KeyCode.LeftArrow)) key = -1;

        //プレイヤーの速度
        float speedx = Mathf.Abs(this.rigi2D.velocity.x);

        //スピード制限
        if (speedx < this.maxWalkSpeed)
        {
            this.rigi2D.AddForce(transform.right * key * this.walkForce);
        }



        //反転対策
        if (key != 0)
        {
            transform.localScale = new Vector3(key, 1, -1);
        }

        //プレイヤの速度に応じてアニメーション速度を変える
        if (this.rigi2D.velocity.y == 0)
        {
            this.animator.speed = speedx / 4.0f;
        }
        else
        {
            this.animator.speed = 1.0f;
        }

    }
}