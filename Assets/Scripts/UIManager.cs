using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject startB;
    [SerializeField] GameObject optionsB;
    [SerializeField] GameObject muteB;
    [SerializeField] GameObject indiceIco;
    [SerializeField] GameObject bagClose;
    [SerializeField] GameObject bagOpen;
    [SerializeField] GameObject backB;
    [SerializeField] GameObject optionsBack;
    [SerializeField] GameObject homeB;
    [SerializeField] GameObject clue;
    [SerializeField] GameObject restartB;
    [SerializeField] GameObject retryB;
    [SerializeField] GameObject next2B;
    [SerializeField] GameObject gameOver;
    [SerializeField] GameObject victory;
    [SerializeField] Text moveLimit;
    [SerializeField] Text moveLimitLvlDeux;
    [SerializeField] GameObject boxMenu;
    [SerializeField] GameObject boxBagOpen;
    [SerializeField] GameObject boxBagOpenLvlDeux;
    [SerializeField] GameObject boxBagClose;
    [SerializeField] GameObject boxBagCloseLvlDeux;
    [SerializeField] GameObject boxOptions;
    [SerializeField] GameObject boxGraines;
    [SerializeField] GameObject boxGrainesLvlDeux;


    [SerializeField] GameObject graineBleue;
    [SerializeField] GameObject graineOrange;
    [SerializeField] GameObject graineJaune;
    [SerializeField] GameObject graineCyan;
    [SerializeField] GameObject graineViolette;
    [SerializeField] GameObject graineRose;
    [SerializeField] GameObject graineDeux1;
    [SerializeField] GameObject graineDeux2;
    [SerializeField] GameObject graineDeux3;
    [SerializeField] GameObject graineDeux4;

    public bool isMuted = false;
    public bool clueOnSceen = false;
    static bool newtry = false;
    public int _moveLimit = 18;
    public int _moveLimitDeux = 17;

    
    // Start is called before the first frame update
    void Start()
    {
        boxOptions.gameObject.SetActive(false);
        boxBagOpen.gameObject.SetActive(false);
        
        boxBagOpenLvlDeux.gameObject.SetActive(false);
        boxBagClose.gameObject.SetActive(false);
       
        boxBagCloseLvlDeux.gameObject.SetActive(false);
        boxGraines.gameObject.SetActive(false);
        
        boxGrainesLvlDeux.gameObject.SetActive(false);
        bagClose.gameObject.SetActive(false);
        clue.gameObject.SetActive(false);
        gameOver.gameObject.SetActive(false);
        victory.gameObject.SetActive(false);
        retryB.gameObject.SetActive(false);
        restartB.gameObject.SetActive(false);
        
        next2B.gameObject.SetActive(false);

        //Debug.Log(gameState);
        startB.GetComponent<Button>().onClick.AddListener(StartGame);
        bagClose.GetComponent<Button>().onClick.AddListener(OpenBag);
        muteB.GetComponent<Button>().onClick.AddListener(MuteSwitch);
        indiceIco.GetComponent<Button>().onClick.AddListener(ShowClue);
        optionsB.GetComponent<Button>().onClick.AddListener(OptionsShow);
        homeB.GetComponent<Button>().onClick.AddListener(MainMenu);
        restartB.GetComponent<Button>().onClick.AddListener(Restart);
        retryB.GetComponent<Button>().onClick.AddListener(NewTry);
        backB.GetComponent<Button>().onClick.AddListener(StepBack);
        
        next2B.GetComponent<Button>().onClick.AddListener(NextLevel3);

        if(newtry == true)
        {
            StartGame();
            newtry = false;
        }

    }

    // Update is called once per frame
    void Update()
    {

        if(_moveLimit <= 0 || _moveLimitDeux <=0)
        {
            GameOver();
        }
        moveLimit.text = "actions lefts : " + _moveLimit.ToString();
        
        moveLimitLvlDeux.text = "actions lefts : " + _moveLimitDeux.ToString();

        if(gameState == State.InGameBagOpen && graineBleue.gameObject.activeInHierarchy == false && graineOrange.gameObject.activeInHierarchy == false && graineJaune.gameObject.activeInHierarchy == false
            && graineCyan.gameObject.activeInHierarchy == false && graineViolette.gameObject.activeInHierarchy == false && graineRose.gameObject.activeInHierarchy == false)
        {
            WinFunction();
        }
        
        if (gameState == State.InGameBagOpenLvlDeux && graineDeux1.gameObject.activeInHierarchy == false && graineDeux2.gameObject.activeInHierarchy == false 
            && graineDeux3.gameObject.activeInHierarchy == false && graineDeux4.gameObject.activeInHierarchy == false)
        {
            WinFunction();
        }
    }

    public void StartGame()
    {
        gameState = State.InGameBagCloseLvlUn;
        
        
        bagClose.gameObject.SetActive(true);
        boxMenu.gameObject.SetActive(false);
        gameOver.gameObject.SetActive(false);
        retryB.gameObject.SetActive(false);
        restartB.gameObject.SetActive(false);
        optionsBack.gameObject.SetActive(false);
        victory.gameObject.SetActive(false);
        
        next2B.gameObject.SetActive(false);
    }

    

    public void NextLevel3()
    {
        gameState = State.InGameBagClose;
    }

    public void OpenBag()
    {
        if(gameState == State.InGameBagClose)
        {
            gameState = State.InGameBagOpen;
            bagClose.gameObject.SetActive(false);
            boxBagOpen.gameObject.SetActive(true);
            boxGraines.gameObject.SetActive(true);
            
        }

      

        if (gameState == State.InGameBagCloseLvlDeux)
        {
            gameState = State.InGameBagOpenLvlDeux;
            bagClose.gameObject.SetActive(false);
            boxBagOpenLvlDeux.gameObject.SetActive(true);
            boxGrainesLvlDeux.gameObject.SetActive(true);

        }
    }

    public void WinFunction()
    {
        if(gameState == State.InGameBagOpen)
        {
            gameState = State.Win;
            victory.gameObject.SetActive(true);
            optionsBack.gameObject.SetActive(true);
            restartB.gameObject.SetActive(true);
        }
        
        if (gameState == State.InGameBagOpenLvlDeux)
        {
            gameState = State.Win;
            victory.gameObject.SetActive(true);
            optionsBack.gameObject.SetActive(true);
            next2B.gameObject.SetActive(true);
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
        gameState = State.Menu;
        boxMenu.gameObject.SetActive(true);
        optionsB.gameObject.SetActive(true);
        muteB.gameObject.SetActive(true);
        
        gameOver.gameObject.SetActive(false);
        victory.gameObject.SetActive(false);
        retryB.gameObject.SetActive(false);
        restartB.gameObject.SetActive(false);
        boxOptions.gameObject.SetActive(false);
        boxBagOpen.gameObject.SetActive(false);
        boxBagClose.gameObject.SetActive(false);
        boxGraines.gameObject.SetActive(false);
        bagClose.gameObject.SetActive(false);
        clue.gameObject.SetActive(false);
    }

    public void StepBack()
    {
        
        boxOptions.gameObject.SetActive(false);
    }

    public void GameOver()
    {
        if (gameState == State.InGameBagOpen)
        {
            gameState = State.GameOver;
            _moveLimit = 18;
            muteB.gameObject.SetActive(false);
            optionsB.gameObject.SetActive(false);
            optionsBack.gameObject.SetActive(true);
            gameOver.gameObject.SetActive(true);
            retryB.gameObject.SetActive(true);
            restartB.gameObject.SetActive(true);
        }
       
        else if (gameState == State.InGameBagOpenLvlDeux)
        {
            gameState = State.GameOver;
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
        newtry = true;
        SceneManager.LoadScene("Level3");
    }
    public void Restart()
    {
        SceneManager.LoadScene("Level3");
    }
}
