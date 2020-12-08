using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour 
{
	public int hp;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	public void OnDamage()
	{
		hp -= 1;
	}
}
