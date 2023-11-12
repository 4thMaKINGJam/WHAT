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
    private int cellIndex = 0;

    private string rowWord = "default";
    Image[] images = new Image[14];
    Image[] frames = new Image[14];

    private int totalCorrect = 0;

    private GameObject[] KeyBoardPicked = new GameObject[10];
    private GameObject selectedRow;
    public GameObject gm,clear;
    
    
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

    public bool clickBtn(char input,Image img)
    {
        Row rowScript = selectedRow.GetComponent<Row>();
        if( rowScript.getTotalIndex() <= userInputsIndex)
        {
            return false;
        }
        userInputs[userInputsIndex] = input;
        KeyBoardPicked[userInputsIndex] = img.gameObject;
        userInputsIndex++;
        cellIndex++;
        
        cellIndex+=rowScript.setInput(userInputs,userInputsIndex);
        return true;
    }

    public void clickDeleteBtn()
    {
        Row rowScript = selectedRow.GetComponent<Row>();
        if(userInputsIndex==0)
        {
            return;
        }
        userInputsIndex--;
        cellIndex--;
        userInputs[userInputsIndex] = ' ';
        KeyBoardPicked[userInputsIndex].GetComponent<Alphabet>().resetBtn();
        KeyBoardPicked[userInputsIndex] = null;

        Debug.Log("----------"+userInputsIndex);
        rowScript.deleteInput(userInputsIndex);
        
    }
    
    public void clickCheckBtn( )
    {
        Row rowScript = selectedRow.GetComponent<Row>();

        string input = "";
        foreach (var ch in userInputs)
        {
            
             input += ch;
        }
        
//        Debug.Log(input +"here");
        if (rowScript.checkAnswer(input))
        {
            totalCorrect++;
        }
        ResetButton();
        userInputsIndex = 0;
        userInputs = new char[10];

        if (totalCorrect == 10)
        {
            
            // GameObject.Find("Canvas").transform.Find("Clear").gameObject.SetActive(true);
            string num = gm.GetComponent<GameManager>().numOfStage;
            //Debug.Log(num+"---------------------");
            int stageNum = int.Parse(num);
            DataManager.instance.SaveStageData(stageNum); //스테이지 번호넣어주시면됩니다. 변수 만들어서 넣어주셔도 됩니다
            SoundManager.instance.PlayClearSound();
            Outline[] outl = GameObject.Find("Canvas").GetComponentsInChildren<Outline>();
            foreach (var a in outl)
            {
                a.enabled = false;
            }
            
            GameObject.Find("Frame").SetActive(false);
            GameObject.Find("Meaning").SetActive(false);
            clear.SetActive(true);
            this.gameObject.SetActive(false);

        }
        
    }

    //imgaes의 클릭을 모두 해제하는 함수
    void ResetButton()
    {
        Alphabet[] sc = gameObject.GetComponentsInChildren<Alphabet>();
        for (int i = 0; i < sc.Length; i++)
        {
            sc[i].resetBtn();
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
        
        GameObject gms = row.transform.parent.gameObject;
        
        Row[] rows = gms.GetComponentsInChildren<Row>();

        for (int i = 0; i < rows.Length; i++)
        {
            rows[i].resetFrameForWord();
        }
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
