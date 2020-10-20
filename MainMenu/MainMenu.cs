using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    Animator _anim;

    void Start() 
    {
        _anim = GameObject.Find("Intro").GetComponent<Animator>();
    }
    
    public void LoadGame()
    {
        StartCoroutine("LoadLevel");
    }


    IEnumerator LoadLevel()
    {
        _anim.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1.0f);
        _anim.SetTrigger("FadeOut");
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
