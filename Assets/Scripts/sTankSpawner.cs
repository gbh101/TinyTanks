using UnityEngine;
using System.Collections;

public class sTankSpawner : MonoBehaviour
{
    public GameObject tank;
    public GameObject teamLogic;

    void Awake()
    {
        GameObject newTank = (GameObject) Instantiate(tank, transform.position, transform.rotation);
        newTank.GetComponent<sTankLogic>().teamLogic = teamLogic;
        teamLogic.GetComponent<sTeamLogic>().tankCount += 1;
    }
}
