using UnityEngine;
using System.Collections;

public class sTankLogic : MonoBehaviour
{
    public int health = 3;
    public int actionPoints = 2;

    public GameObject teamLogic;

    public bool active = false;
    public bool spent = false;

    public GameObject attackButton;
    public GameObject healButton;
    public GameObject moveButton;

    public Vector3 startLocation;
    public Vector3 newLocation;
    public Vector3 previousLocation;

    public GameObject deathExplosion;

    public bool roundEnded = false;

    public GameObject collisionIndicator;

    void Awake()
    {
        ButtonDisable();
        Transform myPos = gameObject.transform;
        startLocation = myPos.position;
        previousLocation = myPos.position;
        newLocation = myPos.position;
    }

    public void ButtonEnable()
    {
        attackButton.GetComponent<SpriteRenderer>().enabled = true;
        healButton.GetComponent<SpriteRenderer>().enabled = true;
        moveButton.GetComponent<SpriteRenderer>().enabled = true;
        attackButton.GetComponent<BoxCollider>().enabled = true;
        healButton.GetComponent<BoxCollider>().enabled = true;
        moveButton.GetComponent<BoxCollider>().enabled = true;
    }

    public void ButtonDisable()
    {
        attackButton.GetComponent<SpriteRenderer>().enabled = false;
        healButton.GetComponent<SpriteRenderer>().enabled = false;
        moveButton.GetComponent<SpriteRenderer>().enabled = false;
        attackButton.GetComponent<BoxCollider>().enabled = false;
        healButton.GetComponent<BoxCollider>().enabled = false;
        moveButton.GetComponent<BoxCollider>().enabled = false;
    }

    void OnMouseDown()
    {
        if (teamLogic.GetComponent<sTeamLogic>().myTurn)
        {
            if (actionPoints > 0)
            {
                active = true;
                ButtonEnable();

                // Deactivates all other tanks on team
                GameObject[] aTanks = GameObject.FindGameObjectsWithTag("Tank");
                for (int i = 0; i < aTanks.Length; i++)
                {
                    if (aTanks[i] != gameObject)
                    {
                        aTanks[i].GetComponent<sTankLogic>().Deactivate();
                    }
                }

                // Deactivates all visualizers
                GameObject[] aVis = GameObject.FindGameObjectsWithTag("Visualizer");
                for (int i = 0; i < aVis.Length; i++)
                {
                    aVis[i].GetComponent<SpriteRenderer>().enabled = false;
                    aVis[i].GetComponent<BoxCollider>().enabled = false;
                }
            }
        }
    }

    public void Deactivate()
    {
        active = false;
        ButtonDisable();
    }

    public void RoundStart()
    {
        actionPoints += 1;
        if(actionPoints > 3)
        {
            actionPoints = 3;
        }
    }

    public void RoundEnd()
    {
        if (health > 3)
        {
            health = 3;
        }
    }

    public void TakeDamage()
    {
        health -= 1;

        if (health < 1)
        {
            teamLogic.GetComponent<sTeamLogic>().TankDestroyed();
            Instantiate(deathExplosion, newLocation, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    public void TankDestruction()
    {
        teamLogic.GetComponent<sTeamLogic>().TankDestroyed();
        Instantiate(deathExplosion, newLocation, Quaternion.identity);
        Destroy(gameObject);
    }

    public void TakeHealing()
    {
        health += 1;
    }
}
