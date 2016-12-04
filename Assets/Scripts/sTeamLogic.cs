using UnityEngine;
using System.Collections;

public class sTeamLogic : MonoBehaviour
{
    public enum Team
    {
        Red, Blue
    }
    public Team team;

    public int tankCount;

    public bool myTurn = false;

    public string otherTeamVictoryLevel;

    public bool redVictory = false;
    public bool blueVictory = false;

    public void TankDestroyed()
    {
        tankCount -= 1;
        if(tankCount <= 0)
        {
            if(team == Team.Red)
            {
                blueVictory = true;
            }
            if(team == Team.Blue)
            {
                redVictory = true;
            }
        }
    }
}
