﻿using UnityEngine;
using System.Collections;

public class sMoveLogic : MonoBehaviour
{
    public GameObject tank;

    public void OnMouseDown()
    {
        tank.GetComponent<sTankLogic>().ButtonDisable();
        
        GameObject[] aTiles = GameObject.FindGameObjectsWithTag("TileTopper");
        for (int i = 0; i < aTiles.Length; i++)
        {
            if (aTiles[i].transform.parent.GetComponent<sTileLogic>().walkable == true)
            {
                float distance = Vector3.Distance(aTiles[i].transform.position, tank.transform.position);

                if (distance <= 1.5 && distance > 0.5)
                {
                    GameObject tileChild = aTiles[i].transform.GetChild(0).gameObject;

                    tileChild.GetComponent<sVisualizerLogic>().AssignInteraction("Move");
                    tileChild.GetComponent<SpriteRenderer>().color = Color.blue;
                }
            }
        }
    }
}