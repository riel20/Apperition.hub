using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimetion : MonoBehaviour
{

	string state;		//状態管理
	string prevState;
	GameObject Player;  //親オブジェクト
	PlayerController PlayerCon;     //親のスクリプト

	Animator animator;
	public bool TransformAnime;		//変身管理

	void Start()
	{
		Player = GameObject.Find("Player");
		PlayerCon = Player.GetComponent<PlayerController>();		//プレイヤー(親)のスクリプト
		animator = GetComponent<Animator>();


		TransformAnime = false;		//ロード時に変身アニメーションが出ないようにする
	}



	void Update()
	{
		state = PlayerCon.State;		//親の状態取得
		if (TransformAnime == true)
		{
			animator.SetBool("Transform", true);
		}
		if (TransformAnime == false)
		{
			//プレイヤーの状態に応じてアニメーション
			if (prevState != state)
			{
				switch (state)
				{
					case "IDLE":    //待機
						animator.SetBool("Idle", true);
						animator.SetBool("Fall", false);
						animator.SetBool("Run", false);
						animator.SetBool("Jump", false);
						break;
					case "JUMP":    //ジャンプ
						animator.SetBool("Jump", true);
						animator.SetBool("Fall", false);
						animator.SetBool("Run", false);
						animator.SetBool("Idle", false);
						break;
					case "FALL":    //落下
						animator.SetBool("Fall", true);
						animator.SetBool("Jump", false);
						animator.SetBool("Run", false);
						animator.SetBool("Idle", false);
						break;
					case "RUN":     //走る
						animator.SetBool("Run", true);
						animator.SetBool("Fall", false);
						animator.SetBool("Jump", false);
						animator.SetBool("Idle", false);
						break;
				}
				// 状態の変更を判定するために状態を保存しておく
				prevState = state;
			}
		}
	}
	void OnEnable()		//オブジェクトのアクティブを検知
	{
		TransformAnime = true;
	}

	void EndTransform()			//Transformアニメーション終了時イベントで呼び出す
	{
		animator.SetBool("Transform", false);
		TransformAnime = false;
	}
}