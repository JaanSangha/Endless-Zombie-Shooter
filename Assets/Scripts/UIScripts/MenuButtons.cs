using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuButtons : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject creditsMenu;
    public GameObject startMenu;

    public void PlayPressed()
    {
        SceneManager.LoadScene("Main");
    }

    public void CreditsPressed()
    {
        creditsMenu.SetActive(true);
        mainMenu.SetActive(false);
        startMenu.SetActive(false);
    }
    public void MenuPressed()
    {
        creditsMenu.SetActive(false);
        mainMenu.SetActive(true);
        startMenu.SetActive(false);
    }
    public void ExitPressed()
    {
        Application.Quit();
    }
}
