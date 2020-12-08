using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapPlayer : MonoBehaviour 
{

    public float speed;     //進むスピード

    // GameObjectを保持する配列の生成
    GameObject[] array = new GameObject[3];

    public string State;        //ステージの状態
    public bool flag = false;
    public int StageCount = 0;           //移動先管理
    public bool Move = true;    //移動可能か判定

    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        array[0] = GameObject.Find("Stage_1");
        array[1] = GameObject.Find("Stage_2");
        array[2] = GameObject.Find("Stage_3");
    }


    void Update()
    {
        //targetというオブジェクトまでstepという時間で向かう
        float step = speed * Time.deltaTime;
        if (Move == true)
        {
            if (StageCount >= 1)
            {
                if (Input.GetKeyDown(KeyCode.A))
                {
                    StageCount -= 1;
                    flag = !flag;
                    transform.localScale = new Vector3(-3, 3, 1);   //右向き変更
                }
            }
            if (StageCount <= 1)
            {
                if (Input.GetKeyDown(KeyCode.D))
                {
                    StageCount += 1;
                    flag = !flag;
                    transform.localScale = new Vector3(3, 3, 1);   //左向き変更
                }
            }

        }

        //移動処理
        transform.position = Vector3.MoveTowards
                    (transform.position, array[StageCount].transform.position, step);


        //移動中操作を不可にする 配列のオブジェクトと同じポジションで移動可能
        if (gameObject.transform.position == array[StageCount].transform.position)
        {
            Move = true;
        }
        else
        {
            Move = false;
        }


        //Enterで対応したシーンをロード
        if(Input.GetKeyDown(KeyCode.Return) && Move == true)
        {
            SceneManager.LoadScene(StageCount + 1);
        }

        if(Move == false)
        {
            animator.SetBool("Run", true);
        }
        else if(Move == true)
        {
            animator.SetBool("Run", false);
        }
    }
}
