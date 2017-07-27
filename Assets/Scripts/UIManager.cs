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

    public int[] crystalNumForChan;
    public Dropdown CrystalDropdown;

    void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        SetItem();
        //SetDropDown();
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
        if (Input.GetKeyDown("d"))
        {
            GameObject go = (GameObject)Instantiate(buttonItem, scrollTrans.position, Quaternion.identity);
            go.transform.SetParent(scrollTrans);
            go.transform.localScale = Vector3.one;
        }
    }

    public void SoundToggle(Toggle tog)
    {
        if(tog.isOn)
        {
            if(tog.name == "SoundOn")
            {
                Debug.Log("Sound on");
            }
            else 
            {
                Debug.Log("Sound off");
            }
        }
    }

    void SetDropDown()
    {
        CrystalDropdown.options.Clear();
        for (int i = 0; i < crystalNumForChan.Length; i++)
        {
            Dropdown.OptionData data = new Dropdown.OptionData{
                text = crystalNumForChan[i].ToString()
            };
            CrystalDropdown.options.Add(data);

        }
        CrystalDropdown.captionText.text = crystalNumForChan[0].ToString();
    }

    public void DropDownChanged(Dropdown drop)
    {
        Debug.Log("Selected value is " + crystalNumForChan[drop.value]);
    }
}
