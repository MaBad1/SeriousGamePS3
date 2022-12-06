using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UITuto : MonoBehaviour
{
    [SerializeField] Text moveLimitT;
    [SerializeField] GameObject next1BT;
    [SerializeField] GameObject next2BT;
    [SerializeField] GameObject retryBT;
    [SerializeField] GameObject muteBT;
    [SerializeField] GameObject bagCloseT;
    [SerializeField] GameObject optionsBackT;
    [SerializeField] GameObject homeBT;
    [SerializeField] GameObject victoryT;
    [SerializeField] GameObject restartBT;
    [SerializeField] GameObject boxBagOpenT;
    [SerializeField] GameObject boxBagCloseT;
    [SerializeField] GameObject boxGrainesT;
    [SerializeField] GameObject boxStarEmptyT;
    [SerializeField] GameObject star1T;
    [SerializeField] GameObject star2T;
    [SerializeField] GameObject star3T;
    [SerializeField] GameObject perfectT;
    [SerializeField] GameObject indicateur;
    [SerializeField] GameObject indicateur2;
    [SerializeField] GameObject arrowGood;
    [SerializeField] GameObject arrowBad;
    [SerializeField] GameObject tutoText;
    [SerializeField] GameObject tutoText2;
    [SerializeField] GameObject tutoText3;
    [SerializeField] GameObject tutoTFond;
    [SerializeField] GameObject tutoTFond2;
    [SerializeField] Material Red;
    [SerializeField] Material Green;
    [SerializeField] Material Normal;

    [SerializeField] GameObject graineT1;
    [SerializeField] GameObject graineT2;
    [SerializeField] GameObject Red1;
    [SerializeField] GameObject Red2;
    [SerializeField] GameObject Green1;
    [SerializeField] ParticleSystem WinT;

    public bool isMuted = false;
    public int _moveLimitUn = 0;
    public int wincheck = 0;
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<GameManager>().gameState = GameManager.State.TutoBagClose;
        Debug.Log(FindObjectOfType<GameManager>().gameState);
        optionsBackT.gameObject.SetActive(false);
        boxBagOpenT.gameObject.SetActive(false);
        boxBagCloseT.gameObject.SetActive(true);
        boxGrainesT.gameObject.SetActive(false);
        bagCloseT.gameObject.SetActive(true);
        victoryT.gameObject.SetActive(false);
        retryBT.gameObject.SetActive(false);
        restartBT.gameObject.SetActive(false);
        next1BT.gameObject.SetActive(false);
        boxStarEmptyT.gameObject.SetActive(false);
        star1T.gameObject.SetActive(false);
        star2T.gameObject.SetActive(false);
        star3T.gameObject.SetActive(false);
        perfectT.gameObject.SetActive(false);
        tutoText.gameObject.SetActive(false);
        tutoTFond.gameObject.SetActive(false);
        arrowBad.gameObject.SetActive(false);
        arrowGood.gameObject.SetActive(false);
        next2BT.gameObject.SetActive(false);
        indicateur2.gameObject.SetActive(false);
        tutoText2.gameObject.SetActive(false);
        tutoText3.gameObject.SetActive(false);
        tutoTFond2.gameObject.SetActive(false);
        WinT.Stop();


        //Debug.Log(gameState);

        bagCloseT.GetComponent<Button>().onClick.AddListener(OpenBag);
        muteBT.GetComponent<Button>().onClick.AddListener(MuteSwitch);
        homeBT.GetComponent<Button>().onClick.AddListener(MainMenu);
        retryBT.GetComponent<Button>().onClick.AddListener(NewTry);
        restartBT.GetComponent<Button>().onClick.AddListener(Restart);
        next1BT.GetComponent<Button>().onClick.AddListener(NextLevel2);
        next2BT.GetComponent<Button>().onClick.AddListener(TutoSwitch);

    }

    // Update is called once per frame
    void Update()
    {
        
        //Debug.Log(FindObjectOfType<GameManager>().gameState);

        moveLimitT.text = "Moves : " + _moveLimitUn.ToString();

        if (FindObjectOfType<GameManager>().gameState == GameManager.State.TutoBagOpen && graineT1.gameObject.activeInHierarchy == false && graineT2.gameObject.activeInHierarchy == false)
        {
            WinCheck();
        }
    }

    public void NextLevel2()
    {
        SceneManager.LoadScene("Level1");
    }

    public void OpenBag()
    {


        if (FindObjectOfType<GameManager>().gameState == GameManager.State.TutoBagClose)
        {
            FindObjectOfType<GameManager>().gameState = GameManager.State.Tuto1;
            bagCloseT.gameObject.SetActive(false);
            indicateur.gameObject.SetActive(false);
            boxBagOpenT.gameObject.SetActive(true);
            boxGrainesT.gameObject.SetActive(true);
            tutoText.gameObject.SetActive(true);
            tutoTFond.gameObject.SetActive(true);
            next2BT.gameObject.SetActive(true);
        }
    }

    public void WinCheck()
    {
        if (wincheck == 3)
        {
            WinFunction();
        }
    }
    public void WinFunction()
    {

        if (FindObjectOfType<GameManager>().gameState == GameManager.State.TutoBagOpen)
        {
            WinT.Play();
            FindObjectOfType<GameManager>().gameState = GameManager.State.Win;
            if (_moveLimitUn > 6)
            {
                victoryT.gameObject.SetActive(true);
                optionsBackT.gameObject.SetActive(true);
                retryBT.gameObject.SetActive(true);
                next1BT.gameObject.SetActive(true);
                restartBT.gameObject.SetActive(true);
                boxStarEmptyT.gameObject.SetActive(true);
                star1T.gameObject.SetActive(true);
            }
            else if (_moveLimitUn > 3 && _moveLimitUn <= 6)
            {
                victoryT.gameObject.SetActive(true);
                optionsBackT.gameObject.SetActive(true);
                retryBT.gameObject.SetActive(true);
                next1BT.gameObject.SetActive(true);
                restartBT.gameObject.SetActive(true);
                boxStarEmptyT.gameObject.SetActive(true);
                star1T.gameObject.SetActive(true);
                star2T.gameObject.SetActive(true);
            }
            else if (_moveLimitUn <= 3)
            {
                victoryT.gameObject.SetActive(true);
                optionsBackT.gameObject.SetActive(true);
                perfectT.gameObject.SetActive(true);
                next1BT.gameObject.SetActive(true);
                restartBT.gameObject.SetActive(true);
                boxStarEmptyT.gameObject.SetActive(true);
                star1T.gameObject.SetActive(true);
                star2T.gameObject.SetActive(true);
                star3T.gameObject.SetActive(true);
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

    public void Tuto2()
    {
        FindObjectOfType<GameManager>().gameState = GameManager.State.Tuto2;
        arrowBad.gameObject.SetActive(true);
        Red1.GetComponent<MeshRenderer>().material = Red;
        Red2.GetComponent<MeshRenderer>().material = Red;
    }

    public void Tuto3()
    {
        FindObjectOfType<GameManager>().gameState = GameManager.State.Tuto3;
        arrowBad.gameObject.SetActive(false);
        arrowGood.gameObject.SetActive(true);
        Red1.GetComponent<MeshRenderer>().material = Normal;
        Red2.GetComponent<MeshRenderer>().material = Normal;
        Green1.GetComponent<MeshRenderer>().material = Green;
    }

    public void Tuto4()
    {
        FindObjectOfType<GameManager>().gameState = GameManager.State.Tuto4;
        arrowGood.gameObject.SetActive(false);
        Green1.GetComponent<MeshRenderer>().material = Normal;
        tutoText.gameObject.SetActive(false);
        tutoTFond.gameObject.SetActive(false);
        tutoText2.gameObject.SetActive(true);
        tutoTFond2.gameObject.SetActive(true);
        indicateur2.gameObject.SetActive(true);

    }

    public void Tuto5()
    {
        FindObjectOfType<GameManager>().gameState = GameManager.State.Tuto5;
        tutoText2.gameObject.SetActive(false);
        tutoText3.gameObject.SetActive(true);
        indicateur2.gameObject.SetActive(false);

    }

    public void Free()
    {
        FindObjectOfType<GameManager>().gameState = GameManager.State.TutoBagOpen;
        tutoText3.gameObject.SetActive(false);
        tutoTFond2.gameObject.SetActive(false);
        next2BT.gameObject.SetActive(false);
    }

    public void TutoSwitch()
    {
        if (FindObjectOfType<GameManager>().gameState == GameManager.State.Tuto1)
        {
            Tuto2();
        }
        else if (FindObjectOfType<GameManager>().gameState == GameManager.State.Tuto2)
        {
            Tuto3();
        }
        else if (FindObjectOfType<GameManager>().gameState == GameManager.State.Tuto3)
        {
            Tuto4();
        }
        else if (FindObjectOfType<GameManager>().gameState == GameManager.State.Tuto4)
        {
            Tuto5();
        }
        else if (FindObjectOfType<GameManager>().gameState == GameManager.State.Tuto5)
        {
            Free();
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void NewTry()
    {
        SceneManager.LoadScene("Tuto");
    }
    public void Restart()
    {
        SceneManager.LoadScene("Menu");
    }
}
