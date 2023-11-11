using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RowClickHandler : MonoBehaviour, IPointerClickHandler
{
    public GameObject focusBox;
    public GameObject keyBoard;
    public GameObject Row;
    private GameManager gameManager;

    private int rowIndex;
    // Start is called before the first frame update
    void Start()
    {
        // focusBox.SetActive(false);
        //keyBoard = GameObject.Find("SetActive").GetChild(0);

        rowIndex = this.GetComponent<Row>().GetRowIndex();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("onclick");

        ShowFocus();
    }

    void ShowFocus()
    {
        Debug.Log(rowIndex);
        // focusBox.SetActive(true);
        keyBoard.GetComponent<AlphabetKeyboard>().setRowWord(gameManager.words[rowIndex]);
        keyBoard.SetActive(true);



    }
    void HideFocus()
    {
        // focusBox.SetActive(false);
        keyBoard.SetActive(false);
    }

}
