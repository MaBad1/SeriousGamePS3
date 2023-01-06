using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Plant : MonoBehaviour
{
    [SerializeField] GameObject plante;
    [SerializeField] GameObject vert;
    [SerializeField] GameObject hori;
    [SerializeField] Material triggerOn;
    [SerializeField] Material triggerOff;
    [SerializeField] Material colorMat;
    [SerializeField] Text counter;
    [SerializeField] public string selectableTag = "Selectable";
    [SerializeField] public string matchingTag = "Matching";
    public List<GameObject> planted = new List<GameObject>();
    public List<GameObject> tagAreasResetO = new List<GameObject>();
    public List<string> tagAreasResetS = new List<string>();
    public List<bool> winCheckReset = new List<bool>();

    private GameObject stock;
    private GameObject plant;
    private Touch touch;
    public int count = 2;
    private bool finalPosition = false;
    private bool parcelleStop = false;
    private bool move = false;
    public bool addWinPoints = false;
    private float originX;
    private float originY;
    private float originZ;
    private float targetX;
    private float targetY;
    private float targetZ;
    private float reducerX;
    private float reducerY;
    private float reducerZ;
    private float enlargerX;
    private float enlargerY;
    private float enlargerZ;
    private float vOriginX;
    private float vOriginY;
    private float vOriginZ;
    private float hOriginX;
    private float hOriginY;
    private float hOriginZ;
    private bool isPlanted = false;
    public string checker;
    public float speed = 0.05f;

    private void Awake()
    {
        //detecte dans quelle scene on se trouve et l'enregistre dans le checker.
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
        if (sceneName == "Tuto")
        {
            checker = "Tuto";
        }

    }

    void Start()
    {
        enlargerX = gameObject.transform.localScale.x;
        enlargerY = gameObject.transform.localScale.y;
        enlargerZ = gameObject.transform.localScale.z;

        reducerX = gameObject.transform.localScale.x * 0.8f;
        reducerY = gameObject.transform.localScale.y *0.8f;
        reducerZ = gameObject.transform.localScale.z *0.8f;
        //save la position originale de la graine.
        originX = transform.position.x;
        originY = transform.position.y;
        originZ = transform.position.z;

        vOriginX = vert.gameObject.transform.position.x;
        vOriginY = vert.gameObject.transform.position.y;
        vOriginZ = vert.gameObject.transform.position.z;

        hOriginX = hori.gameObject.transform.position.x;
        hOriginY = hori.gameObject.transform.position.y;
        hOriginZ = hori.gameObject.transform.position.z;

        //update l'affichage du nombre de graine � poser.
        counter.text = count.ToString();
    }

    void Update()
    {
        //fonction de d�placement des graines par le joueur.
        if (FindObjectOfType<GameManager>().gameState == GameManager.State.InGameBagOpen 
            || FindObjectOfType<GameManager>().gameState == GameManager.State.InGameBagOpenLvlUn 
            || FindObjectOfType<GameManager>().gameState == GameManager.State.InGameBagOpenLvlDeux
            || FindObjectOfType<GameManager>().gameState == GameManager.State.TutoBagOpen)
        {
            //Detecte l'input du joueur.
            if (Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);
                
                //Cast un ray � la position du doigt.
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                //Detecte l'objet touch� par le raycast.
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit) && FindObjectOfType<GameManager>().cantMove == false)
                {
                    var selection = hit.transform;
                    //Si l'objet touch� a le m�me tag que la graine on peut le d�placer.
                    if (selection.CompareTag(selectableTag))
                    {
                        move = true;
                    }
                }

                if ( move == true)
                {
                    isPlanted = false;
                    
                    if (touch.phase == TouchPhase.Began)
                    {
                        FindObjectOfType<GameManager>().cantMove = true;
                        //Initialisation des bool�ens de d�tections de stop et de correspondance de la bonne parcelle.
                        finalPosition = false;
                        parcelleStop = false;

                        
                        

                        //Modif de taille pour feedback.
                        gameObject.transform.localScale = new Vector3(reducerX, reducerY, reducerZ);
                    }
                    else if (touch.phase == TouchPhase.Moved)
                    {
                        Ray ray2 = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                        //Detecte l'objet touch� par le raycast.
                        RaycastHit hit2;

                        if (Physics.Raycast(ray2, out hit2))
                        {
                            
                        }

                        transform.position = new Vector3(
                            hit2.transform.position.x,
                            transform.position.y,
                            hit2.transform.position.z
                            );
                        //d�placement de la graine dir�ctement de parcelles en parcelles.
                        /*transform.position = new Vector3(
                            transform.position.x + touch.deltaPosition.x * (speed),
                            transform.position.y,
                            transform.position.z + touch.deltaPosition.y * (speed)
                            );*/
                        //Debug.Log(finalPosition);


                    }
                    else if (touch.phase == TouchPhase.Ended)
                    {
                        FindObjectOfType<GameManager>().cantMove = false;
                        //Quand on relache le doigt le bool�en de position finale de la graine s'active et celui de mouvement se d�sactive.
                        finalPosition = true;
                        move = false;

                        //On plante donc une plante ici.
                        PlantTest();

                        
                    }
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
       
        stock = other.gameObject;

        //d�termination du centre de la parcelle.
        targetX = other.transform.position.x;
        targetY = other.transform.position.y;
        targetZ = other.transform.position.z;

        vert.transform.position = new Vector3(other.transform.position.x, vOriginY, vOriginZ);
        hori.transform.position = new Vector3(hOriginX, hOriginY, other.transform.position.z);

        //application d'un mat�rial plus sombre sur la parcelle pour feedback visuel.
        if(other.tag != "Taken")
        {
            other.GetComponent<MeshRenderer>().material = triggerOn;
        }
        

        //Si le tag de la parcelle correspond au tag vis�, le bool�en de v�rification s'active.
        if (matchingTag == other.tag)
        {
            parcelleStop = true;
            //Debug.Log(other.tag);
        }
        else 
        { 
            parcelleStop = false; 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(isPlanted == false && other.tag != "Taken")
        {
            //Quand on quitte une parcelle le mat�rial redevient celui de base.
            other.GetComponent<MeshRenderer>().material = triggerOff;
        }
        else if(isPlanted == true)
        {
            other.GetComponent<MeshRenderer>().material = colorMat;
        }

        vert.transform.position = new Vector3(vOriginX, vOriginY, vOriginZ);
        hori.transform.position = new Vector3(hOriginX, hOriginY, hOriginZ);

    }

    private void PlantTest()
    {
        //Si la parcelle est vide :
        if(stock.tag != "Taken")
        {
            isPlanted = true;

            //on plante le prefab de plante au centre de la parcelle o� le joueur a relach� le doigt.
            plant = Instantiate(plante, new Vector3(targetX, targetY, targetZ), Quaternion.identity);

            //on r�duit le nombre de graine � planter et on actualise le compteur.
            count -= 1;
            counter.text = count.ToString();

            //on stocke le tag de la graine dans le script Undo.
            FindObjectOfType<Undo>().history.Add(tag);

            //On stocke les autres donn�es dans des listes pour la fonction Undo :
            tagAreasResetS.Add(stock.tag);
            stock.tag = "Taken";
            tagAreasResetO.Add(stock);

            //On stocke la plante qu'on a plant� dans une liste.
            planted.Add(plant);

            //En fonction du niveau on ajuste les variables de scores dans le bon script.

            if (checker == "Level3")
            {
                FindObjectOfType<UILvl3>()._moveLimit += 1;
            }
            if (checker == "Level2")
            {
                FindObjectOfType<UILvl2>()._moveLimitDeux += 1;
            }
            if (checker == "Level1")
            {
                FindObjectOfType<UILvl1>()._moveLimitUn += 1;
            }
            if (checker == "Tuto")
            {
                FindObjectOfType<UITuto>()._moveLimitUn += 1;
            }

            //on reset la position de la graine.
            ResetPose();

            

            //Si la derni�re parcelle touch�e correspond au tag cibl� :
            if (finalPosition == true && parcelleStop == true)
            {

                //on r�initialise les bool�ens.
                finalPosition = false;
                parcelleStop = false;

                //On stocke le bool�en qui pr�cise si on a ajout� un point de victoire ou non (dans ce cas on en a ajout� un).
                addWinPoints = true;
                winCheckReset.Add(addWinPoints);

                stock.GetComponent<Parcelles>().PlayPart();

                //En fonction du niveau on ajuste les variables de win condition dans le bon script.
                if (checker == "Level3")
                {
                    FindObjectOfType<UILvl3>().wincheck += 1;

                }
                if (checker == "Level2")
                {
                    FindObjectOfType<UILvl2>().wincheck += 1;

                }
                if (checker == "Level1")
                {
                    FindObjectOfType<UILvl1>().wincheck += 1;
                }
                if (checker == "Tuto")
                {
                    FindObjectOfType<UITuto>().wincheck += 1;
                }

                if (FindObjectOfType<Audio>().isMuted == false)
                {
                    FindObjectOfType<Audio>()._right.Play();
                }

                //Debug.Log(FindObjectOfType<UILvl1>().wincheck);
            }
            //Si la parcelle ne correspond pas au bon tag :
            else if (finalPosition == true && parcelleStop == false)
            {
                //on r�p�te le m�me processus mais cette fois sans ajouter de point de victoire.
                finalPosition = false;
                parcelleStop = false;

                //plant.gameObject.transform.localScale = new Vector3(reducerX, reducerY, reducerZ);

                addWinPoints = false;
                winCheckReset.Add(addWinPoints);

                if (FindObjectOfType<Audio>().isMuted == false)
                {
                    FindObjectOfType<Audio>()._wrong.Play();
                }
                //Debug.Log(FindObjectOfType<UILvl1>().wincheck);
            }
            
        }
        //si la parcelle est d�j� occup�e :
        else if (stock.tag == "Taken")
        {
            
            //On reset les bool�ens de v�rification.
            finalPosition = false;
            parcelleStop = false;

            //On reset la position de la graine sans rien faire d'autre.
            ResetPose();
        }
    }

    //Quand la fonction est appel�e depuis le script Undo :
    public void Undo()
    {
        //On rajoute un mouvement disponible au compteur et on r�active la plante si elle ne l'�tait plus.
        count += 1;
        if(count > 0)
        {
            gameObject.SetActive(true);
        }
        //On update le texte.
        counter.text = count.ToString();

        //On rep�re la derni�re plante plant�e dans la liste et on la d�truit et retire de la liste.
        int i = planted.Count - 1;
        Destroy(planted[i]);
        planted.RemoveAt(planted.Count - 1);
        stock.GetComponent<MeshRenderer>().material = triggerOff;

        //Si lors de la derni�re action de cette graine on a ajout� un point on le retire et on supprime la donn�e du bool�en de v�rification de la liste.
        int j = winCheckReset.Count - 1;
        if (winCheckReset[j] == true)
        {
            if (checker == "Level3")
            {
                FindObjectOfType<UILvl3>().wincheck -= 1;
            }
            if (checker == "Level2")
            {
                FindObjectOfType<UILvl2>().wincheck -= 1;
            }
            if (checker == "Level1")
            {
                FindObjectOfType<UILvl1>().wincheck -= 1;
            }
            if (checker == "Tuto")
            {
                FindObjectOfType<UITuto>().wincheck -= 1;
            }
        }
        winCheckReset.RemoveAt(winCheckReset.Count - 1);

        int k = tagAreasResetO.Count - 1;
        int l = tagAreasResetS.Count - 1;
        tagAreasResetO[k].tag = tagAreasResetS[l];
        tagAreasResetO.RemoveAt(tagAreasResetO.Count - 1);
        tagAreasResetS.RemoveAt(tagAreasResetS.Count - 1);

        //Debug.Log(FindObjectOfType<UILvl1>().wincheck);


    }

    private void ResetPose()
    {
        //On reset la position de la graine en fonction de sa position originale stock�e au d�but.
        transform.position = new Vector3(originX, originY, originZ);
        gameObject.transform.localScale = new Vector3(enlargerX, enlargerY, enlargerZ);


        //si le compte de graine � poser est a 0 on la d�sactive.
        if (count <= 0)
        {
            Invoke("Desactivate", 0.1f);
        }
    }

    public void Desactivate()
    {
       
        
            gameObject.SetActive(false);
        
    }
}
