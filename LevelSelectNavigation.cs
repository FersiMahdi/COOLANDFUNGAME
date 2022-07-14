using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelSelectNavigation : MonoBehaviour
{
    public Button[] boutons;
    public int currentBoutonIndex;
    public GameObject scrollRect;
    private void Start()
    {
        boutons[0].Select();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ReturnMainMenu();
        }
        if (Input.GetButtonDown("Jump") || (Input.GetKeyDown(KeyCode.Return)))
        {
            boutons[currentBoutonIndex].onClick.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            SelectButton(-1); 
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) )
        {
            SelectButton(1);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            SelectButton(4); 
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            SelectButton(-4); 
        }


    }
    
    private void SelectButton(int value)
    {
        if (currentBoutonIndex + value > boutons.Length)
        {
            boutons[0].Select();
            currentBoutonIndex = 0;
            placeScroll();
            return;
        }
        currentBoutonIndex = (currentBoutonIndex + value) % boutons.Length;
        if (currentBoutonIndex < 0)
        {
            currentBoutonIndex = boutons.Length-1;
        }
        boutons[currentBoutonIndex].Select();
        placeScroll();
    }
    private void placeScroll()
    {
        if (currentBoutonIndex >= 4 && currentBoutonIndex<8)
        {
            scrollRect.GetComponent<ScrollRect>().verticalNormalizedPosition = 0.75f;
        }else if (currentBoutonIndex >= 8 && currentBoutonIndex<12)
        {
            scrollRect.GetComponent<ScrollRect>().verticalNormalizedPosition = 0.3f;
        }else if (currentBoutonIndex >= 12 )
        {
            scrollRect.GetComponent<ScrollRect>().verticalNormalizedPosition = 0f;
        }else if (currentBoutonIndex >= 0)
        {
            scrollRect.GetComponent<ScrollRect>().verticalNormalizedPosition = 1f;
        }
    }

    public void ReturnMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}

