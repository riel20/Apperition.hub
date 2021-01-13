using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class title_light : MonoBehaviour
{
    public float speed = 1.0f;
    private Text text;
    private float time;

    private void Start()
    {
        text = this.gameObject.GetComponent<Text>();
    }

    void Update()
    {
        text.color = GetAlphaColor(text.color);
    }


    Color GetAlphaColor(Color color)
    {
        time += Time.deltaTime * 5.0f * speed;
        color.a = Mathf.Sin(time);

        return color;
    }
}