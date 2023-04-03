using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    private int score = 0;

    [SerializeField] private GameObject _gameOverScreen;
    [SerializeField] private GameObject _endLevelScreen;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _scoreTextBig;
    [SerializeField] private Button _restartButton;
    [SerializeField] private AudioSource _playerAudioSource;
    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private Button _quitButton;
    [SerializeField] private Button _mainMenuButton;

    private float _timer = 0;

    public bool LevelEnded;

    [SerializeField] private TextMeshProUGUI _fpsText;      // Pour afficher nos FPS en jeu.
    private float _deltaTime;                               // Sert aussi à cette fonction.

    private void Update()
    {
        DisplayFPS();

        _timer += Time.deltaTime;
        _timerText.text = (int)_timer + "s";
    }


    public void PlayerIsDead()
    {
        _gameOverScreen.SetActive(true);

        _timerText.gameObject.SetActive(false);

        _restartButton.gameObject.SetActive(true);
        _quitButton.gameObject.SetActive(true);
        _mainMenuButton.gameObject.SetActive(true);
    }


    public void EndLevel()
    {
        Debug.Log("Fin du niveau !");
        LevelEnded = true;
        _endLevelScreen.SetActive(true);
        _scoreText.gameObject.SetActive(false);     // Cache le compteur de points en haut à droite de l'écran.

        _scoreTextBig.text = score.ToString();      // Le score va s'afficher dans notre grand compteur de points (désactivé).
        _scoreTextBig.gameObject.SetActive(true);   // Affiche le compteur central de points.

        _restartButton.gameObject.SetActive(true);
        _quitButton.gameObject.SetActive(true);
        _mainMenuButton.gameObject.SetActive(true);

        _playerAudioSource.Stop();                  // Arrête le son de vent.
        _timerText.gameObject.SetActive(false);
    }


    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        _scoreText.SetText("Score : " + score);
    }

    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }


    public void ReloadScene()
    { SceneManager.LoadScene(SceneManager.GetActiveScene().name); }

    public void QuitGame()
    {
        Application.Quit();
    }


    private void DisplayFPS()
    {
        _deltaTime += (Time.deltaTime - _deltaTime) * 0.1f;
        float fps = 1.0f / _deltaTime;
        _fpsText.text = Mathf.Ceil(fps).ToString() + " fps";
    }
}
