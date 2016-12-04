using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class sTileLogic : MonoBehaviour
{
    // For choosing the shape of the object
    public enum TileType
    {
        Land, Water, Bridge
    }
    public TileType tileType;

    public Material landMat;
    public Material waterMat;
    public Material bridgeMat;

    public bool walkable = true;

    void Start ()
    {
        if (tileType == TileType.Land)
        {
            GetComponent<Renderer>().material = landMat;
            walkable = true;
        }
        else if (tileType == TileType.Water)
        {
            GetComponent<Renderer>().material = waterMat;
            walkable = false;
        }
        else if (tileType == TileType.Bridge)
        {
            GetComponent<Renderer>().material = bridgeMat;
            walkable = true;
        }
        else
        {
            Debug.Log(gameObject.name + " is assigned an invalid tile type");
        }
    }
}
