using UnityEngine;
using System.Collections;

public class sRotateButton : MonoBehaviour
{
    public enum RotateDirection
    {
        Left, Right
    }
    public RotateDirection direction;

    public GameObject camPivot;
    public bool active = true;

    private void OnMouseOver()
    {
        if(active)
        {
            if (direction == RotateDirection.Left)
            {
                camPivot.GetComponent<sCamRotate>().RotateLeft();
            }
            if (direction == RotateDirection.Right)
            {
                camPivot.GetComponent<sCamRotate>().RotateRight();
            }
        }
    }
}
