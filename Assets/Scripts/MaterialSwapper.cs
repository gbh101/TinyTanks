using UnityEngine;
using System.Collections;

public class MaterialSwapper : MonoBehaviour
{
    public Material blue;
    public Material red;
    public Material action;
        
	public void RedBackground()
    {
        GetComponent<Renderer>().material = red;
    }

    public void BlueBackground()
    {
        GetComponent<Renderer>().material = blue;
    }

    public void ActionBackground()
    {
        GetComponent<Renderer>().material = action;
    }
}
