using UnityEngine;
using System.Collections;

public class sVisualizerLogic : MonoBehaviour
{
    public GameObject boomBox;
    public GameObject muter;

    public GameObject healVis;
    public GameObject attVis;
    public GameObject movVis;

    private string interactionType;

    private bool moved = false;
    private int attacked = 0;
    private int healed = 0;

    private Transform prevLocation;
    private Transform newLocation;

    private GameObject[] myTanks;

    private bool actionPhase = false;

    void Awake()
    {
        boomBox = GameObject.FindGameObjectWithTag("BOOM");
    }
    
    void Update()
    {
        GameObject[] aTanks = GameObject.FindGameObjectsWithTag("Tank");

        if (actionPhase == true)
        {
            // Ensures that no two tanks are in the same space
            for (int i = 0; i < aTanks.Length; i++)
            {
                for (int j = 0; j < aTanks.Length; j++)
                {
                    if (aTanks[i] != aTanks[j])
                    {
                        if (aTanks[i].GetComponent<sTankLogic>().newLocation == aTanks[j].GetComponent<sTankLogic>().newLocation)
                        {
                            aTanks[i].GetComponent<sTankLogic>().TankDestruction();
                            aTanks[j].GetComponent<sTankLogic>().TankDestruction();

                            GameObject vis = Instantiate(attVis, new Vector3(aTanks[i].GetComponent<sTankLogic>().newLocation.x, aTanks[i].GetComponent<sTankLogic>().newLocation.y + 0.3f, aTanks[i].GetComponent<sTankLogic>().newLocation.z), Quaternion.identity) as GameObject;
                        }
                    }
                }
            }
            actionPhase = false;
        }
    }

    public void ResetBools()
    {
        moved = false;
        attacked = 0;
        healed = 0;
    }

    void OnMouseDown()
    {
        VisualOff();

        GameObject[] aTanks = GameObject.FindGameObjectsWithTag("Tank");
        
        // Movement Logic
        if (interactionType == "Move")
        {
            for (int i = 0; i < aTanks.Length; i++)
            {
                if (aTanks[i].GetComponent<sTankLogic>().active)
                {
                    float distance = Vector3.Distance(transform.position, aTanks[i].transform.position);
                    //Sets previous location for use if tanks collide
                    aTanks[i].GetComponent<sTankLogic>().previousLocation = aTanks[i].transform.position;
                    //Sets new location for tank movement during action phase
                    aTanks[i].GetComponent<sTankLogic>().newLocation = transform.position;
                    moved = true;
                    
                    //Moves the tank visually, to be reset when 'Submit Turn' button is pressed
                    aTanks[i].GetComponent<UnityEngine.AI.NavMeshAgent>().SetDestination(aTanks[i].GetComponent<sTankLogic>().newLocation);
                    aTanks[i].GetComponent<UnityEngine.AI.NavMeshAgent>().updateRotation = false;
                    
                    //Instantiates tank movement visual, REMOVED 2 Lines (Obsolete due to tank movement)
                    //GameObject vis = Instantiate(movVis, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                    //vis.transform.position = transform.position;

                    if (muter.GetComponent<AudioButtons>().muted == false)
                    {
                        boomBox.GetComponent<DontDestroyOnLoad>().SoundFX(2);
                    }
                }
            }
        }
        else if(interactionType == "Attack")
        {
            attacked += 1;
            GameObject vis = Instantiate(attVis, new Vector3(transform.position.x, transform.position.y + 0.3f, transform.position.z), Quaternion.identity) as GameObject;

            if (muter.GetComponent<AudioButtons>().muted == false)
            {
                boomBox.GetComponent<DontDestroyOnLoad>().SoundFX(1);
            }
        }
        else if(interactionType == "Heal")
        {
            healed += 1;
            GameObject vis = Instantiate(healVis, new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z), Quaternion.identity) as GameObject;

            if (muter.GetComponent<AudioButtons>().muted == false)
            {
                boomBox.GetComponent<DontDestroyOnLoad>().SoundFX(3);
            }
        }
        else
        {
            Debug.Log("Interaction type not defined: " + interactionType);
        }

        for (int i = 0; i < aTanks.Length; i++)
        {
            if (aTanks[i].GetComponent<sTankLogic>().active == true)
            {
                aTanks[i].GetComponent<sTankLogic>().actionPoints -= 1;
            }
        }
    }

    public void ActionPhaseLogic()
    {
        GameObject[] aTanks = GameObject.FindGameObjectsWithTag("Tank");
        
        if(attacked >= 1)
        {
            GameObject vis = Instantiate(attVis, new Vector3(transform.position.x, transform.position.y + 0.3f, transform.position.z), Quaternion.identity) as GameObject;
        }
        if (healed >= 1)
        {
            GameObject vis = Instantiate(healVis, new Vector3(transform.position.x, transform.position.y + 0.3f, transform.position.z), Quaternion.identity) as GameObject;
        }


        // Moves Tanks to new locations
        if (moved == true)
        {
            for (int x = 0; x < aTanks.Length; x++)
            {
                aTanks[x].GetComponent<UnityEngine.AI.NavMeshAgent>().SetDestination(aTanks[x].GetComponent<sTankLogic>().newLocation);
                aTanks[x].GetComponent<UnityEngine.AI.NavMeshAgent>().updateRotation = false;
                actionPhase = true;
            }
        }

        // Deals with healing logic before damage is dealt
        if (healed >= 1)
        {
            for (int i = 0; i < aTanks.Length; i++)
            {
                if (aTanks[i].GetComponent<sTankLogic>().newLocation == transform.position)
                {
                    for (int j = healed; j > 0; j--)
                    {
                        aTanks[i].GetComponent<sTankLogic>().TakeHealing();
                    }
                }
            }
        }

        // Then Deals with attacking logic
        if (attacked >= 1)
        {
            for (int i = 0; i < aTanks.Length; i++)
            {
                if (aTanks[i].GetComponent<sTankLogic>().newLocation == transform.position)
                {
                    for(int j = attacked; j > 0; j--)
                    {
                        aTanks[i].GetComponent<sTankLogic>().TakeDamage();
                    }
                }
            }
        }
        // Makes sure that health does not exceed 3 or that a tank has not died
        //if (attacked >= 1 || healed >= 1)
        //{
            for (int i = 0; i < aTanks.Length; i++)
            {
                //if (aTanks[i].transform.position == transform.position)
                //{
                    aTanks[i].GetComponent<sTankLogic>().RoundEnd();
               // }
            }
        //}
    }

    public void AssignInteraction(string assignedType)
    {
        interactionType = assignedType;
        VisualOn();
    }

    public void VisualOn()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<BoxCollider>().enabled = true;
    }

    public void VisualOff()
    {
        GameObject[] aVis = GameObject.FindGameObjectsWithTag("Visualizer");

        for (int i = 0; i < aVis.Length; i++)
        {
            aVis[i].GetComponent<SpriteRenderer>().enabled = false;
            aVis[i].GetComponent<BoxCollider>().enabled = false;
        }
    }
}
