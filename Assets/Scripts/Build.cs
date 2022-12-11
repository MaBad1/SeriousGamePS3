using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class Build : MonoBehaviour
{
    [SerializeField] Canvas ui;
    [SerializeField] Canvas build;
    [SerializeField] ParticleSystem win;
    [SerializeField] GameObject broken;
    [SerializeField] GameObject restored;
    [SerializeField] CinemachineVirtualCamera CamBroken;
    [SerializeField] CinemachineVirtualCamera CamGameplay;
    [SerializeField] ParticleSystem buildPart;
    [SerializeField] GameObject boxGraines;

    private Animator animator;


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        restored.gameObject.SetActive(false);
        ui.gameObject.SetActive(false);
        boxGraines.gameObject.SetActive(false);
        win.Stop();
        buildPart.Stop();
        gameObject.GetComponent<Button>().onClick.AddListener(BuildFunction);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BuildFunction()
    {
        CamBroken.Priority = 0;
        CamGameplay.Priority = 1;
        buildPart.Play();
        Invoke("SwitchMods",2f);
    }

    public void SwitchMods()
    {
        restored.gameObject.SetActive(true);
        broken.gameObject.SetActive(false);
        ui.gameObject.SetActive(true);
        build.gameObject.SetActive(false);
    }
    
}
