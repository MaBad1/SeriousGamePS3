using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UILvl3 : MonoBehaviour
{

    [SerializeField] GameObject muteB;
    [SerializeField] GameObject bagClose;
    [SerializeField] GameObject optionsBack;
    [SerializeField] GameObject homeB;
    [SerializeField] GameObject restartB;
    [SerializeField] GameObject retryB;
    [SerializeField] GameObject victory;
    [SerializeField] Text moveLimit;
    [SerializeField] GameObject boxBagOpen;
    [SerializeField] GameObject boxBagClose;
    [SerializeField] GameObject boxGraines;
    [SerializeField] GameObject boxStarEmpty;
    [SerializeField] GameObject star1;
    [SerializeField] GameObject star2;
    [SerializeField] GameObject star3;
    [SerializeField] GameObject perfect;
    [SerializeField] GameObject indicateur;

    [SerializeField] GameObject graineBleue;
    [SerializeField] GameObject graineOrange;
    [SerializeField] GameObject graineJaune;
    [SerializeField] GameObject graineCyan;
    [SerializeField] GameObject graineViolette;
    [SerializeField] GameObject graineRose;
    [SerializeField] ParticleSystem Win;

    public bool clueOnSceen = false;
    public int _moveLimit = 0;
    public int wincheck = 0;

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<GameManager>().gameState = GameManager.State.InGameBagClose;
        optionsBack.gameObject.SetActive(false);
        boxBagOpen.gameObject.SetActive(false);
        boxBagClose.gameObject.SetActive(true);
        boxGraines.gameObject.SetActive(false);
        bagClose.gameObject.SetActive(true);
        victory.gameObject.SetActive(false);
        retryB.gameObject.SetActive(false);
        restartB.gameObject.SetActive(false);
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
    }

    // Update is called once per frame
    void Update()
    {

        moveLimit.text = "Moves : " + _moveLimit.ToString();

        if (FindObjectOfType<GameManager>().gameState == GameManager.State.InGameBagOpen && graineBleue.gameObject.activeInHierarchy == false && graineOrange.gameObject.activeInHierarchy == false && graineJaune.gameObject.activeInHierarchy == false
            && graineCyan.gameObject.activeInHierarchy == false && graineViolette.gameObject.activeInHierarchy == false && graineRose.gameObject.activeInHierarchy == false)
        {
            WinCheck();
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
            indicateur.gameObject.SetActive(false);


        }
    }

    public void WinCheck()
    {
        if (wincheck == 12)
        {
            WinFunction();
        }
    }

    public void WinFunction()
    {
        if (FindObjectOfType<GameManager>().gameState == GameManager.State.InGameBagOpen)
        {
            Win.Play();
            FindObjectOfType<GameManager>().gameState = GameManager.State.Win;
            if(_moveLimit > 24)
            {
                victory.gameObject.SetActive(true);
                optionsBack.gameObject.SetActive(true);
                retryB.gameObject.SetActive(true);
                restartB.gameObject.SetActive(true);
                boxStarEmpty.gameObject.SetActive(true);
                star1.gameObject.SetActive(true);

                if (FindObjectOfType<Audio>().isMuted == false)
                {
                    FindObjectOfType<Audio>()._star1.Play();
                }
            }
            else if (_moveLimit > 12 && _moveLimit <= 24)
            {
                victory.gameObject.SetActive(true);
                optionsBack.gameObject.SetActive(true);
                retryB.gameObject.SetActive(true);
                restartB.gameObject.SetActive(true);
                boxStarEmpty.gameObject.SetActive(true);
                star1.gameObject.SetActive(true);
                star2.gameObject.SetActive(true);

                if (FindObjectOfType<Audio>().isMuted == false)
                {
                    FindObjectOfType<Audio>()._star2.Play();
                }
            }
            else if (_moveLimit <= 12)
            {
                victory.gameObject.SetActive(true);
                optionsBack.gameObject.SetActive(true);
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
        SceneManager.LoadScene("Level3");
    }
    public void Restart()
    {
        SceneManager.LoadScene("Menu");
    }
}
