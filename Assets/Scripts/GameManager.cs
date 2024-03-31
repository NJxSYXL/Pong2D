using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Variable Score")]
    public int PlayerScoreL = 0;
    public int PlayerScoreR = 0;

    [Header("Text Score")]
    public TMP_Text txtPlayerScoreL;
    public TMP_Text txtPlayerScoreR;

    [Header("Panel Player Win")]
    public GameObject panelWin;
    public TMP_Text playerWin;

    public static GameManager instance;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        panelWin.SetActive(false);
        txtPlayerScoreL.text = PlayerScoreL.ToString();
        txtPlayerScoreR.text = PlayerScoreR.ToString();
    }

    public void Score(string wallID)
    {
        if (wallID == "LineL")
        {
            //StartCoroutine(ShakeCam(0.7f));
            PlayerScoreR = PlayerScoreR + 20;
            txtPlayerScoreR.text = PlayerScoreR.ToString();
            ScoreCheck();
        }
        else
        {
            //StartCoroutine(ShakeCam(0.7f));
            PlayerScoreL = PlayerScoreL + 20;
            txtPlayerScoreL.text = PlayerScoreL.ToString();
            ScoreCheck();
        }

        GameObject.Find("Racket_Player").GetComponent<PlayerControls>().ResetPosition();
    }

    public void ScoreCheck()
    {
        if (PlayerScoreL == 100)
        {
            //Debug.Log("playerL win");
            panelWin.SetActive(true);
            playerWin.text = "YOU WIN!";
            Invoke("ChangeTheScene", 2f);
            //this.gameObject.SendMessage("ChangeScene", "MainMenu");
        }
        else if (PlayerScoreR == 100)
        {
            //Debug.Log("playerR win");
            panelWin.SetActive(true);
            playerWin.text = "YOU LOSE!";
            Invoke("ChangeTheScene", 2f);
            //this.gameObject.SendMessage("ChangeScene", "MainMenu");
        }
    }

    private void ChangeTheScene()
    {
        this.gameObject.SendMessage("ChangeScene", "MainMenu");
    }
}