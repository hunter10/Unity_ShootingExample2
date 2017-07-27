using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : Ship {

    public int collideDamage = 3;
    public int scoreAdd = 10;


    public override void DealDamage(int damage)
    {
        Debug.Log("EnemyShip... DealDamage " + damage);
        HP -= damage;
        if (HP <= 0)
            Death();
    }

    public void Death()
    {
        GameManager.Instance.AddScore(scoreAdd);
    }

	public override void OnConflict(GameObject other)
    {
        
    }

}
