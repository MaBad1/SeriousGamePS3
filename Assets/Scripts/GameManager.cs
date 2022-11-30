using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public enum State
    {
        Menu,
        InOptions,
        InGameBagCloseLvlUn,
        InGameBagCloseLvlDeux,
        InGameBagClose,
        InGameBagOpenLvlUn,
        InGameBagOpenLvlDeux,
        InGameBagOpen,
        GameOver,
        Win
    }

    public State gameState = State.Menu;
    private void Awake()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
