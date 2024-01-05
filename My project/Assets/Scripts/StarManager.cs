using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StarManager : MonoBehaviour
{
    public static StarManager instance;

    private int star;
    [SerializeField] private TMP_Text starDisplay;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }

    private void OnGUI()
    {
        starDisplay.text = star.ToString();
    }

    public void ChangeStar(int amount)
    {
        star += amount;
    }
}
