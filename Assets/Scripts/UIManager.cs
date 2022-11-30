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
    [SerializeField] GameObject next1B;
    [SerializeField] GameObject next2B;
    [SerializeField] GameObject gameOver;
    [SerializeField] GameObject victory;
    [SerializeField] Text moveLimit;
    [SerializeField] Text moveLimitLvlUn;
    [SerializeField] Text moveLimitLvlDeux;
    [SerializeField] GameObject boxMenu;
    [SerializeField] GameObject boxBagOpen;
    [SerializeField] GameObject boxBagOpenLvlUn;
    [SerializeField] GameObject boxBagOpenLvlDeux;
    [SerializeField] GameObject boxBagClose;
    [SerializeField] GameObject boxBagCloseLvlUn;
    [SerializeField] GameObject boxBagCloseLvlDeux;
    [SerializeField] GameObject boxOptions;
    [SerializeField] GameObject boxGraines;
    [SerializeField] GameObject boxGrainesLvlUn;
    [SerializeField] GameObject boxGrainesLvlDeux;
    

    [SerializeField] GameObject graineBleue;
    [SerializeField] GameObject graineOrange;
    [SerializeField] GameObject graineJaune;
    [SerializeField] GameObject graineCyan;
    [SerializeField] GameObject graineViolette;
    [SerializeField] GameObject graineRose;
    [SerializeField] GameObject graineUn1;
    [SerializeField] GameObject graineUn2;
    [SerializeField] GameObject graineUn3;
    [SerializeField] GameObject graineDeux1;
    [SerializeField] GameObject graineDeux2;
    [SerializeField] GameObject graineDeux3;
    [SerializeField] GameObject graineDeux4;

    public bool isMuted = false;
    public bool clueOnSceen = false;
    static bool newtry = false;
    public int _moveLimit = 18;
    public int _moveLimitUn = 15;
    public int _moveLimitDeux = 17;
    private State buffer;

    public enum State
    {
        Menu,
        InOptions,
        InGameBagCloseLvlUn,
        InGameBagCloseLvlDeux,
        InGameBagClose,
        InGameBagOpenLvlUn,
        InGameBagOpenLvlDeux,
        InGameBagOpen,
        GameOver,
        Win
    }

    public State gameState = State.Menu;
    // Start is called before the first frame update
    void Start()
    {
        boxOptions.gameObject.SetActive(false);
        boxBagOpen.gameObject.SetActive(false);
        boxBagOpenLvlUn.gameObject.SetActive(false);
        boxBagOpenLvlDeux.gameObject.SetActive(false);
        boxBagClose.gameObject.SetActive(false);
        boxBagCloseLvlUn.gameObject.SetActive(false);
        boxBagCloseLvlDeux.gameObject.SetActive(false);
        boxGraines.gameObject.SetActive(false);
        boxGrainesLvlUn.gameObject.SetActive(false);
        boxGrainesLvlDeux.gameObject.SetActive(false);
        bagClose.gameObject.SetActive(false);
        clue.gameObject.SetActive(false);
        gameOver.gameObject.SetActive(false);
        victory.gameObject.SetActive(false);
        retryB.gameObject.SetActive(false);
        restartB.gameObject.SetActive(false);
        next1B.gameObject.SetActive(false);
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
        next1B.GetComponent<Button>().onClick.AddListener(NextLevel2);
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

        if(_moveLimit <= 0 || _moveLimitUn <=0 || _moveLimitDeux <=0)
        {
            GameOver();
        }
        moveLimit.text = "actions lefts : " + _moveLimit.ToString();
        moveLimitLvlUn.text = "actions lefts : " + _moveLimitUn.ToString();
        moveLimitLvlDeux.text = "actions lefts : " + _moveLimitDeux.ToString();

        if(gameState == State.InGameBagOpen && graineBleue.gameObject.activeInHierarchy == false && graineOrange.gameObject.activeInHierarchy == false && graineJaune.gameObject.activeInHierarchy == false
            && graineCyan.gameObject.activeInHierarchy == false && graineViolette.gameObject.activeInHierarchy == false && graineRose.gameObject.activeInHierarchy == false)
        {
            WinFunction();
        }
        if (gameState == State.InGameBagOpenLvlUn && graineUn1.gameObject.activeInHierarchy == false && graineUn2.gameObject.activeInHierarchy == false && graineUn3.gameObject.activeInHierarchy == false)
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
        Camera.main.transform.position = new Vector3(-98.2f, 42.5f, 103.1f);
        Camera.main.transform.Rotate(59.684f, 90, 0, Space.World);

        boxBagCloseLvlUn.gameObject.SetActive(true);
        bagClose.gameObject.SetActive(true);
        boxMenu.gameObject.SetActive(false);
        gameOver.gameObject.SetActive(false);
        retryB.gameObject.SetActive(false);
        restartB.gameObject.SetActive(false);
        optionsBack.gameObject.SetActive(false);
        victory.gameObject.SetActive(false);
        next1B.gameObject.SetActive(false);
        next2B.gameObject.SetActive(false);
    }

    public void NextLevel2()
    {
        gameState = State.InGameBagCloseLvlDeux;

        Camera.main.transform.position = new Vector3(56.8f, 49.8f, -36.7f);
        Camera.main.transform.Rotate(59.684f, 0, 0, Space.World);

        boxBagCloseLvlDeux.gameObject.SetActive(true);
        bagClose.gameObject.SetActive(true);
        boxMenu.gameObject.SetActive(false);
        gameOver.gameObject.SetActive(false);
        retryB.gameObject.SetActive(false);
        restartB.gameObject.SetActive(false);
        optionsBack.gameObject.SetActive(false);
        victory.gameObject.SetActive(false);
        next1B.gameObject.SetActive(false);
        next2B.gameObject.SetActive(false);
    }

    public void NextLevel3()
    {
        gameState = State.InGameBagClose;

        Camera.main.transform.position = new Vector3(0.2f, 44.2f, -32.08f);
        Camera.main.transform.Rotate(59.684f, 0, 0, Space.World);

        boxBagClose.gameObject.SetActive(true);
        bagClose.gameObject.SetActive(true);
        boxMenu.gameObject.SetActive(false);
        gameOver.gameObject.SetActive(false);
        retryB.gameObject.SetActive(false);
        restartB.gameObject.SetActive(false);
        optionsBack.gameObject.SetActive(false);
        victory.gameObject.SetActive(false);
        next1B.gameObject.SetActive(false);
        next2B.gameObject.SetActive(false);
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

        else if (gameState == State.InGameBagCloseLvlUn)
        {
            gameState = State.InGameBagOpenLvlUn;
            bagClose.gameObject.SetActive(false);
            boxBagOpenLvlUn.gameObject.SetActive(true);
            boxGrainesLvlUn.gameObject.SetActive(true);

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
        if (gameState == State.InGameBagOpenLvlUn)
        {
            gameState = State.Win;
            victory.gameObject.SetActive(true);
            optionsBack.gameObject.SetActive(true);
            next1B.gameObject.SetActive(true);
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
        buffer = gameState;
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
        gameState = buffer;
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
        else if (gameState == State.InGameBagOpenLvlUn)
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
