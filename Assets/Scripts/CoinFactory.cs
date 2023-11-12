using UnityEngine;

public class CoinFactory
{
    private CoinSettings _settings;

    public void LoadSettings()
    {
        _settings = Resources.Load<CoinSettings>("CoinSettings");
    }

    public void CreateCoin(Vector2 position)
    {
        GameObject gameObject = Object.Instantiate(_settings.Prefab, position, Quaternion.identity);
        Coin coin = gameObject.GetComponent<Coin>();
        coin.Points = Random.Range(_settings.MinPoints, _settings.MaxPoints);
    }
}