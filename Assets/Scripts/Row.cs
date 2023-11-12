using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Row : MonoBehaviour
{
    [SerializeField] private int wordLength;
    Color white = Color.white;
    Color gray = new Color(0.7264151f, 0.7264151f, 0.7264151f);

    //부모 오브젝트
    public GameObject parentRow;


    public int columns = 0;
    public GameObject gridCell;

    //해당 ROW의 셀들을 담을 리스트
    private List<GameObject> cells = new List<GameObject>();

    //GameManager를 찾아서 가져오기
    private GameManager gameManager;
    private string rowAnswer;
    
    //띄어쓰기 개수 
    private int totalGray;
    //띄어쓰기 위치
    private List<int> grayIndex = new List<int>();
    
    public int getTotalIndex()
    {
        return rowAnswer.Length - totalGray;
    }


    private void Awake()
    {
        rowAnswer = "";
        totalGray = 0;
    }

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        CreateRow();
        //setAnswerColor();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void clearCell()
    {
       for(int i =0 ; i <cells.Count; i++)
       {
            cells[i].transform.GetChild(1).GetComponent<Text>().text = "";
            cells[i].GetComponent<Image>().color = white;
            
            if (totalGray>0 && grayIndex[0]==i )
            {
                cells[i].GetComponent<Image>().color = gray;
            }
            else if (i > rowAnswer.Length-totalGray)
            {
                cells[i].GetComponent<Image>().color = gray;
            }
            else
            {
                cells[i].GetComponent<Image>().color = white;
            }
       }
    }

    public bool checkAnswer(string input)
    {
        clearCell();
        
        string answer = rowAnswer.Replace(" ", "").ToUpper();
        input = input.ToUpper().Trim();
       // Debug.Log(input+"답"+answer+"입력"+input+"aaaaa");
        Debug.Log(input.Length+"답"+answer.Length+"입력"+input.Length+"aaaaa");
        bool flag = false;
        
        for (int i = 0; i < answer.Length; i++)
        {
            if(input[i]!=answer[i])
            {
                Debug.Log("정답 답+"+answer[i]+"입력"+input[i]);
                flag = false;
                break;
            }
            flag = true;
        }
        
        if (flag)
        {
            //Debug.Log("정답 답+"+answer+"입력"+input);
            resetFrameForWord();
            setAnswerColor();
            SoundManager.instance.PlayCorrectSound();
            return true;

        }
        else
        {
            Debug.Log("실패");
            setActiveFrameForWord(0);
            GameObject.Find("GameManager").GetComponent<GameManager>().showminusLife();
//            SoundManager.instance.PlayIncorrectSound();
            
            if(GameObject.Find("GameManager").GetComponent<GameManager>().life == 0)
            {
                GameObject.Find("Canvas").transform.Find("gameover").gameObject.SetActive(true);
            }
            return false;
        }
        
    }
    public int setInput(char[] inputs,int index)
    {    
        int grayIndex = 0;
        for (int i = 0; i < index; i++)
        {
            if (index + grayIndex > rowAnswer.Length)
            {
                resetFrameForWord();
                return grayIndex;
            }

            if (cells[i + grayIndex].GetComponent<Image>().color == gray)
            {
                grayIndex++;

            }
            cells[i+grayIndex].transform.GetChild(1).GetComponent<Text>().text = inputs[i].ToString();
            cells[i+grayIndex].GetComponent<Image>().color = new Color(73 / 255f, 174 / 255f, 1);
            
        }
        setActiveFrameForWord(index+grayIndex);
        
        return
        grayIndex;

    }
    
    public void deleteInput(int userIndex)
    {
        int index = userIndex;
       
        if (totalGray>0 )
        {
            for (int i = 0; i < userIndex; i++)
            {
               // if (userIndex >grayIndex[0]+1) {index++;    Debug.Log("띄어쓰기칸이 추가됨" + index);}
                //if(i > grayIndex[0]+1) 
            }
            if (userIndex >=grayIndex[0]) {index+=1;    Debug.Log(userIndex +"띄어쓰기칸이 추가됨" + index);}
            // if (index == 0)
            // {
            //     cells[index].transform.GetChild(1).GetComponent<Text>().text = "";
            //     cells[index].GetComponent<Image>().color = white;
            //     setActiveFrameForWord(index);
            //     return;
            // }
            //
        }
        
        cells[index].transform.GetChild(1).GetComponent<Text>().text = "";
        cells[index].GetComponent<Image>().color = white;
        setActiveFrameForWord(index);
        
        return;
    
    }

    public void resetFrameForWord()
    {
        for (int i = 0; i < cells.Count; i++)
        {
            Image frameForWord = cells[i].transform.GetChild(0).GetComponent<Image>();
            frameForWord.enabled = false;
        }
    }
   public void setActiveFrameForWord(int index)
    {
        if(cells[index].GetComponent<Image>().color == gray)
        {
            index++;
        }

        if(index >= getTotalIndex())
        {
         
            resetFrameForWord();
            return;
        }
       
        for (int i = 0; i < cells.Count; i++)
        {
            Image frameForWord = cells[i].transform.GetChild(0).GetComponent<Image>();
            frameForWord.enabled = false;

            if (index == i)
            {
                frameForWord.enabled = true;
            }
        }
    }
   
    // 정답 맞출시 호출
    void setAnswerColor()
    {
        List<Image> sprites = new List<Image>(); //=  gameObject.GetComponentsInChildren<Image>();

        foreach (var cell in cells)
        {
            sprites.Add(cell.GetComponent<Image>());

        }
        for (int i = 0; i < sprites.Count; i++)
        {

            StartRotation(i, sprites[i]);
            //Debug.Log("sprites"+(GetRowIndex()*columns+i));
        }
  

    }

    public void StartRotation(int i, Image uiImage)
    {

        StartCoroutine(RotateImageCoroutine(i, uiImage));

    }

    IEnumerator RotateImageCoroutine(int i, Image uiImage)
    {
        bool isChanged = false;
        yield return new WaitForSeconds(0.2f * i);

        if (uiImage != null)
        {
            // Y축으로 180도 회전
            float elapsedTime = 0f;
            float duration = 1f; // 회전에 걸리는 시간 (초)
            Quaternion startRotation = uiImage.rectTransform.rotation;
            Quaternion targetRotation = startRotation * Quaternion.Euler(0f, 180f, 0f);




            while (elapsedTime < duration)
            {
                uiImage.rectTransform.rotation = Quaternion.Slerp(startRotation, targetRotation, elapsedTime / duration);
                elapsedTime += Time.deltaTime;

                if (elapsedTime > 0.5 && isChanged == false)
                {
                    isChanged = true;
                    uiImage.color = white;
                    uiImage.sprite = gameManager.pixels[GetRowIndex() * columns + i];
                }
                yield return null;
            }

        }
        else
        {
            Debug.LogWarning("UI Image가 할당되지 않았습니다.");
        }


    }


    private void CreateRow()
    {
        SpawnRowCells();

    }

    private void SpawnRowCells()
    {
        int cell_index = 0;
        int rowIndex = GetRowIndex();

         rowAnswer = gameManager.words[rowIndex]; //단어 리스트에서 row에 해당하는 단어 가져오기
        int wordLength = rowAnswer.Length;

        for (int column = 0; column < 10; ++column)
        {
            GameObject cell = Instantiate(gridCell) as GameObject;

            if (cell_index >= wordLength)
            {
                cell.GetComponent<Image>().color = gray; //색깔수정 - 회색으로
                
            }

            else
            {
                if (rowAnswer[column].Equals(' '))
                {
                    cell.GetComponent<Image>().color = gray; //색깔수정 - 띄어쓰기
                    grayIndex.Add(column);
                    totalGray++;
                }
            }
            cell.transform.SetParent(parentRow.transform, false);
            cells.Add(cell);

            cell_index++;
        }

    }


    public int GetRowIndex()
    {
        //전체 테이블 오브젝트 가져오기
        Transform TableTransform = parentRow.transform.parent;

        // 부모의 자식 개수
        int rowCount = TableTransform.childCount;

        // 이 컴포넌트의 인덱스 찾기
        int currentIndex = -1;

        for (int i = 0; i < rowCount; i++)
        {
            Transform childTransform = TableTransform.GetChild(i);


            // 찾고자 하는 컴포넌트와 비교
            if (childTransform == parentRow.transform)
            {
                currentIndex = i;
                break;
            }
        }
        return currentIndex;
    }
}
