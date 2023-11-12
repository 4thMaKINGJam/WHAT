using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridDynamicSize : MonoBehaviour
{
    Vector2 baseSize = new Vector2(720, 1280); // Base size of the screen
    Vector2 baseCellSize; // In editor Cell Size for GridLayoutComponent
    Vector2 baseCellSpacing; // In editor Cell Spacing for GridLayoutComponent
    GridLayoutGroup layoutGroup; //Component
    Vector2 minCellSize = new Vector2(50, 50); // 최소 셀 크기

    void Start()
    {
        layoutGroup = GetComponent<GridLayoutGroup>();
        baseCellSize = layoutGroup.cellSize;
        baseCellSpacing = layoutGroup.spacing;
        Debug.Log(baseCellSpacing);
    }

    void Update()
    {
        Vector2 screenSize = new Vector2(Screen.width, Screen.height); // Current screen size
        layoutGroup.cellSize = Vector2.Max((screenSize / baseSize) * baseCellSize, minCellSize);
        layoutGroup.spacing = (screenSize / baseSize) * baseCellSpacing;
    }
}
