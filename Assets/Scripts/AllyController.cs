using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class AllyController : MonoBehaviour {

    public GameObject BulletObj;
    public Transform BulletPos;

    public float speed;
    public float value;
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;

    private Rigidbody rigibody;
	void Start () {
        rigibody = GetComponent<Rigidbody>();	
        Physics.IgnoreLayerCollision(8, 8);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float moveHorizontal = CrossPlatformInputManager.GetAxis("Horizontal");
        float moveVertical = CrossPlatformInputManager.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0);
        rigibody.velocity = movement * speed;
        rigibody.rotation = Quaternion.Euler(0, 90, rigibody.velocity.y * value);
        rigibody.position = new Vector3(Mathf.Clamp(rigibody.position.x, xMin, xMax),
                                        Mathf.Clamp(rigibody.position.y, yMin, yMax),
                                        0);
	}

    private void Update()
    {
        if(CrossPlatformInputManager.GetButtonDown("Fire"))
        {
            //Debug.Log("Fire Pressed");
        }
    }

    public void Fire()
    {
        WeaponClass weapon = GetComponent<AllyShip>().thisWeaponClass;
        GameObject bullet = (GameObject)Instantiate(weapon.weaponObj, BulletPos.position, BulletPos.rotation);
        bullet.GetComponent<MissileControl>().thisWeapon = weapon;
    }
}
