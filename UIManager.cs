using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    Text _scoreText;

    [SerializeField]
    Text _gameOverText;

    [SerializeField]
    Text _restart;

    [SerializeField]
    Image _livesImg;

    [SerializeField]
    Sprite[] _liveSprites;//Array to hold all of the lives sprites
    // Start is called before the first frame update
    GameManager _gameManager;
    void Start()
    {
        _restart.gameObject.SetActive(false);
        _gameOverText.gameObject.SetActive(false);//or _gameOverText.enabled = false
        _scoreText.text = "Your score is " + 0;
        _gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
        if(_gameManager == null)
        {
            Debug.LogError("GameManager component is missing");
        }
    }

    // Update is called once per frame
    public void UpdateScore(int playerScore)
    {
        _scoreText.text = "Your score is: " + playerScore.ToString();
    }

    public void UpdateLives(int currentLives)
    {
        _livesImg.sprite = _liveSprites[currentLives];//Get the current lives form the display image.
        if(currentLives == 0)
        {
            GameOverSequence();
        }
    }
    //Theis function works as well and can be called via the Player script
    /*public void GameOver()
    {
        _gameOverText.enabled = true;
    }*/

    IEnumerator GameOverTextFlicker()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.50f);
            _gameOverText.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            _gameOverText.gameObject.SetActive(true); 
        }
              
    }
    void GameOverSequence()
    {
        _gameManager.GameOver();
        _gameOverText.gameObject.SetActive(true);
        StartCoroutine("GameOverTextFlicker");
        _restart.gameObject.SetActive(true);
    }
}
