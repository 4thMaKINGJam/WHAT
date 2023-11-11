using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    [SerializeField]
    public List<string> words = new List<string>();
    [TextArea]
    public List<string> meanings = new List<string>();

    public Sprite[] pixels;

    void Awake()
    {
        LoadSprite("1");

    }

    void LoadSprite(string numOfStage)
    {
        pixels = Resources.LoadAll<Sprite>(string.Format("stage/stage{0}", numOfStage));

    }

}
