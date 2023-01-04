using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Herbier : MonoBehaviour
{
    [SerializeField] Button herbier;
    [SerializeField] Button left;
    [SerializeField] Button right;
    [SerializeField] Button back;
    [SerializeField] List<GameObject> pages = new List<GameObject>();

    private int show = -1;
    // Start is called before the first frame update
    void Start()
    {
        left.gameObject.SetActive(false);
        right.gameObject.SetActive(false);
        back.gameObject.SetActive(false);

        for(int i = 0; i < pages.Count; i++)
        {
            pages[i].gameObject.SetActive(false);
        }

        herbier.GetComponent<Button>().onClick.AddListener(HerbierOpen);
        back.GetComponent<Button>().onClick.AddListener(HerbierClose);
        right.GetComponent<Button>().onClick.AddListener(NextPage);
        left.GetComponent<Button>().onClick.AddListener(PrevPage);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void HerbierOpen()
    {
        show = 0;

        left.gameObject.SetActive(true);
        right.gameObject.SetActive(true);
        back.gameObject.SetActive(true);

        pages[0].gameObject.SetActive(true);
    }

    private void HerbierClose()
    {
        show = -1;

        left.gameObject.SetActive(false);
        right.gameObject.SetActive(false);
        back.gameObject.SetActive(false);

        for (int i = 0; i < pages.Count; i++)
        {
            pages[i].gameObject.SetActive(false);
        }
    }

    private void NextPage()
    {
        if(show < pages.Count-1)
        {
            show += 1;

            pages[show].gameObject.SetActive(true);
        }
        
    }

    private void PrevPage()
    {
        if(show > 0)
        {
            show -= 1;

            pages[show + 1].SetActive(false);
        }
        
    }
}
