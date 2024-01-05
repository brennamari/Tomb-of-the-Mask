using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    [SerializeField] private int value;
    private bool hasTriggered;

    private CoinManager coinManager;
    private AudioSource audioSource;

    private void Start()
    {
        coinManager = CoinManager.instance;
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !hasTriggered)
        {
            hasTriggered = true;
            coinManager.ChangeCoins(value);
            PlayCollectionSound();
            Destroy(gameObject);
            
        }
    }
    private void PlayCollectionSound()
    {
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.Play();
        }
    }
}
