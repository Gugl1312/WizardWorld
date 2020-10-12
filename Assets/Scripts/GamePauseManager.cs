using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePauseManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject inventory;
    private bool paused = false;
    private bool lookingAtInventory = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))//U EDITORU NE RADI CURSOR LOCK JER SE NA ESCAPE UNLOCKUJE DA MOZE DA SE PAUZIRA IGRICA
        {
            if (paused)
            {
                pauseMenu.SetActive(false);
                paused = !paused;
                Debug.Log(Cursor.visible);
                Debug.Log(Cursor.lockState);
                Time.timeScale = 1;
                //Cursor.lockState = CursorLockMode.Locked;
                //Cursor.visible = false;
                StartCoroutine(LockCursor());
                Debug.Log(Cursor.visible);
                Debug.Log(Cursor.lockState);
            }
            else
            {
                Time.timeScale = 0;
                pauseMenu.SetActive(true);
                paused = !paused;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }            
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (lookingAtInventory)
            {
                inventory.SetActive(false);
                lookingAtInventory = !lookingAtInventory;
                Time.timeScale = 1;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else
            {
                inventory.SetActive(true);
                lookingAtInventory = !lookingAtInventory;
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }
    public IEnumerator LockCursor()
    {
        yield return 0;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Debug.Log(Cursor.visible);
        Debug.Log(Cursor.lockState);
    }
}
