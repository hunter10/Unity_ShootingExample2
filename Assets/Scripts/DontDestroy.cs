using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour {

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (FindObjectsOfType(GetType()).Length > 1)
            Destroy(gameObject);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown("a")){
            SceneManager.LoadScene("Scene2");
        }
		if (Input.GetKeyDown("s"))
		{
			SceneManager.LoadScene("Scene1");
		}
	}
}
