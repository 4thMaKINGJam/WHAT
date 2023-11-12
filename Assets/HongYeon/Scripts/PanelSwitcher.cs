using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelSwitcher : MonoBehaviour
{   public GameObject[] panels; // 판넬들을 배열로 저장

    private int currentPanelIndex = 0; // 현재 활성화된 판넬의 인덱스

    void Start()
    {
        // 초기에는 첫 번째 판넬만 활성화
        ShowPanel(currentPanelIndex);
    }

    public void Exit()
    {
        SceneManager.LoadScene("CollectionScene");
    }
    void Update()
    {
        // 마우스 클릭으로 판넬 전환
        if (Input.GetMouseButtonDown(0))
        {
            SwitchToNextPanel();
        }

        // 우클릭 또는 ESC 키로 뒤로 가기
        if (Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.Escape))
        {
            SwitchToPreviousPanel();
        }
    }

    void SwitchToNextPanel()
    {
        // 다음 판넬 인덱스 증가
        currentPanelIndex++;

        // 마지막 판넬에서 한번 더 클릭하면 콜렉션 씬으로 넘어감
        if (currentPanelIndex >= panels.Length)
        {
            SceneManager.LoadScene("CollectionScene");

        }

        // 다음 판넬 활성화
        ShowPanel(currentPanelIndex);
    }

void SwitchToPreviousPanel()
{
    // 첫 번째 판넬에서는 뒤로가기와 ESC 키 동작을 막음
    if (currentPanelIndex == 0)
        return;

    // 현재 판넬 비활성화
    panels[currentPanelIndex].SetActive(false);

    // 이전 판넬 인덱스로 이동
    currentPanelIndex--;

    // 이전 판넬 활성화
    ShowPanel(currentPanelIndex);
}

    void ShowPanel(int index)
    {
        // 해당 인덱스의 판넬을 활성화
        panels[index].SetActive(true);
    }

}
