using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    [SerializeField] GameObject plante;
    [SerializeField] GameObject detector;

    private Touch touch;
    public float speed = 0.01f;
    private bool finalPosition = false;
    private float originX;
    private float originZ;
    private float detectMaxX;
    private float detectMaxY;
    private float detectMinX;
    private float detectMinY;
    // Start is called before the first frame update
    void Start()
    {
        originX = transform.position.x;
        originZ = transform.position.z;
        detectMaxX = detector.transform.position.x + 82.6f;
        detectMinX = detector.transform.position.x - 82.6f;
        detectMaxY = detector.transform.position.y + 82.6f;
        detectMinY = detector.transform.position.y - 82.6f;
    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<UIManager>().gameState == UIManager.State.InGameBagOpen)
        {

            if (Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);

                if(touch.deltaPosition.x < detectMaxX && touch.deltaPosition.x > detectMinX && touch.deltaPosition.y < detectMaxY && touch.deltaPosition.y > detectMinY)
                {
                    if (touch.phase == TouchPhase.Began)
                    {

                    }
                    else if (touch.phase == TouchPhase.Moved)
                    {
                        transform.position = new Vector3(
                            transform.position.x + touch.deltaPosition.x * speed,
                            transform.position.y,
                            transform.position.z + touch.deltaPosition.y * speed
                            );
                    }
                    else if (touch.phase == TouchPhase.Ended)
                    {
                        finalPosition = true;
                        Debug.Log(finalPosition);
                        ResetPose();
                    }
                }
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (tag == other.tag && finalPosition == true)
        {
            Instantiate(plante, new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z), Quaternion.identity);
            finalPosition = false;
        }
    }

    private void ResetPose()
    {
        transform.position = new Vector3(originX, 0.57f, originZ);
    }
}
