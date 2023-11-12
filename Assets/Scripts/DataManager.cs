using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    private void Awake()
    {

        // PlayerPrefs.DeleteAll();
        if (instance == null) //존재하고 있지 않을때
        {
            instance = this; //다시 최신화
            DontDestroyOnLoad(gameObject); //씬변경시 파괴 x
        }
        else
        {
            if (instance != this) //중복으로 존재할시에는 파괴! 
                Destroy(this.gameObject);
        }
    }


    /*
    TotalStage - int : 총 스테이지 수
    Stage1 - string : 클리어시 "clear", 미완료시 "lock"
    Stage2 - string : 클리어시 "clear", 미완료시 "lock"
    Stage3 - string : 클리어시 "clear", 미완료시 "lock"
    Stage4 - string : 클리어시 "clear", 미완료시 "lock"
    Stage5 - string : 클리어시 "clear", 미완료시 "lock"
    Stage6 - string : 클리어시 "clear", 미완료시 "lock"
    
    */

    public void SetInitialData()
    {
        if (!PlayerPrefs.HasKey("TotalStage"))
        {
            PlayerPrefs.DeleteAll(); // 모두 삭제하기
            PlayerPrefs.SetInt("TotalStage", 6);
            PlayerPrefs.SetString("Stage1", "lock");
            PlayerPrefs.SetString("Stage2", "lock");
            PlayerPrefs.SetString("Stage3", "lock");
            PlayerPrefs.SetString("Stage4", "lock");
            PlayerPrefs.SetString("Stage5", "lock");
            PlayerPrefs.SetString("Stage6", "lock");
            PlayerPrefs.SetString("Stage7", "lock");
            PlayerPrefs.SetString("Stage8", "lock");
            PlayerPrefs.SetString("Stage9", "lock");
        }
    }


    public void SaveStageData(int stageNum)
    {
        string stageInfo = "Stage" + stageNum.ToString();
        PlayerPrefs.SetString(stageInfo, "clear");
    }

    public bool LoadStageData(int stageNum)
    {
        string stageInfo = "Stage" + stageNum.ToString();
        string stageState = PlayerPrefs.GetString(stageInfo);

        if (stageState == "lock")
        {
            return false;

        }
        else
        {
            return true;
        }
    }

}
