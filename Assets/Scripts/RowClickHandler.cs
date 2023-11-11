using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RowClickHandler : MonoBehaviour, IPointerClickHandler
{
    public GameObject focusBox;
    public GameObject keyBoard;
    public GameObject meaningPanel;

    private GameManager gameManager;

    private int rowIndex;
    public bool hasBeenClicked = false; // 클릭 이벤트가 처리되었는지 여부를 추적하는 플래그



    // List<GameObject> rowList;



    // Start is called before the first frame update

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        meaningPanel = GameObject.Find("Canvas").transform.Find("Meaning").gameObject;
        // if (meaningPanel != null)
        // {
        //     meaningPanel.SetActive(false);
        // }
        // if (keyBoard != null)
        // {
        //     keyBoard.SetActive(false);
        // }



        focusBox.SetActive(false);
        keyBoard.SetActive(false);

        //클릭한 row가 몇 번째 행인지 가져오기
        rowIndex = GetComponent<Row>().GetRowIndex();

    }

    public void OnPointerClick(PointerEventData eventData)
    {

        if (!hasBeenClicked)
        {
            Debug.Log("클릭됨");

            RowClickHandler[] siblings = transform.parent.GetComponentsInChildren<RowClickHandler>();
            foreach (RowClickHandler sibling in siblings)
            {
                if (sibling != this)
                {
                    sibling.SetClicked(false);
                }
            }

            ShowFocus();
            hasBeenClicked = true;
        }
    }

    void ShowFocus()
    {

        // focusBox.SetActive(true);
        Debug.Log("rowIndex : " + rowIndex.ToString());

        //뜻 보이게
        meaningPanel.SetActive(true);
        meaningPanel.transform.GetChild(0).GetComponent<Text>().text = gameManager.meanings[rowIndex];

        //선택한 행의 정답 단어 할당
        keyBoard.GetComponent<AlphabetKeyboard>().setRowWord(gameManager.words[rowIndex]);
        //키보드 보이게 + 키보드 글자 생성
        keyBoard.GetComponent<AlphabetKeyboard>().SetKeyboard();



    }
    void HideFocus()
    {
        // focusBox.SetActive(false);
        //뜻 안보이게
        meaningPanel.SetActive(false);
        //키보드 안보이게
        keyBoard.SetActive(false);


        //모든 row flag false(미선택)로 만들기


    }


    public void SetClicked(bool value)
    {
        hasBeenClicked = value;
    }
}
