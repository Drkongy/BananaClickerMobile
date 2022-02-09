using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
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
        Application.OpenURL("https://discord.gg/cYCsDfyPAv");  // connects to discord server.
    }

    public void pause()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1); // changes from main menu to the actual game.
    }


    public void resetData(){
        DirectoryInfo dataDir = new DirectoryInfo(Application.persistentDataPath); // cleares all of the data files that are in the persistantdatapath.
        dataDir.Delete(true); 
    }

    public void btnPrestige(){
        string filePath = Application.persistentDataPath + "/PlayTime.json";
        File.Delete(filePath);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1); // changes from main menu to the actual game.

    }




}
