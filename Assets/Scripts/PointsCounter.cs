using TMPro;
using UnityEngine;

public class PointsCounter : MonoBehaviour
{
    [SerializeField] private CoinCollector _coinCollector;
    private TextMeshProUGUI _counter;

    private void Awake()
    {
        _counter = GetComponent<TextMeshProUGUI>();
        _coinCollector.Collected += UpdateCounter;
    }

    private void Start()
    {
        UpdateCounter();
    }

    private void OnDestroy()
    {
        _coinCollector.Collected -= UpdateCounter;
    }

    private void UpdateCounter()
    {
        _counter.text = "Points: " + _coinCollector.Points;
    }
}