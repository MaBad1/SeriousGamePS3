using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UILvl3 : MonoBehaviour
{

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
    [SerializeField] Text moveLimit;
    [SerializeField] GameObject boxBagOpen;
    [SerializeField] GameObject boxBagClose;
    [SerializeField] GameObject boxGraines;
    [SerializeField] GameObject boxOptions;

    [SerializeField] GameObject graineBleue;
    [SerializeField] GameObject graineOrange;
    [SerializeField] GameObject graineJaune;
    [SerializeField] GameObject graineCyan;
    [SerializeField] GameObject graineViolette;
    [SerializeField] GameObject graineRose;

    public bool isMuted = false;
    public bool clueOnSceen = false;
    public int _moveLimit = 0;
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<GameManager>().gameState = GameManager.State.InGameBagClose;
        boxOptions.gameObject.SetActive(false);
        boxBagOpen.gameObject.SetActive(false);
        boxBagClose.gameObject.SetActive(true);
        boxGraines.gameObject.SetActive(false);
        bagClose.gameObject.SetActive(true);
        clue.gameObject.SetActive(false);
        gameOver.gameObject.SetActive(false);
        victory.gameObject.SetActive(false);
        retryB.gameObject.SetActive(false);
        restartB.gameObject.SetActive(false);

        //Debug.Log(gameState);
        bagClose.GetComponent<Button>().onClick.AddListener(OpenBag);
        muteB.GetComponent<Button>().onClick.AddListener(MuteSwitch);
        indiceIco.GetComponent<Button>().onClick.AddListener(ShowClue);
        optionsB.GetComponent<Button>().onClick.AddListener(OptionsShow);
        homeB.GetComponent<Button>().onClick.AddListener(MainMenu);
        restartB.GetComponent<Button>().onClick.AddListener(Restart);
        retryB.GetComponent<Button>().onClick.AddListener(NewTry);
        backB.GetComponent<Button>().onClick.AddListener(StepBack);
    }

    // Update is called once per frame
    void Update()
    {
        if (_moveLimit <= 25 && FindObjectOfType<GameManager>().gameState == GameManager.State.InGameBagOpen && graineBleue.gameObject.activeInHierarchy == false && graineOrange.gameObject.activeInHierarchy == false && graineJaune.gameObject.activeInHierarchy == false
            && graineCyan.gameObject.activeInHierarchy == false && graineViolette.gameObject.activeInHierarchy == false && graineRose.gameObject.activeInHierarchy == false)
        {
            GameOver();
        }
        moveLimit.text = "score : " + _moveLimit.ToString();



        if (_moveLimit >= 26 && FindObjectOfType<GameManager>().gameState == GameManager.State.InGameBagOpen && graineBleue.gameObject.activeInHierarchy == false && graineOrange.gameObject.activeInHierarchy == false && graineJaune.gameObject.activeInHierarchy == false
            && graineCyan.gameObject.activeInHierarchy == false && graineViolette.gameObject.activeInHierarchy == false && graineRose.gameObject.activeInHierarchy == false)
        {
            WinFunction();
        }
    }

    public void OpenBag()
    {
        if (FindObjectOfType<GameManager>().gameState == GameManager.State.InGameBagClose)
        {
            FindObjectOfType<GameManager>().gameState = GameManager.State.InGameBagOpen;
            bagClose.gameObject.SetActive(false);
            boxBagOpen.gameObject.SetActive(true);
            boxGraines.gameObject.SetActive(true);

        }
    }

    public void WinFunction()
    {
        if (FindObjectOfType<GameManager>().gameState == GameManager.State.InGameBagOpen)
        {
            FindObjectOfType<GameManager>().gameState = GameManager.State.Win;
            if(_moveLimit >= 26 && _moveLimit < 36)
            {
                victory.gameObject.SetActive(true);
                optionsBack.gameObject.SetActive(true);
                retryB.gameObject.SetActive(true);
                restartB.gameObject.SetActive(true);
            }
            if (_moveLimit == 36)
            {
                victory.gameObject.SetActive(true);
                optionsBack.gameObject.SetActive(true);
                restartB.gameObject.SetActive(true);
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
        if (FindObjectOfType<GameManager>().gameState == GameManager.State.InGameBagOpen)
        {
            FindObjectOfType<GameManager>().gameState = GameManager.State.GameOver;
            _moveLimit = 18;
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
        SceneManager.LoadScene("Level3");
    }
    public void Restart()
    {
        SceneManager.LoadScene("Menu");
    }
}
