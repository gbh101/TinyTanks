using UnityEngine;
using System.Collections;

public class HPAP_Tracker : MonoBehaviour
{
    public GameObject myTank;

    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;

    public GameObject bolt1;
    public GameObject bolt2;
    public GameObject bolt3;
	
	void Update ()
    {
        //Health visualization logic
        if (myTank.GetComponent<sTankLogic>().health < 1)
        {
            heart1.GetComponent<SpriteRenderer>().enabled = false;
            heart2.GetComponent<SpriteRenderer>().enabled = false;
            heart3.GetComponent<SpriteRenderer>().enabled = false;
        }
        else if (myTank.GetComponent<sTankLogic>().health < 2)
        {
            heart1.GetComponent<SpriteRenderer>().enabled = true;
            heart2.GetComponent<SpriteRenderer>().enabled = false;
            heart3.GetComponent<SpriteRenderer>().enabled = false;
        }
        else if (myTank.GetComponent<sTankLogic>().health < 3)
        {
            heart1.GetComponent<SpriteRenderer>().enabled = true;
            heart2.GetComponent<SpriteRenderer>().enabled = true;
            heart3.GetComponent<SpriteRenderer>().enabled = false;
        }
        else if (myTank.GetComponent<sTankLogic>().health == 3)
        {
            heart1.GetComponent<SpriteRenderer>().enabled = true;
            heart2.GetComponent<SpriteRenderer>().enabled = true;
            heart3.GetComponent<SpriteRenderer>().enabled = true;
        }

        //Action point visualization logic
        if (myTank.GetComponent<sTankLogic>().actionPoints < 1)
        {
            bolt1.GetComponent<SpriteRenderer>().enabled = false;
            bolt2.GetComponent<SpriteRenderer>().enabled = false;
            bolt3.GetComponent<SpriteRenderer>().enabled = false;
        }
        else if (myTank.GetComponent<sTankLogic>().actionPoints < 2)
        {
            bolt1.GetComponent<SpriteRenderer>().enabled = true;
            bolt2.GetComponent<SpriteRenderer>().enabled = false;
            bolt3.GetComponent<SpriteRenderer>().enabled = false;
        }
        else if (myTank.GetComponent<sTankLogic>().actionPoints < 3)
        {
            bolt1.GetComponent<SpriteRenderer>().enabled = true;
            bolt2.GetComponent<SpriteRenderer>().enabled = true;
            bolt3.GetComponent<SpriteRenderer>().enabled = false;
        }
        else if (myTank.GetComponent<sTankLogic>().actionPoints == 3)
        {
            bolt1.GetComponent<SpriteRenderer>().enabled = true;
            bolt2.GetComponent<SpriteRenderer>().enabled = true;
            bolt3.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
