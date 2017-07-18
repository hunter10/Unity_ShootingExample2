using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Classes : MonoBehaviour {
}

public abstract class Ship : MonoBehaviour
{
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