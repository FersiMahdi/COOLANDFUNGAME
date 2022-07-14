using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Text textPiece;
    public int coinsCount = 0;
    public static Inventory instance;

    public void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance d'Inventory dans la scène !");
        }
        instance = this;
    }

    public void AddCoins(int count)
    {
        coinsCount += count;
        UpdateCoinsUI();
    }

    public void RemoveCoins(int count)
    {
        coinsCount -= count;
        UpdateCoinsUI();
    }

    public void UpdateCoinsUI()
    {
        textPiece.text = coinsCount.ToString("D3");

    }
}
