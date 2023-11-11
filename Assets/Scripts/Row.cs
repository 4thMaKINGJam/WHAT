using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Row : MonoBehaviour
{
    [SerializeField] private int wordLength;
    Color white = Color.white;
    Color gray = new Color(0.7264151f, 0.7264151f, 0.7264151f);
    public GameObject parentRow;
    public int columns = 0;
    public GameObject gridCell;

    // Start is called before the first frame update

    int cell_index = 0;
    void Start()
    {
        CreateRow();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void CreateRow()
    {
        SpawnRowCells();

    }

    private void SpawnRowCells()
    {
        int cell_index = 0;
        for (int column = 0; column < columns; ++column)
        {
            GameObject cell = Instantiate(gridCell) as GameObject;
            if (cell_index >= wordLength)
            {
                cell.GetComponent<Image>().color = gray; //색깔수정
            }
            cell.transform.SetParent(parentRow.transform, false);

            cell_index++;
        }

    }
}
