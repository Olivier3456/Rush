using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] private float _forceForward;
    [SerializeField] private float _horizontalForce;
    [SerializeField] private float _verticalForce;
    private PlayerManager _playerManager;
    private GameManager _gameManager;


    [SerializeField] private Transform _camera;

    private Rigidbody _rb;

    void Start()        
    {
        _rb = GetComponent<Rigidbody>();
        _playerManager = GetComponent<PlayerManager>();
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }


    void FixedUpdate()
    {
        /*     ( Ma version pour les contrôles )
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");


        GetComponent<Rigidbody>().AddForce(Vector3.right * horizontalAxis * _horizontalForce);      // Mouvement latéraux.
        GetComponent<Rigidbody>().AddForce(Vector3.up * verticalAxis * _verticalForce);             // Mouvement latéraux.

        */

        if (_playerManager.PlayerIsAlive && !_gameManager.LevelEnded)       // Si le joueur est en vie, et que le jeu n'est pas fini...
        {
            _rb.AddForce(_camera.forward * _forceForward);   // La direction du player suit celle de notre caméra (qu'on peut orienter à la souris).
        }
        else { _rb.velocity = Vector3.zero; }       // Si le joueur est mort, le joueur s'arrête.


        if (Input.GetKey(KeyCode.Space))   Boost();
    }

    public void MoveLeft()
    { _rb.AddForce(_camera.right * - _horizontalForce, ForceMode.Impulse); }

    public void MoveRight()
    { _rb.AddForce(_camera.right * _horizontalForce, ForceMode.Impulse); }

    public void Boost()
    {
        _rb.AddForce(_camera.forward * _forceForward);
    }
}
