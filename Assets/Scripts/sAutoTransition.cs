using UnityEngine;
using System.Collections;

public class sAutoTransition : MonoBehaviour
{
    public string levelToLoad;

    public int timeToSwitch = 300;
    private int timer = 0;

    void Update ()
    {
	    if(Input.anyKeyDown || timer >= timeToSwitch)
        {
            Application.LoadLevel(levelToLoad);
        }
        timer++;
	}
}
