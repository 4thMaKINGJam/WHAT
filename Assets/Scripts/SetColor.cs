using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetColor : MonoBehaviour
{

    public string HexCode;
    public Image cell;

    // Start is called before the first frame update
    void Start()
    {
        cell = GetComponent<Image>();
        colorChange(HexCode);
    }

    // Update is called once per frame
    void Update()
    {


    }
    void colorChange(string HexCode)
    {
        Color color;
        ColorUtility.TryParseHtmlString(HexCode, out color);
        cell.color = color;

    }

}
