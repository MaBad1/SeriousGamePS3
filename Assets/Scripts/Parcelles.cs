using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parcelles : MonoBehaviour
{
    [SerializeField] ParticleSystem winPart;
    // Start is called before the first frame update
    void Start()
    {
        winPart.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayPart()
    {
        winPart.Emit(10);
    }
}
