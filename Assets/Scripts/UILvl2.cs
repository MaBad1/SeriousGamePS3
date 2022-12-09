using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UILvl2 : MonoBehaviour
{
    [SerializeField] Text moveLimitLvlDeux;
    [SerializeField] GameObject next2B;
    [SerializeField] GameObject next2BTuto;
    [SerializeField] GameObject boxBagOpenLvlDeux;
    [SerializeField] GameObject boxBagCloseLvlDeux;
    [SerializeField] GameObject boxGrainesLvlDeux;
    [SerializeField] GameObject muteB;
    [SerializeField] GameObject indiceIco;
    [SerializeField] GameObject bagClose;
    [SerializeField] GameObject optionsBack;
    [SerializeField] GameObject homeB;
    [SerializeField] GameObject clue;
    [SerializeField] GameObject clueTuto;
    [SerializeField] GameObject restartB;
    [SerializeField] GameObject retryB;
    [SerializeField] GameObject victory;
    [SerializeField] GameObject boxStarEmpty;
    [SerializeField] GameObject star1;
    [SerializeField] GameObject star2;
    [SerializeField] GameObject star3;
    [SerializeField] GameObject perfect;
    [SerializeField] GameObject TutoText1;
    [SerializeField] GameObject TutoText2;
    [SerializeField] GameObject TutoTextFond;
    [SerializeField] GameObject indicateur;

    [SerializeField] GameObject graineDeux1;
    [SerializeField] GameObject graineDeux2;
    [SerializeField] GameObject graineDeux3;
    [SerializeField] GameObject graineDeux4;
    [SerializeField] ParticleSystem Win;

    public bool clueOnSceen = false;
    public int _moveLimitDeux = 0;
    public int wincheck = 0;


    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<GameManager>().gameState = GameManager.State.InGameBagCloseLvlDeux;
        optionsBack.gameObject.SetActive(false);
        boxBagOpenLvlDeux.gameObject.SetActive(false);
        boxBagCloseLvlDeux.gameObject.SetActive(true);
        boxGrainesLvlDeux.gameObject.SetActive(false);
        bagClose.gameObject.SetActive(true);
        clue.gameObject.SetActive(false);
        victory.gameObject.SetActive(false);
        retryB.gameObject.SetActive(false);
        restartB.gameObject.SetActive(false);
        next2B.gameObject.SetActive(false);
        boxStarEmpty.gameObject.SetActive(false);
        star1.gameObject.SetActive(false);
        star2.gameObject.SetActive(false);
        star3.gameObject.SetActive(false);
        perfect.gameObject.SetActive(false);
        next2BTuto.gameObject.SetActive(false);
        TutoText1.gameObject.SetActive(false);
        TutoText2.gameObject.SetActive(false);
        TutoTextFond.gameObject.SetActive(false);
        clueTuto.gameObject.SetActive(false);
        indicateur.gameObject.SetActive(false);
        Win.Stop();

        //Debug.Log(gameState);
        bagClose.GetComponent<Button>().onClick.AddListener(OpenBag);
        muteB.GetComponent<Button>().onClick.AddListener(MuteSwitch);
        indiceIco.GetComponent<Button>().onClick.AddListener(ShowClue);
        homeB.GetComponent<Button>().onClick.AddListener(MainMenu);
        restartB.GetComponent<Button>().onClick.AddListener(Restart);
        retryB.GetComponent<Button>().onClick.AddListener(NewTry);
        next2B.GetComponent<Button>().onClick.AddListener(NextLevel3);
        next2BTuto.GetComponent<Button>().onClick.AddListener(NextTuto);
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
            FindObjectOfType<GameManager>().gameState = GameManager.State.Tuto1;
            bagClose.gameObject.SetActive(false);
            boxBagOpenLvlDeux.gameObject.SetActive(true);
            boxGrainesLvlDeux.gameObject.SetActive(true);
            indicateur.gameObject.SetActive(true);

        }
    }

    public void WinCheck()
    {
        if (wincheck == 8)
        {
            WinFunction();
        }
    }

    public void WinFunction()
    {
        if (FindObjectOfType<GameManager>().gameState == GameManager.State.InGameBagOpenLvlDeux)
        {
            Win.Play();
            FindObjectOfType<GameManager>().gameState = GameManager.State.Win;
            if (_moveLimitDeux > 16)
            {
                victory.gameObject.SetActive(true);
                optionsBack.gameObject.SetActive(true);
                retryB.gameObject.SetActive(true);
                next2B.gameObject.SetActive(true);
                restartB.gameObject.SetActive(true);
                boxStarEmpty.gameObject.SetActive(true);
                star1.gameObject.SetActive(true);

                if (FindObjectOfType<Audio>().isMuted == false)
                {
                    FindObjectOfType<Audio>()._star1.Play();
                }
            }
            else if (_moveLimitDeux > 8 && _moveLimitDeux <= 16)
            {
                victory.gameObject.SetActive(true);
                optionsBack.gameObject.SetActive(true);
                retryB.gameObject.SetActive(true);
                next2B.gameObject.SetActive(true);
                restartB.gameObject.SetActive(true);
                boxStarEmpty.gameObject.SetActive(true);
                star1.gameObject.SetActive(true);
                star2.gameObject.SetActive(true);

                if (FindObjectOfType<Audio>().isMuted == false)
                {
                    FindObjectOfType<Audio>()._star2.Play();
                }

            }
            else if (_moveLimitDeux <= 8)
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

                if (FindObjectOfType<Audio>().isMuted == false)
                {
                    FindObjectOfType<Audio>()._star3.Play();
                }
            }
        }
    }

    public void MuteSwitch()
    {
        if (FindObjectOfType<Audio>().isMuted == false)
        {
            FindObjectOfType<Audio>().isMuted = true;
            FindObjectOfType<Audio>()._birds.Pause();
        }
        else
        {
            FindObjectOfType<Audio>().isMuted = false;
            FindObjectOfType<Audio>()._birds.Play();
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
        if(FindObjectOfType<GameManager>().gameState == GameManager.State.Tuto1)
        {
            Tuto2();
        }
        else if (FindObjectOfType<GameManager>().gameState == GameManager.State.Tuto4)
        {
            Free();
        }
    }

    public void NextTuto()
    {
        if (FindObjectOfType<GameManager>().gameState == GameManager.State.Tuto2)
        {
            Tuto3();
        }
        else if (FindObjectOfType<GameManager>().gameState == GameManager.State.Tuto3)
        {
            Tuto4();
        }
        
    }

    public void Tuto2()
    {
        FindObjectOfType<GameManager>().gameState = GameManager.State.Tuto2;
        TutoText1.gameObject.SetActive(true);
        TutoTextFond.gameObject.SetActive(true);
        next2BTuto.gameObject.SetActive(true);
        indicateur.gameObject.SetActive(false);
    }

    public void Tuto3()
    {
        FindObjectOfType<GameManager>().gameState = GameManager.State.Tuto3;
        TutoText1.gameObject.SetActive(false);
        TutoText2.gameObject.SetActive(true);
        clueTuto.gameObject.SetActive(true);
    }

    public void Tuto4()
    {
        FindObjectOfType<GameManager>().gameState = GameManager.State.Tuto4;
        clueTuto.gameObject.SetActive(false);
        TutoText2.gameObject.SetActive(false);
        TutoTextFond.gameObject.SetActive(false);
        next2BTuto.gameObject.SetActive(false);
        indicateur.gameObject.SetActive(true);
    }

    public void Free()
    {
        FindObjectOfType<GameManager>().gameState = GameManager.State.InGameBagOpenLvlDeux;
        indicateur.gameObject.SetActive(false);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
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
