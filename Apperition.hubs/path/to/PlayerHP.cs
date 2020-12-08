using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour 
{

    Slider slider;
    int hp = 100;

    void Start()
    {
        slider = GameObject.Find("Slider").GetComponent<Slider>();
    }



    void Update()
    {
        slider.value = hp;      //スライダーとHPの紐づけ
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")        //Enemyタグに当たり判定
        {
            hp -= 10;
        }
    }
}
