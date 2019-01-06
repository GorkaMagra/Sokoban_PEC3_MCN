using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBehaviour : MonoBehaviour
{
    public bool isInObjective;

    public bool IsMoving(Vector2 direction)
    {
        if (IsBlocked(transform.position, direction))
        {
            return false;
        } else
        {
            transform.Translate(direction); //move the box in that direction
            IsInObjective(); //check if it is in an objective
            return true;
        }
    }

    public bool IsBlocked(Vector3 position, Vector2 direction) //if it is facing a wall the direction it is moving, it will be blocked.
    {
        Vector2 newPos = new Vector2(position.x, position.y) + direction;
        GameObject[] walls = GameObject.FindGameObjectsWithTag("Brick");
        foreach(GameObject wall in walls)
        {
            if (wall.transform.position.x == newPos.x && wall.transform.position.y == newPos.y)
                return true;

        }
        GameObject[] boxes = GameObject.FindGameObjectsWithTag("Box"); // other boxes will count as blocked path also.
        foreach (GameObject box in boxes) {
            if (box.transform.position.x == newPos.x && box.transform.position.y == newPos.y)
                return true;

        }        
        return false;
    }

    public void IsInObjective() //if it is inside an objective check as in objective towards the objective requierements of the map.
    {
        GameObject[] objectives = GameObject.FindGameObjectsWithTag("Objective");
        foreach(var objective in objectives)
        {
            if(transform.position.x == objective.transform.position.x && transform.position.y == objective.transform.position.y)
            {
                isInObjective = true;
                return;
            }
        }
        isInObjective = false;
    }


}
