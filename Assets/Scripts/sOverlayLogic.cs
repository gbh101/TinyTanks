using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class sOverlayLogic : MonoBehaviour
{
    public GameObject bluePlayer;
    public GameObject redPlayer;

    public GameObject myButton;
    private Button datButton;

    public GameObject redTransition;
    public GameObject blueTransition;
    //public GameObject actionTransition;

    public GameObject background;

    private int timer = 0;
    private int timeToActive = 90;
    private bool buttonActive = true;

    void Awake()
    {
        myButton.GetComponent<Text>().text = "Submit Turn";
        datButton = GameObject.Find("EndTurnButton").GetComponent<Button>();
    }

    void Update()
    {
        if(buttonActive == false)
        {
            if(timer >= timeToActive)
            {
                datButton.interactable = true;
                timer = 0;
                buttonActive = true;
            }
            timer++;
        }

        if(bluePlayer.GetComponent<sTeamLogic>().redVictory == true && redPlayer.GetComponent<sTeamLogic>().blueVictory == true)
        {
            //MutualDestruction
            myButton.GetComponent<Text>().text = "Mutual Destruction";
        }
        else if(bluePlayer.GetComponent<sTeamLogic>().redVictory == true)
        {
            //RedVictory
            myButton.GetComponent<Text>().text = "Red Victory";
        }
        else if(redPlayer.GetComponent<sTeamLogic>().blueVictory == true)
        {
            //BlueVictory
            myButton.GetComponent<Text>().text = "Blue Victory";
        }
    }

    public void EndTurnButton()
    {
        if (myButton.GetComponent<Text>().text == "Mutual Destruction")
        {
            Application.LoadLevel("MutualDestruction");
        }
        else if (myButton.GetComponent<Text>().text == "Red Victory")
        {
            Application.LoadLevel("RedVictory");
        }
        else if (myButton.GetComponent<Text>().text == "Blue Victory")
        {
            Application.LoadLevel("BlueVictory");
        }

        else
        {
            // Deactivates all Tanks
            GameObject[] aTanks = GameObject.FindGameObjectsWithTag("Tank");
            for (int i = 0; i < aTanks.Length; i++)
            {
                aTanks[i].GetComponent<sTankLogic>().Deactivate();
            }

            // Deactivates all visualizers
            GameObject[] aVis = GameObject.FindGameObjectsWithTag("Visualizer");
            for (int i = 0; i < aVis.Length; i++)
            {
                aVis[i].GetComponent<SpriteRenderer>().enabled = false;
                aVis[i].GetComponent<BoxCollider>().enabled = false;
            }

            //Destroys all action visualizers
            GameObject[] aVis2 = GameObject.FindGameObjectsWithTag("Vis2");
            for (int i = 0; i < aVis2.Length; i++)
            {
                Destroy(aVis2[i]);
            }

            // Switches to Red's Turn
            if (bluePlayer.GetComponent<sTeamLogic>().myTurn == true)
            {
                for (int i = 0; i < aTanks.Length; i++)
                {
                    aTanks[i].GetComponent<UnityEngine.AI.NavMeshAgent>().SetDestination(aTanks[i].GetComponent<sTankLogic>().startLocation);
                    aTanks[i].transform.position = aTanks[i].GetComponent<sTankLogic>().startLocation;
                }
                redTransition.GetComponent<DeathTimer>().active = true;
                background.GetComponent<MaterialSwapper>().RedBackground();
                bluePlayer.GetComponent<sTeamLogic>().myTurn = false;
                redPlayer.GetComponent<sTeamLogic>().myTurn = true;
            }
            // Switches to Action Phase
            else if (redPlayer.GetComponent<sTeamLogic>().myTurn == true)
            {
                for (int i = 0; i < aTanks.Length; i++)
                {
                    aTanks[i].GetComponent<UnityEngine.AI.NavMeshAgent>().SetDestination(aTanks[i].GetComponent<sTankLogic>().startLocation);
                    aTanks[i].transform.position = aTanks[i].GetComponent<sTankLogic>().startLocation;
                }
                bluePlayer.GetComponent<sTeamLogic>().myTurn = false;
                redPlayer.GetComponent<sTeamLogic>().myTurn = false;
                background.GetComponent<MaterialSwapper>().ActionBackground();
                // Changes button text
                myButton.GetComponent<Text>().text = "End Action Phase";
                datButton.interactable = false;
                buttonActive = false;
                // Begins action phase
                ActionPhase();
            }
            // Switches to Blue's Turn
            else if (bluePlayer.GetComponent<sTeamLogic>().myTurn == false && redPlayer.GetComponent<sTeamLogic>().myTurn == false)
            {
                blueTransition.GetComponent<DeathTimer>().active = true;
                background.GetComponent<MaterialSwapper>().BlueBackground();
                bluePlayer.GetComponent<sTeamLogic>().myTurn = true;
                redPlayer.GetComponent<sTeamLogic>().myTurn = false;
                // Changes button text
                myButton.GetComponent<Text>().text = "Submit Turn";

                // Gives Each Tank an Action Point and sets their startLocation to their current position
                for (int i = 0; i < aTanks.Length; i++)
                {
                    if (aTanks[i].GetComponent<sTankLogic>().actionPoints < 3)
                    {
                        aTanks[i].GetComponent<sTankLogic>().actionPoints += 1;
                        //aTanks[i].GetComponent<sTankLogic>().RoundEnd();
                    }
                    aTanks[i].GetComponent<sTankLogic>().startLocation = aTanks[i].GetComponent<sTankLogic>().newLocation;
                    aTanks[i].GetComponent<sTankLogic>().roundEnded = false;
                }

                EndActionPhase();
            }
        }
    }

    public void ActionPhase()
    {
        GameObject[] aTiles = GameObject.FindGameObjectsWithTag("TileTopper");
        for (int i = 0; i < aTiles.Length; i++)
        {
            aTiles[i].transform.GetChild(0).GetComponent<sVisualizerLogic>().ActionPhaseLogic();
        }
    }

    private void EndActionPhase()
    {
        GameObject[] aTiles = GameObject.FindGameObjectsWithTag("TileTopper");
        for (int i = 0; i < aTiles.Length; i++)
        {
            aTiles[i].transform.GetChild(0).GetComponent<sVisualizerLogic>().ResetBools();
        }
    }
}