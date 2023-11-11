using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RowClickHandler : MonoBehaviour, IPointerClickHandler
{
    public GameObject focusBox;
    public Image row;
    // Start is called before the first frame update
    void Start()
    {
        focusBox.SetActive(false);

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("onclick");
        ShowFocusBox();
    }

    void ShowFocusBox()
    {
        focusBox.SetActive(true);
    }
    void HideFocusBox()
    {
        focusBox.SetActive(false);
    }
}
