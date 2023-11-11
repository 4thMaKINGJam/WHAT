using System.Collections;
using System.Collections.Generic;
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
           
            
            StartRotation(i,sprites[i]);
            //Debug.Log("sprites"+(GetRowIndex()*columns+i));
        }
    }
    
    public void StartRotation(int i,Image uiImage)
    {

        StartCoroutine(RotateImageCoroutine(i, uiImage));

    }

    IEnumerator RotateImageCoroutine(int i, Image uiImage)
    {
        bool isChanged = false;
        yield return new WaitForSeconds(0.2f*i);

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
                    uiImage.sprite = gameManager.pixels[GetRowIndex()*columns+i];
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
        Debug.Log(rowIndex);
        string rowAnswer = gameManager.words[rowIndex]; //단어 리스트에서 row에 해당하는 단어 가져오기
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
                }
            }
            cell.transform.SetParent(parentRow.transform, false);
            cells.Add(cell);

            cell_index++;
        }

    }


    private int GetRowIndex()
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
