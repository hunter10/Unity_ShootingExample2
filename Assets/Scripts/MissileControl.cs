using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileControl : MonoBehaviour {

    public float speed;
    public ForceMode mode;
    public float deadTime;
    public GameObject explodeObj;
    public WeaponClass thisWeapon;
    private Rigidbody rigibody;
	
	void Start () {
        rigibody = GetComponent<Rigidbody>();	
        Destroy(gameObject, deadTime);
	}
	
	
	void FixedUpdate () {
        rigibody.AddForce(Vector3.right * speed, mode);
	}

    private void OnCollisionEnter(Collision other)
    {
        if (explodeObj != null)
            Instantiate(explodeObj, transform.position, Quaternion.identity);

        thisWeapon.WeaponFunc(other.gameObject);
        Destroy(gameObject); 

        Debug.Log("Collision!!");
    }
}
