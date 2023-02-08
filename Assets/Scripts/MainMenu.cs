using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Button startButton;

    public void OnStart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
        AudioManager.instance.PauseSound("maintheme");
        AudioManager.instance.UnpauseSound("menutheme");
    }
    // Start is called before the first frame update

    //void Start()
    //{
    //    startButton.onClick.AddListener(OnStart);   
    //}

    public void Quit()
    {
        Application.Quit();
    }

}
