using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject startB;
    [SerializeField] GameObject muteB;
    [SerializeField] GameObject boxMenu;





    public bool isMuted = false;
    public bool clueOnSceen = false;


    void Start()
    {

        //Debug.Log(gameState);
        startB.GetComponent<Button>().onClick.AddListener(StartGame);
        muteB.GetComponent<Button>().onClick.AddListener(MuteSwitch);

    }

    void Update()
    {

    }

    public void StartGame()
    {
        SceneManager.LoadScene("Tuto");
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

}
