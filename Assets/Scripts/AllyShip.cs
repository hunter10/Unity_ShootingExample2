using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyShip : Ship, IAlly {

    public static AllyShip Instance;
    public int defenseRate;

    public override void DealDamage(int dam)
    {
        float finalDamage = dam - dam * (defenseRate / 100f);
        HP -= (int)finalDamage;
    }

    public override void OnConflict(GameObject other)
    {
        //if(other.GetComponent<EnemyShip>() != null)
        {
            //HP -= other.GetComponent<EnemyShip>().collideDamage;
        }
    }

    public Weapon thisWeapon { get; set; }
    private int Score;
    public int thisShipScore { 
        get { return Score; }
        set
        {
            Score = value;
            // UIManager 스코어 업데이트
        }
    }
    public void AllyMethod()
    {
        //throw new System.NotImplementedException();    
        Debug.Log(Name + " AllyMethod is called");
    }

    private void OnCollisionEnter(Collision other)
    {
        OnConflict(other.gameObject);
        Debug.Log("This ship conflict with " + other.gameObject);
    }
}
