using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    [SerializeField] GameObject right;
    [SerializeField] GameObject wrong;
    [SerializeField] GameObject star1;
    [SerializeField] GameObject star2;
    [SerializeField] GameObject star3;
    [SerializeField] GameObject birds;
    //[SerializeField] GameObject music;

    public AudioSource _right;
    public AudioSource _wrong;
    public AudioSource _star1;
    public AudioSource _star2;
    public AudioSource _star3;
    public AudioSource _birds;
    //public AudioSource _music;
    // Start is called before the first frame update
    void Start()
    {
        _right = right.GetComponent<AudioSource>();
        _wrong = wrong.GetComponent<AudioSource>();
        _star1 = star1.GetComponent<AudioSource>();
        _star2 = star2.GetComponent<AudioSource>();
        _star3 = star3.GetComponent<AudioSource>();
        _birds = birds.GetComponent<AudioSource>();
        //_music = music.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
