using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public static UIManager Instance;
    public Text scoreText;

    public int[] crystalNumForChan;
    public Dropdown CrystalDropdown;

    void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        SetDropDown();
    }

    public void UpdateScore(int score)
    {
        scoreText.text = "Score : " + score;
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
