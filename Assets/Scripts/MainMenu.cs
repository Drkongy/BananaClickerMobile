using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void quit()
    {
        Debug.Log("Game has quit");
        Application.Quit();
    }


    public void discord()
    {
        Application.OpenURL("https://discord.gg/cYCsDfyPAv");
    }

    public void pause()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }




}
