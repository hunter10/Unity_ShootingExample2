using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpChangeColor : MonoBehaviour {

    private Image image;
    public float min = 0;
    public float max = 1;
    public Color minColor = Color.red;
    public Color maxColor = Color.green;

    private void Start()
    {
        image = GetComponent<Image>();
    }

    private void Update()
    {
        image.color = Color.Lerp(minColor, 
                                 maxColor, 
                                 Mathf.Lerp(min, max, transform.localScale.x));
    }
}
