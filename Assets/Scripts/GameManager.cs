using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public List<string> words = new List<string>();
    [TextArea]
    public List<string> meanings = new List<string>();

    public Text lifeText;
    public GameObject GameOverPanel;
    
    public Sprite[] pixels;
    public string numOfStage;
    public int life = 1;
    void Awake()
    {
        LoadSprite(numOfStage);
        lifeText.text = life.ToString();
    }
    
    
    
    public void showminusLife()
    {
        life--;
        lifeText.text = life.ToString();
    }

    void LoadSprite(string numOfStage)
    {
        pixels = Resources.LoadAll<Sprite>(string.Format("stage/stage{0}", numOfStage));

    }

}
