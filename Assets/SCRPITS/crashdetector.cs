using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class crashdetector : MonoBehaviour
{
    [SerializeField] float Restartdelay = 1f;
    [SerializeField] ParticleSystem finishParticles;
    PLAYERCONTROLS playercontroller;

    void Start()
    {
        playercontroller = FindAnyObjectByType<PLAYERCONTROLS>();
    }

    void OnTriggerEnter2D(Collider2D collosion)
    {
        int layerIndex = LayerMask.NameToLayer("floor");

        if (collosion.gameObject.layer == layerIndex)
        {
            playercontroller.disablecontrol();
             finishParticles.Play();
             Invoke("Reloadscene",Restartdelay);
        }
    }
        void Reloadscene()
    {
        SceneManager.LoadScene(0);
    }
    

    
}