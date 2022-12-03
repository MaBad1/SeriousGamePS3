using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UILvl2 : MonoBehaviour
{
    [SerializeField] Text moveLimitLvlDeux;
    [SerializeField] GameObject next2B;
    [SerializeField] GameObject boxBagOpenLvlDeux;
    [SerializeField] GameObject boxBagCloseLvlDeux;
    [SerializeField] GameObject boxGrainesLvlDeux;
    [SerializeField] GameObject boxOptions;
    [SerializeField] GameObject optionsB;
    [SerializeField] GameObject muteB;
    [SerializeField] GameObject indiceIco;
    [SerializeField] GameObject bagClose;
    [SerializeField] GameObject backB;
    [SerializeField] GameObject optionsBack;
    [SerializeField] GameObject homeB;
    [SerializeField] GameObject clue;
    [SerializeField] GameObject restartB;
    [SerializeField] GameObject retryB;
    [SerializeField] GameObject gameOver;
    [SerializeField] GameObject victory;
    [SerializeField] GameObject boxStarEmpty;
    [SerializeField] GameObject star1;
    [SerializeField] GameObject star2;
    [SerializeField] GameObject star3;
    [SerializeField] GameObject perfect;

    [SerializeField] GameObject graineDeux1;
    [SerializeField] GameObject graineDeux2;
    [SerializeField] GameObject graineDeux3;
    [SerializeField] GameObject graineDeux4;

    public bool isMuted = false;
    public bool clueOnSceen = false;
    public int _moveLimitDeux = 0;
    public int wincheck = 0;


    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<GameManager>().gameState = GameManager.State.InGameBagCloseLvlDeux;
        boxOptions.gameObject.SetActive(false);
        optionsBack.gameObject.SetActive(false);
        boxBagOpenLvlDeux.gameObject.SetActive(false);
        boxBagCloseLvlDeux.gameObject.SetActive(true);
        boxGrainesLvlDeux.gameObject.SetActive(false);
        bagClose.gameObject.SetActive(true);
        clue.gameObject.SetActive(false);
        gameOver.gameObject.SetActive(false);
        victory.gameObject.SetActive(false);
        retryB.gameObject.SetActive(false);
        restartB.gameObject.SetActive(false);
        next2B.gameObject.SetActive(false);
        boxStarEmpty.gameObject.SetActive(false);
        star1.gameObject.SetActive(false);
        star2.gameObject.SetActive(false);
        star3.gameObject.SetActive(false);
        perfect.gameObject.SetActive(false);

        //Debug.Log(gameState);
        bagClose.GetComponent<Button>().onClick.AddListener(OpenBag);
        muteB.GetComponent<Button>().onClick.AddListener(MuteSwitch);
        indiceIco.GetComponent<Button>().onClick.AddListener(ShowClue);
        optionsB.GetComponent<Button>().onClick.AddListener(OptionsShow);
        homeB.GetComponent<Button>().onClick.AddListener(MainMenu);
        restartB.GetComponent<Button>().onClick.AddListener(Restart);
        retryB.GetComponent<Button>().onClick.AddListener(NewTry);
        backB.GetComponent<Button>().onClick.AddListener(StepBack);
        next2B.GetComponent<Button>().onClick.AddListener(NextLevel3);
    }

    // Update is called once per frame
    void Update()
    {
        moveLimitLvlDeux.text = "Moves : " + _moveLimitDeux.ToString();

        if (FindObjectOfType<GameManager>().gameState == GameManager.State.InGameBagOpenLvlDeux && graineDeux1.gameObject.activeInHierarchy == false && graineDeux2.gameObject.activeInHierarchy == false
            && graineDeux3.gameObject.activeInHierarchy == false && graineDeux4.gameObject.activeInHierarchy == false)
        {
            WinCheck();
        }
    }

    public void NextLevel3()
    {
        SceneManager.LoadScene("Level3");
    }

    public void OpenBag()
    {

        if (FindObjectOfType<GameManager>().gameState == GameManager.State.InGameBagCloseLvlDeux)
        {
            FindObjectOfType<GameManager>().gameState = GameManager.State.InGameBagOpenLvlDeux;
            bagClose.gameObject.SetActive(false);
            boxBagOpenLvlDeux.gameObject.SetActive(true);
            boxGrainesLvlDeux.gameObject.SetActive(true);

        }
    }

    public void WinCheck()
    {
        if (wincheck == 7)
        {
            WinFunction();
        }
    }

    public void WinFunction()
    {
        if (FindObjectOfType<GameManager>().gameState == GameManager.State.InGameBagOpenLvlDeux)
        {
            FindObjectOfType<GameManager>().gameState = GameManager.State.Win;
            if (_moveLimitDeux > 14)
            {
                victory.gameObject.SetActive(true);
                optionsBack.gameObject.SetActive(true);
                retryB.gameObject.SetActive(true);
                next2B.gameObject.SetActive(true);
                restartB.gameObject.SetActive(true);
                boxStarEmpty.gameObject.SetActive(true);
                star1.gameObject.SetActive(true);
            }
            else if (_moveLimitDeux > 7 && _moveLimitDeux <= 14)
            {
                victory.gameObject.SetActive(true);
                optionsBack.gameObject.SetActive(true);
                retryB.gameObject.SetActive(true);
                next2B.gameObject.SetActive(true);
                restartB.gameObject.SetActive(true);
                boxStarEmpty.gameObject.SetActive(true);
                star1.gameObject.SetActive(true);
                star2.gameObject.SetActive(true);
            }
            else if (_moveLimitDeux <= 7)
            {
                victory.gameObject.SetActive(true);
                optionsBack.gameObject.SetActive(true);
                next2B.gameObject.SetActive(true);
                restartB.gameObject.SetActive(true);
                perfect.gameObject.SetActive(true);
                boxStarEmpty.gameObject.SetActive(true);
                star1.gameObject.SetActive(true);
                star2.gameObject.SetActive(true);
                star3.gameObject.SetActive(true);
            }
        }
    }

    public void MuteSwitch()
    {
        if (isMuted == false)
        {
            isMuted = true;
        }
        else
        {
            isMuted = false;
        }
    }

    public void ShowClue()
    {
        if (clueOnSceen == false)
        {
            clue.gameObject.SetActive(true);
            clueOnSceen = true;
        }
        else if (clueOnSceen == true)
        {
            clue.gameObject.SetActive(false);
            clueOnSceen = false;
        }
    }

    public void OptionsShow()
    {

        FindObjectOfType<GameManager>().gameState = GameManager.State.InOptions;
        boxOptions.gameObject.SetActive(true);
        retryB.gameObject.SetActive(true);
        optionsBack.gameObject.SetActive(true);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void StepBack()
    {
        retryB.gameObject.SetActive(false);
        boxOptions.gameObject.SetActive(false);
        optionsBack.gameObject.SetActive(false);
    }

    public void GameOver()
    {

        if (FindObjectOfType<GameManager>().gameState == GameManager.State.InGameBagOpenLvlDeux)
        {
            FindObjectOfType<GameManager>().gameState = GameManager.State.GameOver;
            _moveLimitDeux = 17;
            muteB.gameObject.SetActive(false);
            optionsB.gameObject.SetActive(false);
            optionsBack.gameObject.SetActive(true);
            gameOver.gameObject.SetActive(true);
            retryB.gameObject.SetActive(true);
            restartB.gameObject.SetActive(true);
        }
    }

    public void NewTry()
    {
        SceneManager.LoadScene("Level2");
    }
    public void Restart()
    {
        SceneManager.LoadScene("Menu");
    }
}
