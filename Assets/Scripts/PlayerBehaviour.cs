using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    public bool IsMoving(Vector2 direction)
    {
        if (Mathf.Abs(direction.x) < 0.5) //This will prevent the player to move "diagonally".
        {
            direction.x = 0;
        }
        else
            direction.y = 0;


        direction.Normalize(); //This will make the player move only 1 unit.


        if (IsBlocked(transform.position, direction)){ //If the player is blocked (by another tile) he wont move.
            return false;
        }else
        {
            transform.Translate(direction);
            return true;
        }

    }

    bool IsBlocked(Vector3 position, Vector2 direction)
    {
        Vector2 newPos = new Vector2(position.x, position.y) + direction;
        GameObject[] walls = GameObject.FindGameObjectsWithTag("Brick"); //Find all gameobjects tagged as "bricks"
        foreach (GameObject wall in walls)
        {
            if (wall.transform.position.x == newPos.x && wall.transform.position.y == newPos.y)
            {
                return true; //if the position the player is going is the same as the position of a brick, It wont move, because the path is blocked.
            }
        }

        GameObject[] boxes = GameObject.FindGameObjectsWithTag("Box"); //Find all gameobject tagged as "box"
        foreach(GameObject box in boxes)
        {
            if(box.transform.position.x == newPos.x && box.transform.position.y == newPos.y)
            {
                BoxBehaviour boxBehaviour = box.GetComponent<BoxBehaviour>();
                if (boxBehaviour && boxBehaviour.IsMoving(direction)) //If the face the direction the box is facing is without bricks, the player will move with the box, otherwise, it will be blocked.
                {
                    return false;
                }
                else
                    return true;
            }
        
        }
        return false;
    }
}
