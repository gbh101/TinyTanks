using UnityEngine;
using System.Collections;

public class sMainMenuLogic : MonoBehaviour
{
    public string mapSelect;
    public string tutorial;
    public string credits;

    public void MapSelection()
    {
        Application.LoadLevel(mapSelect);
    }

    public void Tutorial()
    {
        Application.LoadLevel(tutorial);
    }

    public void Credits()
    {
        Application.LoadLevel(credits);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        Application.LoadLevel("MainMenu");
    }
}
