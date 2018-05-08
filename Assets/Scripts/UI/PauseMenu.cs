/** Written by Bryan Hyland **/
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using XInputDotNetPure;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] Canvas pauseMenu;

    bool isPaused = false;

    void Awake()
    {
        // Ensure the pause menu is disabled at the start of the game
        pauseMenu.enabled = false;
    }

    void Update()
    {
        GamePadState state = GamePad.GetState(PlayerIndex.One);

        // If esc is pressed call enable menu
        if (Input.GetKeyDown(KeyCode.Escape) || state.Buttons.Start == ButtonState.Pressed && !isPaused)
            EnableMenu();
    }

    void FixedUpdate()
    {
        if (EventSystem.current.currentSelectedGameObject == null)
            EventSystem.current.SetSelectedGameObject(EventSystem.current.firstSelectedGameObject);
    }

    // Pause/Unpause the game and show the menu
    public void DisableMenu()
    {
        isPaused = false;
        pauseMenu.enabled = false;
        Time.timeScale = 1f;
    }

    void EnableMenu()
    {
        isPaused = true;
        pauseMenu.enabled = true;
        Time.timeScale = 0f;
    }

    // Quit the game
    public void QuitGame()
    {
        Application.Quit();
    }

    // Start a new game
    public void StartOver()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("FinalScene");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
