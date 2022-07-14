using UnityEngine;

public class LoadAndSaveData : MonoBehaviour
{
    public static LoadAndSaveData instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("there is more than one instance of LoadAndSaveData in the scene");
            return;
        }
        instance = this;
    }

    void Start()
    {
        Inventory.instance.coinsCount = PlayerPrefs.GetInt("coinsCount", 0);
        Inventory.instance.UpdateCoinsUI();

        int currentHealth= PlayerPrefs.GetInt("playerHealth", PlayerHealth.instance.maxHealth);
        PlayerHealth.instance.currentHealth = currentHealth;
        PlayerHealth.instance.healthBar.SetHealth(currentHealth);
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("coinsCount",Inventory.instance.coinsCount);
        PlayerPrefs.SetInt("playerHealth",PlayerHealth.instance.currentHealth);
    }
}
