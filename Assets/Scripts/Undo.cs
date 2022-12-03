using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Undo : MonoBehaviour
{
    //on initialiste une liste qui détectera le tag de la dernière graine posée.
    public List<string> history = new List<string>();

    //On crée une liste où l'on mettra toutes les graines du niveau.
    [SerializeField] public List<GameObject> fleurs = new List<GameObject>();

    void Start()
    {
        //Création du listener pour le bouton.
        gameObject.GetComponent<Button>().onClick.AddListener(UndoFunction);
    }


    void Update()
    {
        
    }

    public void UndoFunction()
    {
        //On cherche la correspondance entre la dernière graine posée et les graines de la scène pour appeler le bon script.
        int j = history.Count - 1;
        for (int i = 0; i < fleurs.Count; i++)
        {
            if(fleurs[i].tag == history[j])
            {
                fleurs[i].gameObject.GetComponent<Plant>().Undo();
            }
        }
        //On supprime la dernière graine posée de l'historique.
        history.RemoveAt(history.Count - 1);
    }
}
