using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Text menuCoinText;

    private void Start()
    {
        LoadCoins();
    }

    private void LoadCoins()
    {
        int coins = PlayerPrefs.GetInt("Coins", 0);
        menuCoinText.text = coins.ToString();
    }
}
