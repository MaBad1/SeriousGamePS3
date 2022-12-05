using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UILvl1 : MonoBehaviour
{
    [SerializeField] Text moveLimitLvlUn;
    [SerializeField] GameObject next1B;
    [SerializeField] GameObject retryB;
    [SerializeField] GameObject clue;
    [SerializeField] GameObject optionsB;
    [SerializeField] GameObject muteB;
    [SerializeField] GameObject indiceIco;
    [SerializeField] GameObject bagClose;
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
    [SerializeField] GameObject boxStarEmpty;
    [SerializeField] GameObject star1;
    [SerializeField] GameObject star2;
    [SerializeField] GameObject star3;
    [SerializeField] GameObject perfect;

    [SerializeField] GameObject graineUn1;
    [SerializeField] GameObject graineUn2;
    [SerializeField] GameObject graineUn3;
    [SerializeField] ParticleSystem Win;


    public bool isMuted = false;
    public bool clueOnSceen = false;
    public int _moveLimitUn = 0;
    public int wincheck = 0;
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<GameManager>().gameState = GameManager.State.InGameBagCloseLvlUn;
        Debug.Log(FindObjectOfType<GameManager>().gameState);
        boxOptions.gameObject.SetActive(false);
        optionsBack.gameObject.SetActive(false);
        boxBagOpenLvlUn.gameObject.SetActive(false);
        boxBagCloseLvlUn.gameObject.SetActive(true);
        boxGrainesLvlUn.gameObject.SetActive(false);
        bagClose.gameObject.SetActive(true);
        clue.gameObject.SetActive(false);
        gameOver.gameObject.SetActive(false);
        victory.gameObject.SetActive(false);
        retryB.gameObject.SetActive(false);
        restartB.gameObject.SetActive(false);
        next1B.gameObject.SetActive(false);
        boxStarEmpty.gameObject.SetActive(false);
        star1.gameObject.SetActive(false);
        star2.gameObject.SetActive(false);
        star3.gameObject.SetActive(false);
        perfect.gameObject.SetActive(false);
        Win.Stop();
        

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
        moveLimitLvlUn.text = "Moves : " + _moveLimitUn.ToString();

        if (FindObjectOfType<GameManager>().gameState == GameManager.State.InGameBagOpenLvlUn && graineUn1.gameObject.activeInHierarchy == false && graineUn2.gameObject.activeInHierarchy == false && graineUn3.gameObject.activeInHierarchy == false)
        {
            WinCheck();
        }
    }

    public void NextLevel2()
    {
        SceneManager.LoadScene("Level2");
    }

    public void OpenBag()
    {
        

        if (FindObjectOfType<GameManager>().gameState == GameManager.State.InGameBagCloseLvlUn)
        {
            FindObjectOfType<GameManager>().gameState = GameManager.State.InGameBagOpenLvlUn;
            bagClose.gameObject.SetActive(false);
            boxBagOpenLvlUn.gameObject.SetActive(true);
            boxGrainesLvlUn.gameObject.SetActive(true);

        }
    }

    public void WinCheck()
    {
        if(wincheck == 4)
        {
            WinFunction();
        }
    }
    public void WinFunction()
    {
        
        if (FindObjectOfType<GameManager>().gameState == GameManager.State.InGameBagOpenLvlUn)
        {
            Win.Play();
            FindObjectOfType<GameManager>().gameState = GameManager.State.Win;
            if(_moveLimitUn >8)
            {
                victory.gameObject.SetActive(true);
                optionsBack.gameObject.SetActive(true);
                retryB.gameObject.SetActive(true);
                next1B.gameObject.SetActive(true);
                restartB.gameObject.SetActive(true);
                boxStarEmpty.gameObject.SetActive(true);
                star1.gameObject.SetActive(true);
            }
            else if (_moveLimitUn > 4 && _moveLimitUn <=8)
            {
                victory.gameObject.SetActive(true);
                optionsBack.gameObject.SetActive(true);
                retryB.gameObject.SetActive(true);
                next1B.gameObject.SetActive(true);
                restartB.gameObject.SetActive(true);
                boxStarEmpty.gameObject.SetActive(true);
                star1.gameObject.SetActive(true); 
                star2.gameObject.SetActive(true);
            }
            else if (_moveLimitUn <= 4)
            {
                victory.gameObject.SetActive(true);
                optionsBack.gameObject.SetActive(true);
                perfect.gameObject.SetActive(true);
                next1B.gameObject.SetActive(true);
                restartB.gameObject.SetActive(true);
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
       if (FindObjectOfType<GameManager>().gameState == GameManager.State.InGameBagOpenLvlUn)
        {
            FindObjectOfType<GameManager>().gameState = GameManager.State.GameOver;
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
