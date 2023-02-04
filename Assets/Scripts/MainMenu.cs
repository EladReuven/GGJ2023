using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Button startButton;

    void OnStart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    // Start is called before the first frame update

    void Start()
    {
        AudioManager.instance.PlaySound("menutheme", true);
        startButton.onClick.AddListener(OnStart);   
    }

}
