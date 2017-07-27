using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class SellItem
{
    public string name;
    public string cost;
    public string description;
}

public class UIManager : MonoBehaviour {

    public static UIManager Instance;
    public Text scoreText;
    public Transform scrollTrans;
    public GameObject buttonItem;
    public List<SellItem> itemList = new List<SellItem>();
    public GameObject shopObj;

    void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        SetItem();
    }

    public void UpdateScore(int score)
    {
        scoreText.text = "Score : " + score;
    }

    void SetItem()
    {
        for(int i=0; i<itemList.Count; i++)
        {
            GameObject go = (GameObject)Instantiate(buttonItem, scrollTrans.position, Quaternion.identity);
            go.transform.SetParent(scrollTrans);
            go.transform.localScale = Vector3.one;
            go.GetComponentInChildren<Text>().text = itemList[i].name + "\n" + itemList[i].cost + "\n" + itemList[i].description;
        }
    }

    public void ToggleShopUI(bool open)
    {
        shopObj.SetActive(open);
    }

    void Update()
    {
        if(Input.GetKeyDown("d"))
        {
            GameObject go = (GameObject)Instantiate(buttonItem, scrollTrans.position, Quaternion.identity);
            go.transform.SetParent(scrollTrans);
            go.transform.localScale = Vector3.one;
        }
    }
}
