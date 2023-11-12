using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.EventSystems;

public class AlphabetKeyboard : MonoBehaviour
{

    private Text[] alphabetTextComs;
    private List<char> WordList;
    private char[] userInputs = new char[10];
    private int userInputsIndex = 0;

    private string rowWord = "default";
    Image[] images = new Image[14];
    Image[] frames = new Image[14];

    private Image[] frameForWord = new Image[10];
    private GameObject selectedRow;
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
        images = GetComponentsInChildren<Image>();
        alphabetTextComs = new Text[images.Length];
        for (int i = 0; i < images.Length; i++)
        {
            alphabetTextComs[i] = images[i].GetComponentInChildren<Text>();
        }
        Debug.Log("awake");
        WordList = new List<char>();
    }


    public bool clickBtn(char input)
    {
        Row rowScript = selectedRow.GetComponent<Row>();
        if( rowScript.getTotalIndex() < userInputsIndex)
        {
            return false;
        }
        userInputs[userInputsIndex] = input;
        userInputsIndex++;
        rowScript.setActiveFrameForWord(userInputsIndex); 
        rowScript.setInput(userInputs,userInputsIndex);
        return true;
    }


    //imgaes의 클릭을 모두 해제하는 함수
    void ResetButton()
    {
        for (int i = 0; i < images.Length; i++)
        {
            images[i].color = new Color(1f, 1f, 1f);
        }
    }

    public void setFrame(GameObject row,int index)
    {
        frames = GameObject.Find("Frame").GetComponentsInChildren<Image>();
       
        
        
        for (int i = 0; i < frames.Length; i++)
        {
            frames[i].enabled = false;
            if (i == index)
            {
                frames[i].enabled = true;
                Debug.Log("index: " + i);
            }
        }
        
        //word frame
        userInputsIndex = 0;
        selectedRow = row;
        row.GetComponent<Row>().setActiveFrameForWord( userInputsIndex); 

    }
    public void SetKeyboard()
    {
        WordList = new List<char>();

        this.gameObject.SetActive(true);
        ResetButton();
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
        // Debug.Log("wordLength는" + wordLength.ToString());

        int remainWord = 14 - wordLength; //행 단어를 넣고 남은 키보드의 단어 수

        for (int i = 0; i < remainWord; i++)//남은 단어에 A~Z 랜덤하게 넣기
        {
            char randomAlphabet = (char)Random.Range('A', 'Z' + 1);
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
