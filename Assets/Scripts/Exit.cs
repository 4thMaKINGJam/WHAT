using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Exit : MonoBehaviour
{
    Button btn;
    // Start is called before the first frame update
    void Start()
    {
        btn = this.transform.GetComponent<Button>();
        if (btn != null)
        {
            btn.onClick.AddListener(GotoCollections);         //스크립트로 버튼 이벤트 수행
        }
    }
    void GotoCollections()
    {
        SceneManager.LoadScene("CollectionScene");
    }
}
