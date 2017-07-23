using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllyShip : Ship, IAlly {

    public static AllyShip Instance;
    public int defenseRate;
    public MissileWeapon missileWeapon;
    public BulletWeapon bulletWeapon;
    public List<WeaponClass> weapons = new List<WeaponClass>();
    public WeaponClass thisWeaponClass;
    public Weapon thisWeaponSort;
    public GameObject damPrefab;
    public GameObject hpBar;

    private void Start()
    {
        weapons.Add(missileWeapon);
        weapons.Add(bulletWeapon);
        thisWeapon = Weapon.Missile;
    }

    void Update()
    {
        if(Input.GetKeyDown("a"))
        {
            DealDamage(3);
        }
    }

    public override void DealDamage(int dam)
    {
        float finalDamage = dam - dam * (defenseRate / 100f);
        HP -= (int)finalDamage;
        GameObject damObj = (GameObject)Instantiate(damPrefab, transform.position, Quaternion.identity);
        damObj.GetComponentInChildren<Text>().text = finalDamage.ToString();
        //damObj.transform.parent = transform;
        damObj.transform.SetParent(transform);
        damObj.transform.localEulerAngles = new Vector3(0, -90f, 0);
        Destroy(damObj, 3);
        SetHPBar((float)HP/(float)MaxHP);
    }

    public void SetHPBar(float hpValue)
    {
        hpBar.transform.localScale = new Vector3(hpValue, hpBar.transform.localScale.y, hpBar.transform.localScale.z);
    }

    public override void OnConflict(GameObject other)
    {
        if(other.GetComponent<EnemyShip>() != null)
        {
            HP -= other.GetComponent<EnemyShip>().collideDamage;
        }
    }

    public Weapon thisWeapon { 
        get { return thisWeaponSort; } 
        set{
            thisWeaponSort = value;
            foreach(WeaponClass weapon in weapons)
            {
                if (weapon.weaponSort == value)
                    thisWeaponClass = weapon;
            }
        }
    }
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
