using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManagerLvl1 : MonoBehaviour
{
    [SerializeField] Text moveLimitLvlUn;
    [SerializeField] GameObject next1B;
    [SerializeField] GameObject retryB;
    [SerializeField] GameObject clue;
    [SerializeField] GameObject optionsB;
    [SerializeField] GameObject muteB;
    [SerializeField] GameObject indiceIco;
    [SerializeField] GameObject bagClose;
    [SerializeField] GameObject bagOpen;
    [SerializeField] GameObject backB;
    [SerializeField] GameObject optionsBack;
    [SerializeField] GameObject homeB;
    [SerializeField] GameObject gameOver;
    [SerializeField] GameObject victory;
    [SerializeField] GameObject restartB;
    [SerializeField] GameObject boxBagOpenLvlUn;
    [SerializeField] GameObject boxBagCloseLvlUn;
    [SerializeField] GameObject boxGrainesLvlUn;
    [SerializeField] GameObject boxOptions;

    [SerializeField] GameObject graineUn1;
    [SerializeField] GameObject graineUn2;
    [SerializeField] GameObject graineUn3;

    public bool isMuted = false;
    public bool clueOnSceen = false;
    public int _moveLimitUn = 15;
    // Start is called before the first frame update
    void Start()
    {
        boxOptions.gameObject.SetActive(false);
        
        boxBagOpenLvlUn.gameObject.SetActive(false);
        
        boxBagCloseLvlUn.gameObject.SetActive(false);
        
        boxGrainesLvlUn.gameObject.SetActive(false);
        
        bagClose.gameObject.SetActive(false);
        clue.gameObject.SetActive(false);
        gameOver.gameObject.SetActive(false);
        victory.gameObject.SetActive(false);
        retryB.gameObject.SetActive(false);
        
        next1B.gameObject.SetActive(false);
        

        //Debug.Log(gameState);
        
        bagClose.GetComponent<Button>().onClick.AddListener(OpenBag);
        muteB.GetComponent<Button>().onClick.AddListener(MuteSwitch);
        indiceIco.GetComponent<Button>().onClick.AddListener(ShowClue);
        optionsB.GetComponent<Button>().onClick.AddListener(OptionsShow);
        homeB.GetComponent<Button>().onClick.AddListener(MainMenu);
        retryB.GetComponent<Button>().onClick.AddListener(NewTry);
        backB.GetComponent<Button>().onClick.AddListener(StepBack);
        restartB.GetComponent<Button>().onClick.AddListener(Restart);
        next1B.GetComponent<Button>().onClick.AddListener(NextLevel2);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_moveLimitUn <= 0)
        {
            GameOver();
        }

        moveLimitLvlUn.text = "actions lefts : " + _moveLimitUn.ToString();

        if (gameState == State.InGameBagOpenLvlUn && graineUn1.gameObject.activeInHierarchy == false && graineUn2.gameObject.activeInHierarchy == false && graineUn3.gameObject.activeInHierarchy == false)
        {
            WinFunction();
        }
    }

    public void NextLevel2()
    {
        gameState = State.InGameBagCloseLvlDeux;
    }

    public void OpenBag()
    {
        

        if (gameState == State.InGameBagCloseLvlUn)
        {
            gameState = State.InGameBagOpenLvlUn;
            bagClose.gameObject.SetActive(false);
            boxBagOpenLvlUn.gameObject.SetActive(true);
            boxGrainesLvlUn.gameObject.SetActive(true);

        }
    }

    public void WinFunction()
    {
        
        if (gameState == State.InGameBagOpenLvlUn)
        {
            gameState = State.Win;
            victory.gameObject.SetActive(true);
            optionsBack.gameObject.SetActive(true);
            next1B.gameObject.SetActive(true);
            restartB.gameObject.SetActive(true);
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

        gameState = State.InOptions;
        boxOptions.gameObject.SetActive(true);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void StepBack()
    {

        boxOptions.gameObject.SetActive(false);
    }

    public void GameOver()
    {
       if (gameState == State.InGameBagOpenLvlUn)
        {
            gameState = State.GameOver;
            _moveLimitUn = 15;
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
        SceneManager.LoadScene("Level1");
    }
    public void Restart()
    {
        SceneManager.LoadScene("Menu");
    }
}
