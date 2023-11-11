using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlphabetKeyboard : MonoBehaviour
{

    private Text[] alphabetTextComs;
    private List<char> WordList;

    //단어 리스트 저장된 오브젝트 가져오기
    // private GameManager gameManager;
    // private RowClickHandler rowClickHandler;


    private string rowWord = "default";

    string getWord()
    {
        return rowWord;
    }

    public void setRowWord(string word)
    {
        rowWord = word;
    }
    private void Awake()
    {
        Image[] images = GetComponentsInChildren<Image>();
        alphabetTextComs = new Text[images.Length];
        for (int i = 0; i < images.Length; i++)
        {
            alphabetTextComs[i] = images[i].GetComponentInChildren<Text>();
        }

        WordList = new List<char>();



    }
    // Start is called before the first frame update
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {

    }

    void SetKeyboard()
    {
        int wordLength = rowWord.Length; //행의 단어 쪼개서 키보드에 넣기
        for (int i = 0; i < rowWord.Length; i++)
        {
            if (rowWord[i] == ' ')
            {
                wordLength--;
                continue;

            }
            WordList.Add(char.ToUpper(rowWord[i]));
        }
        Debug.Log("wordLength는" + wordLength.ToString());

        int remainWord = 14 - wordLength; //행 단어를 넣고 남은 키보드의 단어 수

        for (int i = 0; i < remainWord; i++)//남은 단어에 A~Z 랜덤하게 넣기
        {
            char randomAlphabet = (char)Random.Range('A', 'Z' + 1);
            Debug.Log(randomAlphabet + i.ToString());
            WordList.Add(randomAlphabet);
        }
        //키보드 리스트 섞기
        int random1, random2;
        char temp;
        for (int i = 0; i < WordList.Count; i++)
        {
            random1 = Random.Range(0, WordList.Count);
            random2 = Random.Range(0, WordList.Count);

            temp = WordList[random1];
            WordList[random1] = WordList[random2];
            WordList[random2] = temp;
        }

        for (int i = 0; i < WordList.Count; i++)
        {
            alphabetTextComs[i].text = WordList[i].ToString();
        }
    }

}
