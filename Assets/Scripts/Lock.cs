using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    GameObject lockObject;

    public int stagenum;

    private void Start()
    {
        lockObject = this.gameObject.transform.GetChild(1).gameObject;

        if (!DataManager.instance.LoadStageData(stagenum))
        {

            lockObject.SetActive(true);
            Debug.Log("Lock");
        }
        else
        {
            lockObject.SetActive(false);
            Debug.Log("Clear");
        }
    }


}

