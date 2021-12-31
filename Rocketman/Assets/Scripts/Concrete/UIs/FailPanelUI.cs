using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailPanelUI : MonoBehaviour
{
    public void RestartButtonClick()
    {
        GameManager.Instance.lateOpen();
        this.gameObject.SetActive(false);
    }
}
