using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TransitionAnimation : MonoBehaviour
{
    public GameObject transitionHub;

    public bool topSlot = false;
    public GameObject rotLeft;
    public GameObject rotRight;

    private Vector3 origin;
    public Transform destination;

    private int speed = 30;
    public int timer = 0;

    public Button endTurnButton;

    private void Start()
    {
        origin = transform.localPosition;

        endTurnButton = GameObject.Find("EndTurnButton").GetComponent<Button>();
    }

    void Update()
    {
        if (transitionHub.GetComponent<DeathTimer>().active == true)
        {
            endTurnButton.interactable = false;
            rotLeft.GetComponent<sRotateButton>().active = false;
            rotRight.GetComponent<sRotateButton>().active = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            float step = speed * Time.deltaTime;
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, destination.localPosition, step);
        }
        if(transform.localPosition == destination.localPosition)
        {
            if(timer >= 120)
            {
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                transform.localPosition = origin;
                transitionHub.GetComponent<DeathTimer>().active = false;
                timer = 0;
                if(topSlot)
                {
                    endTurnButton.interactable = true;
                    rotLeft.GetComponent<sRotateButton>().active = true;
                    rotRight.GetComponent<sRotateButton>().active = true;
                }
            }
            timer++;
        }
    }
}
