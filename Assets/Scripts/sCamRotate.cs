using UnityEngine;
using System.Collections;

public class sCamRotate : MonoBehaviour
{
    public float speed = 0.1f;

    void Update ()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            RotateLeft();
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            RotateRight();
        }
	}

    public void RotateRight()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x,
                            (transform.rotation.eulerAngles.y - 60f * Time.deltaTime * speed),
                            transform.rotation.eulerAngles.z);
    }

    public void RotateLeft()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x,
                            (transform.rotation.eulerAngles.y + 60f * Time.deltaTime * speed),
                                transform.rotation.eulerAngles.z);
    }
}
