using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : Ship {

    public int collideDamage;


    public override void DealDamage(int damage)
    {
        HP -= damage;
    }

	public override void OnConflict(GameObject other)
    {
        
    }

}
