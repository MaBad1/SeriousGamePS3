using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Plant : MonoBehaviour
{
    [SerializeField] GameObject plante;
    [SerializeField] Material triggerOn;
    [SerializeField] Material triggerOff;
    [SerializeField] Text counter;
    [SerializeField] public string selectableTag = "Selectable";
    [SerializeField] public string matchingTag = "Matching";


    private Touch touch;
    public float speed = 0.01f;
    public int count = 2;
    private bool finalPosition = false;
    private bool parcelleStop = false;
    private bool move = false;
    private float originX;
    private float originY;
    private float originZ;
    private float targetX;
    private float targetY;
    private float targetZ;
    public string checker;


    private void Awake()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        if (sceneName == "Level3")
        {
            checker = "Level3";
            
        }
        if (sceneName == "Level2")
        {
            checker = "Level2";
        }
        if (sceneName == "Level1")
        {
            checker = "Level1";
        }
        
    }


    // Start is called before the first frame update
    void Start()
    {
        
        originX = transform.position.x;
        originY = transform.position.y;
        originZ = transform.position.z;
        counter.text = count.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (FindObjectOfType<GameManager>().gameState == GameManager.State.InGameBagOpen 
            || FindObjectOfType<GameManager>().gameState == GameManager.State.InGameBagOpenLvlUn 
            || FindObjectOfType<GameManager>().gameState == GameManager.State.InGameBagOpenLvlDeux)
        {
            if (Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);
                

                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    var selection = hit.transform;
                    if (selection.CompareTag(selectableTag))
                    {
                        move = true;
                    }
                }

                if ( move == true)
                {
                    if (touch.phase == TouchPhase.Began)
                    {
                        finalPosition = false;
                        parcelleStop = false;
                    }
                    else if (touch.phase == TouchPhase.Moved)
                    {
                        transform.position = new Vector3(
                            hit.transform.position.x,
                            transform.position.y,
                            hit.transform.position.z
                            );
                        //Debug.Log(finalPosition);
                    }
                    else if (touch.phase == TouchPhase.Ended)
                    {
                        finalPosition = true;
                        move = false;

                        PlantTest();
                    }
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        /*if (tag == other.tag && finalPosition == true)
        {

            Instantiate(plante, new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z), Quaternion.identity);
            finalPosition = false;
        }*/
        other.GetComponent<MeshRenderer>().material = triggerOn;
        if (matchingTag == other.tag)
        {
            
            targetX = other.transform.position.x;
            targetY = other.transform.position.y;
            targetZ = other.transform.position.z;
            parcelleStop = true;
            Debug.Log(other.tag);
        }
        else { parcelleStop = false; }
    }

    private void OnTriggerExit(Collider other)
    {
        other.GetComponent<MeshRenderer>().material = triggerOff;
    }

    private void PlantTest()
    {
        if (finalPosition == true && parcelleStop == true)
        {
            Instantiate(plante, new Vector3(targetX, targetY, targetZ), Quaternion.identity);
            finalPosition = false;
            parcelleStop = false;
            count -= 1;
            counter.text = count.ToString();
            
            ResetPose();
            if (count <= 0)
            {
                gameObject.SetActive(false);
            }
        }
        else
        {
            finalPosition = false;
            parcelleStop = false;
            ResetPose();
        }
    }

    private void ResetPose()
    {
        transform.position = new Vector3(originX, originY, originZ);
        if (checker == "Level3")
        {
            FindObjectOfType<UILvl3>()._moveLimit -= 1;
        }
        if (checker == "Level2")
        {
            FindObjectOfType<UILvl2>()._moveLimitDeux -= 1;
        }
        if (checker == "Level1")
        {
            FindObjectOfType<UILvl1>()._moveLimitUn -= 1;
        }

    }
}
