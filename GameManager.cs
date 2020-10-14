using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    bool _isGameOver;

    public void GameOver()
    {
        Debug.Log("GameManager::GameOver() called");//Professional comment
        _isGameOver = true;
    }

    void Update() {
        {
            if(Input.GetKeyDown(KeyCode.R) && _isGameOver == true)
            {
                SceneManager.LoadScene("Game");//or use index 0. Strings are slower
            }
        }
    }
}
