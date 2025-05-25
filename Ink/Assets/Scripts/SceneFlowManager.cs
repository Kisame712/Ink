using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SceneFlowManager : MonoBehaviour
{
    public TMP_Text dropperText;

    public int currentDropperCount;
    public int totalDropperCount;

    private void Start()
    {
        totalDropperCount = FindObjectsOfType<Dropper>().Length;
    }
    private void Update()
    {
        dropperText.text = $"{currentDropperCount} / {totalDropperCount}";
    }

    public bool AllItemsCollected()
    {
        if(currentDropperCount == totalDropperCount)
        {
            return true;
        }
        return false;
    }
}
