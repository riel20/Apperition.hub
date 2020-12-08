using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamaItati : MonoBehaviour 
{

    //プレイヤーオブジェクト
    public GameObject player;
    //弾のプレハブオブジェクト
    public GameObject tama;

    //一秒ごとに弾を発射するためのもの
    public float targetTime = 3.0f;
    public float currentTime = 0;

    public float timer = 7f;


    void Start()
    {

    }


    void Update()
    {
        //X座標取得（自分）
        Vector3 Epos = GameObject.Find("KamaItati").transform.position;
        float Ex = Epos.x;
        //X座標取得（プレイヤー）
        Vector3 EPpos = GameObject.Find("KamaItati").transform.position;
        float Px = Epos.x;

        //プレイヤーを見るように画像回転
        if (Ex <= Px)
        {
            transform.localScale = new Vector3(-1, 1, 1);   //左向き変更
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);   //右向き変更
        }


        //targetTime経つごとに弾を発射する
        currentTime += Time.deltaTime;
        if (targetTime < currentTime)
        {
            currentTime = 0;
            //敵の座標を変数posに保存
            var pos = this.gameObject.transform.position;
            //弾のプレハブを作成
            var t = Instantiate(tama) as GameObject;
            //弾のプレハブの位置を敵の位置にする
            t.transform.position = pos;
            //敵からプレイヤーに向かうベクトルをつくる
            //プレイヤーの位置から敵の位置（弾の位置）を引く
            Vector2 vec = player.transform.position - pos;
            //弾のRigidBody2Dコンポネントのvelocityに先程求めたベクトルを入れて力を加える
            t.GetComponent<Rigidbody2D>().velocity = vec;
        }

    }

}
