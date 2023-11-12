using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypingSound : MonoBehaviour
{
    Button button;
    private void Start()
    {
        button = this.transform.GetComponent<Button>();
        button.onClick.AddListener(SoundManager.instance.PlayTypingSound);
    }

}
