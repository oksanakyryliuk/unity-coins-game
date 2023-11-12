using System.Collections;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private float _spawnInterval;
    [SerializeField] private float _minX;
    [SerializeField] private float _maxX;
    
    private CoinFactory _factory;
    private bool _paused;

    private void Awake()
    {
        _factory = new CoinFactory();
        _factory.LoadSettings();
    }

    private void Start()
    {
        StartCoroutine(SpawnCoins());
    }

    private IEnumerator SpawnCoins()
    {
        while(true)
        {
            if(_paused)
                yield return null;
            
            var position = new Vector2(Random.Range(_minX, _maxX), transform.position.y);
            _factory.CreateCoin(position);
            yield return new WaitForSeconds(_spawnInterval);
        }
    }

    public void Pause() =>
        _paused = true;

    public void Resume() =>
        _paused = false;
}