using UnityEngine;
using System.Collections;

public class QuitGame : MonoBehaviour
{
	public void Quit ()
    {
        Application.LoadLevel("MainMenu");
	}

    public void MapSelect()
    {
        Application.LoadLevel("MainMenu"); ;
    }

    public void Credits()
    {
        Application.LoadLevel("Credits");
    }

    public void RealQuit()
    {
        Application.Quit();
    }
}
