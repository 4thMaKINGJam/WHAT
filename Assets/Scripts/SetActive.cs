using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActive : MonoBehaviour
{
    private void Start()
    {
        setActiveFalse();
    }
    public void setActiveTrue()
    {
        this.gameObject.SetActive(true);
    }
    public void setActiveFalse()
    {
        this.gameObject.SetActive(false);
    }
}
