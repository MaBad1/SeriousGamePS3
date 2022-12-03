using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Undo : MonoBehaviour
{
    //on initialiste une liste qui d�tectera le tag de la derni�re graine pos�e.
    public List<string> history = new List<string>();

    //On cr�e une liste o� l'on mettra toutes les graines du niveau.
    [SerializeField] public List<GameObject> fleurs = new List<GameObject>();

    void Start()
    {
        //Cr�ation du listener pour le bouton.
        gameObject.GetComponent<Button>().onClick.AddListener(UndoFunction);
    }


    void Update()
    {
        
    }

    public void UndoFunction()
    {
        //On cherche la correspondance entre la derni�re graine pos�e et les graines de la sc�ne pour appeler le bon script.
        int j = history.Count - 1;
        for (int i = 0; i < fleurs.Count; i++)
        {
            if(fleurs[i].tag == history[j])
            {
                fleurs[i].gameObject.GetComponent<Plant>().Undo();
            }
        }
        //On supprime la derni�re graine pos�e de l'historique.
        history.RemoveAt(history.Count - 1);
    }
}
