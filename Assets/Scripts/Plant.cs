using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    private float originZ;
    private float targetX;
    private float targetY;
    private float targetZ;
 
    // Start is called before the first frame update
    void Start()
    {
        originX = transform.position.x;
        originZ = transform.position.z;
        counter.text = count.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<UIManager>().gameState == UIManager.State.InGameBagOpen)
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
                            transform.position.x + touch.deltaPosition.x * speed,
                            transform.position.y,
                            transform.position.z + touch.deltaPosition.y * speed
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
        transform.position = new Vector3(originX, 0.57f, originZ);
        FindObjectOfType<UIManager>()._moveLimit -= 1;
    }
}
