using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    Text _scoreText;
    // Start is called before the first frame update
    void Start()
    {
        _scoreText.text = "Your score is " + 0;
    }

    // Update is called once per frame
    public void UpdateScore(int playerScore)
    {
        _scoreText.text = playerScore.ToString();
    }
}
