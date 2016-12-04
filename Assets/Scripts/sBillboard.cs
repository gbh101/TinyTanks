using UnityEngine;
using System.Collections;

public class sBillboard : MonoBehaviour
{
	void Update ()
    {
        transform.LookAt(Camera.main.transform.position, Vector3.up);
	}
}
