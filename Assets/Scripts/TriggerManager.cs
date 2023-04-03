using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerManager : MonoBehaviour
{
    public UnityEvent triggerEntered;    
    private AudioSource _audioSource;

    [SerializeField] private int _scoreValue;
    [SerializeField] private bool _isArrival;

    GameManager gm;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Quand le joueur passe dans un checkpoint, la méthode UpdateScore de GameManager est appelée (score++) :
        //   triggerEntered.AddListener(gm.UpdateScore);

        triggerEntered.Invoke();
        _audioSource.Play();
        gm.UpdateScore(_scoreValue);


        if (_isArrival) gm.EndLevel();
    }
}
