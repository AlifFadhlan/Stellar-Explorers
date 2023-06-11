using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    [Header("UI Pages")]
    public GameObject mainMenu;
    public GameObject about;

    [Header("Main Menu Buttons")]
    public Button startButton;
    public Button aboutButton;
    public Button quitButton;

    public List<Button> returnButtons;
    // Start is called before the first frame update
    void Start()
    {
        EnableMainMenu();

        //Hook events
        startButton.onClick.AddListener(StartGame);
        aboutButton.onClick.AddListener(EnableAbout);
        quitButton.onClick.AddListener(QuitGame);

        foreach (var item in returnButtons)
        {
            item.onClick.AddListener(EnableMainMenu);
        }
    }

    // Update is called once per frame
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void StartGame()
    {
        Debug.Log("Start");
        SceneManager.LoadScene("StellarScene");
    }

    public void EnableMainMenu()
    {
        mainMenu.SetActive(true);
        about.SetActive(false);
    }

    public void EnableAbout()
    {
        mainMenu.SetActive(false);
        about.SetActive(true);
    }

}
