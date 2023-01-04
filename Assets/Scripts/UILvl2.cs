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
    [SerializeField] GameObject muteB;
    [SerializeField] GameObject bagClose;
    [SerializeField] GameObject optionsBack;
    [SerializeField] GameObject homeB;
    [SerializeField] GameObject restartB;
    [SerializeField] GameObject retryB;
    [SerializeField] GameObject victory;
    [SerializeField] GameObject boxStarEmpty;
    [SerializeField] GameObject star1;
    [SerializeField] GameObject star2;
    [SerializeField] GameObject star3;
    [SerializeField] GameObject perfect;
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
        victory.gameObject.SetActive(false);
        retryB.gameObject.SetActive(false);
        restartB.gameObject.SetActive(false);
        next2B.gameObject.SetActive(false);
        boxStarEmpty.gameObject.SetActive(false);
        star1.gameObject.SetActive(false);
        star2.gameObject.SetActive(false);
        star3.gameObject.SetActive(false);
        perfect.gameObject.SetActive(false);
        indicateur.gameObject.SetActive(true);
        Win.Stop();

        //Debug.Log(gameState);
        bagClose.GetComponent<Button>().onClick.AddListener(OpenBag);
        muteB.GetComponent<Button>().onClick.AddListener(MuteSwitch);
        homeB.GetComponent<Button>().onClick.AddListener(MainMenu);
        restartB.GetComponent<Button>().onClick.AddListener(Restart);
        retryB.GetComponent<Button>().onClick.AddListener(NewTry);
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
            indicateur.gameObject.SetActive(false);

        }
    }

    public void WinCheck()
    {
        if (wincheck == 11)
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
            if (_moveLimitDeux > 22)
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
            else if (_moveLimitDeux > 11 && _moveLimitDeux <= 22)
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
            else if (_moveLimitDeux <= 11)
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
