using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    [SerializeField] GameObject menuBack;
    [SerializeField] GameObject title;
    [SerializeField] GameObject startB;
    [SerializeField] GameObject optionsB;
    [SerializeField] GameObject muteB;
    [SerializeField] GameObject indiceIco;
    [SerializeField] GameObject bagClose;
    [SerializeField] GameObject bagOpen;
    [SerializeField] GameObject optionsTitle;
    [SerializeField] GameObject orangerie;
    [SerializeField] GameObject backB;
    [SerializeField] GameObject homeB;
    [SerializeField] GameObject clue;
    [SerializeField] Text moveLimit;
    [SerializeField] Text orangeNb;
    [SerializeField] Text yellowNb;
    [SerializeField] Text blueNb;
    [SerializeField] Text violetNb;
    [SerializeField] Text roseNb;
    [SerializeField] Text cyanNb;
    

    [SerializeField] GameObject graineBleue;
    [SerializeField] GameObject graineOrange;
    [SerializeField] GameObject graineJaune;
    [SerializeField] GameObject graineCyan;
    [SerializeField] GameObject graineViolette;
    [SerializeField] GameObject graineRose;

    public bool isMuted = false;
    public bool clueOnSceen = false;
    public int _moveLimit = 18;

    public enum State
    {
        Menu,
        InGameBagClose,
        InGameBagOpen,
        GameOver
    }

    public State gameState = State.Menu;
    // Start is called before the first frame update
    void Start()
    {
        indiceIco.gameObject.SetActive(false);
        orangerie.gameObject.SetActive(false);
        bagClose.gameObject.SetActive(false);
        bagOpen.gameObject.SetActive(false);
        homeB.gameObject.SetActive(false);
        backB.gameObject.SetActive(false);
        clue.gameObject.SetActive(false);
        moveLimit.gameObject.SetActive(false);
        orangeNb.gameObject.SetActive(false);
        yellowNb.gameObject.SetActive(false);
        blueNb.gameObject.SetActive(false);
        violetNb.gameObject.SetActive(false);
        roseNb.gameObject.SetActive(false);
        cyanNb.gameObject.SetActive(false);
        optionsTitle.gameObject.SetActive(false);
        graineBleue.gameObject.SetActive(false);
        graineOrange.gameObject.SetActive(false);
        graineJaune.gameObject.SetActive(false);
        graineCyan.gameObject.SetActive(false);
        graineViolette.gameObject.SetActive(false);
        graineRose.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        startB.GetComponent<Button>().onClick.AddListener(StartGame);
        bagClose.GetComponent<Button>().onClick.AddListener(OpenBag);
        muteB.GetComponent<Button>().onClick.AddListener(MuteSwitch);
        indiceIco.GetComponent<Button>().onClick.AddListener(ShowClue);

        if(_moveLimit <= 0)
        {

        }
    }

    public void StartGame()
    {
        gameState = State.InGameBagClose;

        indiceIco.gameObject.SetActive(true);
        orangerie.gameObject.SetActive(true);
        bagClose.gameObject.SetActive(true);
        startB.gameObject.SetActive(false);
        title.gameObject.SetActive(false);
        menuBack.gameObject.SetActive(false);
    }

    public void OpenBag()
    {
        if(gameState == State.InGameBagClose)
        {
            gameState = State.InGameBagOpen;
            bagClose.gameObject.SetActive(false);
            bagOpen.gameObject.SetActive(true);
            graineBleue.gameObject.SetActive(true);
            graineOrange.gameObject.SetActive(true);
            graineJaune.gameObject.SetActive(true);
            graineCyan.gameObject.SetActive(true);
            graineViolette.gameObject.SetActive(true);
            graineRose.gameObject.SetActive(true);
            moveLimit.gameObject.SetActive(true);
            orangeNb.gameObject.SetActive(true);
            yellowNb.gameObject.SetActive(true);
            blueNb.gameObject.SetActive(true);
            violetNb.gameObject.SetActive(true);
            roseNb.gameObject.SetActive(true);
            cyanNb.gameObject.SetActive(true);

            moveLimit.text = "actions lefts" + _moveLimit.ToString();
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
}
