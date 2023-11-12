using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public static SceneChange instance;

    private void Awake()
    {
        instance = this;
    }


    public void ChangeToCollectionScene()
    {
        SceneManager.LoadScene("CollectionScene");
    }
    public void ChangeToTestScene()
    {
        SceneManager.LoadScene("TestScene");
    }
}
