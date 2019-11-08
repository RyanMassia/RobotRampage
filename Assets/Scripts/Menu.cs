using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 1 loooks for the battle scence and plays it
    public void StartGame()
    {
        SceneManager.LoadScene("Battle");
    }
    // 2 closes game
    public void Quit()
    {
        Application.Quit();
    }

}
