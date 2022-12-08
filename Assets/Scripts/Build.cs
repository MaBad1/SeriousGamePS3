using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Build : MonoBehaviour
{
    [SerializeField] Canvas ui;
    [SerializeField] Canvas build;
    [SerializeField] ParticleSystem win;
    [SerializeField] GameObject broken;
    [SerializeField] GameObject restored;

    // Start is called before the first frame update
    void Start()
    {
        restored.gameObject.SetActive(false);
        ui.gameObject.SetActive(false);
        win.Stop();
        gameObject.GetComponent<Button>().onClick.AddListener(BuildFunction);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BuildFunction()
    {
        restored.gameObject.SetActive(true);
        broken.gameObject.SetActive(false);
        ui.gameObject.SetActive(true);
        build.gameObject.SetActive(false);
    }

    
}
