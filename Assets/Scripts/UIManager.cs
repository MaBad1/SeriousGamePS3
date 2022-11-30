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
    [SerializeField] GameObject gameOver;
    [SerializeField] GameObject victory;
    [SerializeField] Text moveLimit;
    [SerializeField] GameObject boxMenu;
    [SerializeField] GameObject boxBagOpen;
    [SerializeField] GameObject boxBagClose;
    [SerializeField] GameObject boxOptions;
    [SerializeField] GameObject boxGraines;
    

    [SerializeField] GameObject graineBleue;
    [SerializeField] GameObject graineOrange;
    [SerializeField] GameObject graineJaune;
    [SerializeField] GameObject graineCyan;
    [SerializeField] GameObject graineViolette;
    [SerializeField] GameObject graineRose;

    public bool isMuted = false;
    public bool clueOnSceen = false;
    public int _moveLimit = 18;
    private State buffer;

    public enum State
    {
        Menu,
        InOptions,
        InGameBagClose,
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
        boxBagClose.gameObject.SetActive(false);
        boxGraines.gameObject.SetActive(false);
        bagClose.gameObject.SetActive(false);
        clue.gameObject.SetActive(false);
        gameOver.gameObject.SetActive(false);
        victory.gameObject.SetActive(false);
        retryB.gameObject.SetActive(false);
        restartB.gameObject.SetActive(false);

        //Debug.Log(gameState);
        startB.GetComponent<Button>().onClick.AddListener(StartGame);
        bagClose.GetComponent<Button>().onClick.AddListener(OpenBag);
        muteB.GetComponent<Button>().onClick.AddListener(MuteSwitch);
        indiceIco.GetComponent<Button>().onClick.AddListener(ShowClue);
        optionsB.GetComponent<Button>().onClick.AddListener(OptionsShow);
        homeB.GetComponent<Button>().onClick.AddListener(MainMenu);
        restartB.GetComponent<Button>().onClick.AddListener(Restart);
        retryB.GetComponent<Button>().onClick.AddListener(StartGame);
        backB.GetComponent<Button>().onClick.AddListener(StepBack);

    }

    // Update is called once per frame
    void Update()
    {

        if(_moveLimit <= 0)
        {
            gameState = State.GameOver;
            GameOver();
        }
        moveLimit.text = "actions lefts : " + _moveLimit.ToString();

        if(gameState == State.InGameBagOpen && graineBleue.gameObject.activeInHierarchy == false && graineOrange.gameObject.activeInHierarchy == false && graineJaune.gameObject.activeInHierarchy == false
            && graineCyan.gameObject.activeInHierarchy == false && graineViolette.gameObject.activeInHierarchy == false && graineRose.gameObject.activeInHierarchy == false)
        {
            WinFunction();
        } 
    }

    public void StartGame()
    {
        gameState = State.InGameBagClose;

        boxBagClose.gameObject.SetActive(true);
        bagClose.gameObject.SetActive(true);
        boxMenu.gameObject.SetActive(false);
        gameOver.gameObject.SetActive(false);
        retryB.gameObject.SetActive(false);
        restartB.gameObject.SetActive(false);
        optionsBack.gameObject.SetActive(false);
        victory.gameObject.SetActive(false);
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
        if (gameState == State.GameOver)
        {
            _moveLimit = 18;
            muteB.gameObject.SetActive(false);
            optionsB.gameObject.SetActive(false);
            optionsBack.gameObject.SetActive(true);
            gameOver.gameObject.SetActive(true);
            retryB.gameObject.SetActive(true);
            restartB.gameObject.SetActive(true);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("Level3");
    }
}
