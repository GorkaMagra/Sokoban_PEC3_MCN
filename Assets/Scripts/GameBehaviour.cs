using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBehaviour : MonoBehaviour
{
    bool ReadyForInput;
    public LevelEditor levelEditor;
    private PlayerBehaviour Player;


    private void Start()
    {
        ResetLevel(); //load the level by the first time.
    }

    private void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveInput.Normalize();
        if (moveInput.sqrMagnitude > 0.5) //check for player movements and answer to that imputs with the character moving to that direction.
        {
            if (ReadyForInput)
            {
                ReadyForInput = false;
                Player.IsMoving(moveInput);

                if (isLevelCompleted()) //check if the level is completed to progress to the next one.
                {
                    NextLevel();
                }
            }
        }
        else
            ReadyForInput = true;


    }


    public void ResetLevel() //reset the level to the initial state.
    {
        StartCoroutine(ResetLevelASync());
    }

    public void NextLevel() //load the next level in the scene.
    {
            levelEditor.NextLevel();
            StartCoroutine(ResetLevelASync());

    }

    public bool isLevelCompleted() //check if all the objectives have been "checked".
    {
        BoxBehaviour [] boxes = FindObjectsOfType<BoxBehaviour>();
        foreach(BoxBehaviour box in boxes)
        {
            if (!box.isInObjective)
                return false;
        }
        return true;
    }


    IEnumerator ResetLevelASync() //unload the last level and load the next one (or the same one if it is reseting) by asyncronous inner scene in the main scene.
    {
        if (SceneManager.sceneCount > 1)
        {
            AsyncOperation asynunload = SceneManager.UnloadSceneAsync("LevelReplacer"); //unload the innerScene (witch it is where all the map elements are)
            while (!asynunload.isDone)
            {
                yield return null;
            }
            Resources.UnloadUnusedAssets();
        }
        AsyncOperation asyncload = SceneManager.LoadSceneAsync("LevelReplacer", LoadSceneMode.Additive); //load the selected scene
        while (!asyncload.isDone)
        {
            yield return null;
        }
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("LevelReplacer"));
        levelEditor.Build(); //call the level editor to translate the txt to the ingame assets.
        Player = FindObjectOfType<PlayerBehaviour>(); //locate the player in the new level and select it to be able to move it.

    }

}
