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
    [SerializeField] GameObject backB;
    [SerializeField] GameObject homeB;
    [SerializeField] GameObject boxMenu;
    [SerializeField] GameObject boxOptions;




    public bool isMuted = false;
    public bool clueOnSceen = false;


    
    // Start is called before the first frame update
    void Start()
    {
        boxOptions.gameObject.SetActive(false);

        //Debug.Log(gameState);
        startB.GetComponent<Button>().onClick.AddListener(StartGame);
        muteB.GetComponent<Button>().onClick.AddListener(MuteSwitch);
        optionsB.GetComponent<Button>().onClick.AddListener(OptionsShow);
        homeB.GetComponent<Button>().onClick.AddListener(MainMenu);
        backB.GetComponent<Button>().onClick.AddListener(StepBack);

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
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

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }



    public void OptionsShow()
    {
        FindObjectOfType<GameManager>().gameState = GameManager.State.InOptions;
        boxOptions.gameObject.SetActive(true);
    }

   

    public void StepBack()
    {
        FindObjectOfType<GameManager>().gameState = GameManager.State.Menu;
        boxOptions.gameObject.SetActive(false);
    }

}
