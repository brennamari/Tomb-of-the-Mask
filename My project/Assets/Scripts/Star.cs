using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    [SerializeField] private int value;
    private bool hasTriggered;

    private StarManager starManager;

    private void Start()
    {
        starManager = StarManager.instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !hasTriggered)
        {
            hasTriggered = true;
            starManager.ChangeStar(value);
            Destroy(gameObject);
        }
    }
}
