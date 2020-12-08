using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour 
{
	Animator animator;

	public Transform attackPount;
	public float attackRadius;
	public LayerMask enemyLayer;
	void Start () 
	{
		animator = GetComponent<Animator>();
	}
	

	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.P))
        {
			animator.SetTrigger("Attack");
		}
	}

	public void Attack()	//攻撃の当たり判定
    {
		Collider2D[] hitEnemys = Physics2D.OverlapCircleAll(attackPount.position, attackRadius, enemyLayer);
		foreach (Collider2D hitEnemy in hitEnemys)
        {
			hitEnemy.GetComponent<EnemyManager>().OnDamage();
        }
    }

	void OnDrawGizmosSelected()		//判定場所デバッグ
    {
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(attackPount.position, attackRadius);
    }
}
