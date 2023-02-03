using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private Button ResumeButton;
    [SerializeField] private Button ExitButton;
    [SerializeField] private CanvasRenderer pauseMenu;
    [SerializeField] private TurretController turretControler;
    [SerializeField] private rootMovement rootMovement;

    void TogglePause()
    {
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        turretControler.enabled= !turretControler.enabled;
        rootMovement.enabled = !rootMovement.enabled;

    }
    void TogglePauseMenunOpen()
    {
        TogglePause();
        TogglePauseMenuVisible();
    }
    void TogglePauseMenuVisible()
    {
        pauseMenu.gameObject.SetActive(!pauseMenu.gameObject.activeSelf);
    }
    void SwitchToMainMenu()
    {
        SceneManager.LoadScene(1);
    }

    // Start is called before the first frame update
    void Start()
    {
        ExitButton.onClick.AddListener(SwitchToMainMenu);
        ResumeButton.onClick.AddListener(TogglePauseMenunOpen);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenunOpen();
        }
    }
}
