using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Classes : MonoBehaviour {
}

public abstract class Ship : MonoBehaviour
{
    public int MaxHP;
    public int HP;
    public string Name;

    public abstract void DealDamage(int damage);
    public abstract void OnConflict(GameObject other);
}

public enum Weapon
{
    None, Bullet, Missile, Rocket, Laser
}

public interface IAlly
{
    Weapon thisWeapon { get; }
    int thisShipScore { get; }
    void AllyMethod();
}

[System.Serializable]
public class Stat
{
    public int HP;
    public int MaxHP;
    public int defence;
    public Stat Clone()
    {
        return (Stat)MemberwiseClone();
    }
}

public abstract class WeaponClass
{
    public Weapon weaponSort;
    public float damage;
    public GameObject weaponObj;

    public virtual void WeaponFunc(GameObject enemyObj)
    {
        Debug.Log("This is weapon's general function");
        enemyObj.GetComponent<EnemyShip>().DealDamage((int)damage);
    }
}

[System.Serializable]
public class MissileWeapon : WeaponClass{
    public override void WeaponFunc(GameObject enemyObj)
    {
        base.WeaponFunc(enemyObj);
        Debug.Log("This is Missile's additional function");
    }
}

[System.Serializable] 
public class BulletWeapon : WeaponClass{
    public override void WeaponFunc(GameObject enemyObj)
    {
        base.WeaponFunc(enemyObj);
        Debug.Log("This is Bullet's additional function");
    }
}