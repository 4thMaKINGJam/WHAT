using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Alphabet : MonoBehaviour
{
    private Sprite clickedImage; // 클릭할 때 보여질 새 이미지
    private Sprite originalImage; 
    private Image myImage;
    private Text text;
    private Button button;
    private void Awake()
    {
        // Resources 폴더에서 이미지 가져오기
       // clickedImage = Resources.Load<Sprite>("Clicked");
       // originalImage = Resources.Load<Sprite>("Original");
    }

    void Start()
    {
        // 현재 GameObject에 연결된 Image 컴포넌트 가져오기
        myImage = GetComponent<Image>();
        text = this.transform.GetChild(0).GetComponent<Text>();
        
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(ClickBtn);
    }

    void ClickBtn()
    {

        if (transform.GetComponentInParent<AlphabetKeyboard>().clickBtn(text.text[0],myImage))
        {
        myImage.color = new Color(0.4f, 0.4f, 0.4f);
        button.interactable = false;
    }
}

    public void resetBtn()
    {
        myImage.color = new Color(1f,1f,1f);
        button.interactable = true;
     //   myImage.sprite = clickedImage;
    }
}
