using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerManager : MonoBehaviour
{
    private GameManager _gameManager;

    private AudioSource _audioSource;
    [SerializeField] private AudioClip _criDeMort;

    public bool PlayerIsAlive = true;


    void Start()
    {
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        _audioSource = GetComponent<AudioSource>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            _gameManager.PlayerIsDead();
            _audioSource.clip = _criDeMort;
            _audioSource.loop = false;
            _audioSource.Play();
            PlayerIsAlive = false;
        }
    }

    void Update()
    {

    }
}
