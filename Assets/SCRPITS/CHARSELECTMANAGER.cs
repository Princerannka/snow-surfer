using System;
using UnityEngine;

public class CHARSELECTMANAGER : MonoBehaviour
{
    [SerializeField] GameObject scoreCanvas;
    [SerializeField] GameObject dino;
    [SerializeField] GameObject frog;
    void Start()
    {
        Time.timeScale=0;
    }

    void BeginGame()

    {
        Time.timeScale=1f;
        scoreCanvas.SetActive(true);
        gameObject.SetActive(false);
    }
    
    public void choosedino()
    {
        Debug.Log("clicked");
        dino.SetActive(true);
        BeginGame();
    }

    public void choosefrog()
    {
        Debug.Log("clicked");
        frog.SetActive(true);
        BeginGame();
    }
}

   