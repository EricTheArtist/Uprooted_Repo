using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WelcomeSceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);

    }

    public void OpenCredits()
    {
        SceneManager.LoadScene(2);
    }

    public void CloseCredits()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame() 
    {

        Application.Quit();

    }

    public void GameOver()
    {
        SceneManager.LoadScene(3);
    }
}
