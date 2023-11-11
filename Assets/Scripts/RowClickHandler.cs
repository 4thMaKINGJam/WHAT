using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RowClickHandler : MonoBehaviour, IPointerClickHandler
{
   // public Image focusBox;
    public GameObject keyBoard;
    public GameObject MeaningPanel;

    private GameManager gameManager;

    private int rowIndex;
    private bool hasBeenClicked = false; // 클릭 이벤트가 처리되었는지 여부를 추적하는 플래그



    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        //focusBox.enabled = false;

    }

    public void OnPointerClick(PointerEventData eventData)
    {

       
            Debug.Log("클릭됨");
            ShowFocus();
            hasBeenClicked = true;
            this.GetComponent<Image>().color = new Color(0.4f, 0.4f, 0.4f);
        
    }

    void ShowFocus()
    {
        rowIndex = this.transform.GetSiblingIndex();

        // focusBox.SetActive(true);
        keyBoard.GetComponent<AlphabetKeyboard>().setRowWord(gameManager.words[rowIndex]);
        keyBoard.GetComponent<AlphabetKeyboard>().SetKeyboard();
        keyBoard.GetComponent<AlphabetKeyboard>().setFrame(rowIndex);

        hasBeenClicked = false;
    }
    void HideFocusBox()
    {
        //focusBox.enabled = false;
    }
}
