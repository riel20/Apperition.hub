using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IttanMomeni : MonoBehaviour 
{

    //座標を再計算しても良いかの判定
    private bool bl = true;

    //移動先の座標
    private Vector3 pos;

    //x座標代入用
    private float x;

    //z座標代入用
    private float y;

    //移動する速度
    private float speed = 2f;

    //移動範囲計算用
    //X
    private float a = 5;
    //Y
    private float b = 1;

    void Start()
    {
        //Randomな値を代入する
        x = Random.Range(-a, a);
        y = Random.Range(-b, b);

        //↑で出た値を座標に代入する
        pos = new Vector3(x, y, transform.position.z);
    }


    void Update()
    {
        //移動するときの速度用
        float step = speed * Time.deltaTime;

        //座標をpos座標へstepの速度で移動させる
        transform.position = Vector3.MoveTowards(transform.position, pos, step);

        //座標の再計算を行ってよく、座標が目的地に着いた時
        if (bl == true && transform.position == pos)
        {
            //2秒後再計算を行う
            Invoke("Idou", 3f);
            //毎フレーム計算しない様に判定を変える
            bl = false;
        }
    }

    void Idou()
    {
        //移動するときの値への減少率を計算
        float xp = 1f - System.Math.Abs(transform.position.x) / 5f;
        float yp = 1f - System.Math.Abs(transform.position.y) / 5f;

        //x座標が中心より大きい時（中央より右側へ行ったとき
        if (transform.position.x > 0)
        {
            //右側へ移動する範囲にのみ減少率を掛けRandomな値を計算する
            x = Random.Range(-a, a * xp);
        }
        //x座標が中心より小さい時(中央より左側へ行ったとき
        else
        {
            //左側へ移動する範囲にのみ減少率を掛けRandomな値を計算する
            x = Random.Range(-a * xp, a);
        }

        //y座標ver(以下略
        if (transform.position.y > 0)
        {
            y = Random.Range(-b, b * yp);
        }
        else
        {
            y = Random.Range(-b * yp, b);
        }

        //目的地座標posに計算結果の値を代入する
        pos = new Vector3(x, y, transform.position.z);

        //再計算をしてもよい判定を付ける
        bl = true;
    }
}
