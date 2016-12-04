using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class sTutorialLogic : MonoBehaviour
{
    public GameObject tutorialImage;

    public Sprite intro;
    public Sprite actions;
    public Sprite strategies;

    public Button leftArrow;
    public Button rightArrow;

    void Awake()
    {
        tutorialImage.GetComponent<Image>().sprite = intro;
    }

    void Update()
    {
        //left arrow usability
        if(tutorialImage.GetComponent<Image>().sprite == intro)
        {
            leftArrow.interactable = false;
        }
        else
        {
            leftArrow.interactable = true;
        }

        //right arrow usability
        if (tutorialImage.GetComponent<Image>().sprite == strategies)
        {
            rightArrow.interactable = false;
        }
        else
        {
            rightArrow.interactable = true;
        }
    }

    public void ArrowRight()
    {
        if (tutorialImage.GetComponent<Image>().sprite == intro)
        {
            tutorialImage.GetComponent<Image>().sprite = actions;
        }
        else if (tutorialImage.GetComponent<Image>().sprite == actions)
        {
            tutorialImage.GetComponent<Image>().sprite = strategies;
        }
    }

    public void ArrowLeft()
    {
        if (tutorialImage.GetComponent<Image>().sprite == strategies)
        {
            tutorialImage.GetComponent<Image>().sprite = actions;
        }
        else if (tutorialImage.GetComponent<Image>().sprite == actions)
        {
            tutorialImage.GetComponent<Image>().sprite = intro;
        }
    }
}
