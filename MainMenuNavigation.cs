using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuNavigation : MonoBehaviour
{
    public Button[] boutons;
    public int currentBoutonIndex;
    private int upOrDown;
    public bool axisInUse = false;
    private void Start()
    {
        boutons[0].Select();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") || (Input.GetKeyDown(KeyCode.Return)))
        {
            boutons[currentBoutonIndex].onClick.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MainMenu.instance.settingWindow.SetActive(false);
        }
        if (Input.GetAxis("Vertical") != 0 )
        {
            if (!axisInUse)
            {
                if (Input.GetAxis("Vertical") > 0)
                {
                    upOrDown = -1;
                }
                else upOrDown = +1;
                currentBoutonIndex = (currentBoutonIndex + upOrDown) % boutons.Length;
                if (currentBoutonIndex < 0)
                {
                    currentBoutonIndex = boutons.Length-1;
                }
                boutons[currentBoutonIndex].Select();
                axisInUse = true;
            }
        }

        if (Input.GetAxis("Vertical") == 0)
        {
            axisInUse = false;
        }
    }
}
