using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Alphabet : MonoBehaviour
{
    public Sprite newImage; // 클릭할 때 보여질 새 이미지

    private Image myImage;

    void Start()
    {
        // 현재 GameObject에 연결된 Image 컴포넌트 가져오기
        myImage = GetComponent<Image>();
        Button button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(ChangeImage);
    }

    void ChangeImage()
    {
        myImage.sprite = newImage;
    }
}
