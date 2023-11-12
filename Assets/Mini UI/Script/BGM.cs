using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{

    public static BGM instance;

    private void Awake()
    {
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
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
