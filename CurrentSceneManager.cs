using UnityEngine;

public class CurrentSceneManager : MonoBehaviour
{
   public static CurrentSceneManager instance;
   public int coinsPickedUpInThisScene;
   private void Awake()
   {
      if (instance != null)
      {
         Debug.LogWarning("Une instance de CurrentSceneManager existe déjà.");
         return;
      }

      instance = this;
   }

}
