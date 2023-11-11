using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlphabetKeyboard : MonoBehaviour
{

    private Text[] alphabetTextComs;
    private List<char> WordList;

    
    private string rowWord = "Applepie";

    private void Awake() {
        Image[] images = GetComponentsInChildren<Image>();
        alphabetTextComs = new Text[images.Length];
        for (int i = 0; i < images.Length; i++){
            alphabetTextComs[i] = images[i].GetComponentInChildren<Text>();
        }

        WordList = new List<char>();
    }
    // Start is called before the first frame update
    void Start()
    {
        int wordLength = rowWord.Length; //행의 단어 쪼개서 키보드에 넣기
        for (int i = 0; i < wordLength; i++)
        {
            WordList.Add(char.ToUpper(rowWord[i]));
        }

        int remainWord = 14 - wordLength; //행 단어를 넣고 남은 키보드의 단어 수

        for (int i = 0; i < remainWord; i++)//남은 단어에 A~Z 랜덤하게 넣기
        {
            char randomAlphabet = (char)Random.Range('A', 'Z' + 1);
            WordList.Add(randomAlphabet);
        }
        //키보드 리스트 섞기
        int random1,  random2;
        char temp;
        for (int i = 0; i< WordList.Count; i++){
            random1 = Random.Range(0, WordList.Count);
            random2 = Random.Range(0, WordList.Count);

            temp = WordList[random1];
            WordList[random1] = WordList[random2];
            WordList[random2] = temp;
        }

        for (int i = 0; i < WordList.Count; i++){
            alphabetTextComs[i].text = WordList[i].ToString(); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
