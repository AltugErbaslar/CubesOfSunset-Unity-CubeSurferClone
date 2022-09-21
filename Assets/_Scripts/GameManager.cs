using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    public GameObject startUI;
    private Stacker stackerScript;
    [SerializeField] private Button restartButton;
    [SerializeField] private TextMeshProUGUI endGameScoreText;
    [SerializeField] private Button startButton;
    [SerializeField] private GameObject joystickCanvas;
    [SerializeField] private GameObject endUI;
    private void Start()
    {
        stackerScript = GameObject.Find("Stacker").GetComponent<Stacker>();
        startButton.onClick.AddListener(StartGame);
    }

    private void Update()
    {
        GameOver();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        if (stackerScript.stackParent.childCount == 0)
        {
            
            endGameScoreText.text = "YOUR SCORE\n" + stackerScript.money;
            stackerScript.moneyText.gameObject.SetActive(false);
            endUI.gameObject.SetActive(true);
            joystickCanvas.gameObject.SetActive(false);
        }
        
    }

    public void Succes()
    {
        endGameScoreText.text = "YOUR SCORE\n" + stackerScript.money;
        stackerScript.moneyText.gameObject.SetActive(false);
        endUI.gameObject.SetActive(true);
        joystickCanvas.gameObject.SetActive(false);
        stackerScript.isGameActive = false;

    }

    void StartGame()
    {
        startUI.gameObject.SetActive(false);
        stackerScript.isGameActive = true;
        joystickCanvas.gameObject.SetActive(true);
        
    }
   
}
