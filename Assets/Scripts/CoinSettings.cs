using UnityEngine;

[CreateAssetMenu(fileName = "CoinSettings", menuName = "Settings/Coin settings")]
public class CoinSettings : ScriptableObject
{
    public int MinPoints;
    public int MaxPoints;
    public GameObject Prefab;
}