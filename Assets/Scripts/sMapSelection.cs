using UnityEngine;
using System.Collections;

public class sMapSelection : MonoBehaviour
{
    public void DualIslandDuel()
    {
        Application.LoadLevel("DualIslandDuel");
    }

    public void ThePlains()
    {
        Application.LoadLevel("ThePlains");
    }

    public void PrivateIslands()
    {
        Application.LoadLevel("PrivateIslands");
    }

    public void CloseQuarters()
    {
        Application.LoadLevel("CloseQuarters");
    }
}
