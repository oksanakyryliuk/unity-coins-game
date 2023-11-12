using System;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    [SerializeField] private Audio _audio;
    
    public int Points;
    public event Action Collected;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.TryGetComponent<Coin>(out var coin))
        {
            Points += coin.Points;
            Collected?.Invoke();
            _audio.PlayCollectedSound();
            Destroy(other.gameObject);
        }
    }
}