/** Written by Bryan Hyland **/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour 
{
    [SerializeField] Canvas mainMenu;

    void FixedUpdate()
    {
        if (EventSystem.current.currentSelectedGameObject == null)
            EventSystem.current.SetSelectedGameObject(EventSystem.current.firstSelectedGameObject);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("FinalScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
