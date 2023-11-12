using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    // public static SceneChange instance;

    // private void Awake()
    // {
    //     if (instance == null)
    //     {
    //         instance = this;
    //         DontDestroyOnLoad(gameObject);
    //     }
    //     else
    //     {
    //         Destroy(gameObject);
    //     }
    // }

    public void ChangeToCollectionScene()
    {
        DataManager.instance.SetInitialData();
        SceneManager.LoadScene("CollectionScene");
    }
    public void ChangeToTestScene()
    {
        SceneManager.LoadScene("TestScene");
    }

    public void ChangeToStage2()
    {
        SceneManager.LoadScene("Stage2");
    }

    public void ChangeToStage3()
    {
        SceneManager.LoadScene("Stage3");
    }


    public void ChangeToStage4()
    {
        SceneManager.LoadScene("Stage4");
    }


    public void ChangeToStage5()
    {
        SceneManager.LoadScene("Stage5");
    }

    public void ChangeToStage6()
    {
        SceneManager.LoadScene("Stage6");
    }
}
