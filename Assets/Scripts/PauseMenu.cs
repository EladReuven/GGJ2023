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
    [SerializeField] private Image GameOver;
    [SerializeField] private CanvasRenderer pauseMenu;
    [SerializeField] private TurretController turretControler;
    [SerializeField] private rootMovement rootMovement;
    [SerializeField] private GameObject aimWall;

    bool paused = false;

    void TogglePause()
    {
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        turretControler.enabled= !turretControler.enabled;
        rootMovement.enabled = !rootMovement.enabled;
        aimWall.SetActive(!aimWall.active);


    }
    void TogglePauseMenunOpen()
    {
        if (!paused)
        {
            AudioManager.instance.PauseSound("maintheme");
            AudioManager.instance.UnpauseSound("menutheme");
            paused = !paused;
        }
        else
        {
            AudioManager.instance.PauseSound("menutheme");
            AudioManager.instance.UnpauseSound("maintheme");
            paused = !paused;

        }
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
        GameOver.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //if(!paused)
            //{
            //    AudioManager.instance.PauseSound("maintheme");
            //    AudioManager.instance.UnpauseSound("menutheme");
            //    paused = !paused;
            //}
            //else
            //{
            //    AudioManager.instance.PauseSound("menutheme");
            //    AudioManager.instance.UnpauseSound("maintheme");
            //    paused = !paused;

            //}
            TogglePauseMenunOpen();
        }

        if(!GameManager.Instance.isAlive)
        {
            GameOver.gameObject.SetActive(true);
            turretControler.enabled = false;
            rootMovement.enabled = false;
            aimWall.SetActive(false);
            pauseMenu.gameObject.SetActive(true);
            ResumeButton.gameObject.SetActive(false);
            Time.timeScale = Time.timeScale = 0;
            AudioManager.instance.PauseSound("maintheme");
            AudioManager.instance.UnpauseSound("menutheme");

        }
    }
}
