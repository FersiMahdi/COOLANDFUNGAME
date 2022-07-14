using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
 public GameObject gameOverUI;
 public static GameOverManager instance;
 private void Awake()
 {
  if (instance != null)
  {
   Debug.LogWarning("Une instance de GameOverManager existe déjà.");
  }

  instance = this;
 }

 public void OnPlayerDeath()
 {
  gameOverUI.SetActive(true);
 }

 public void RetryButton()
 {
  Inventory.instance.RemoveCoins(CurrentSceneManager.instance.coinsPickedUpInThisScene);
  SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
  PlayerHealth.instance.Respawn();
  gameOverUI.SetActive(false);
  AudioManager.instance.PlayMusic();
  
 }

 public void MainMenuButton()
 {
  SceneManager.LoadScene("MainMenu");
 }

 public void QuitButton()
 {
  Application.Quit();
 }
}
