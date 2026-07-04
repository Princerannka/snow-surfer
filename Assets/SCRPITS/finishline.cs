using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finishline : MonoBehaviour
{
    [SerializeField] float Restartdelay = 1f;
    [SerializeField] ParticleSystem finishParticles;
    void OnTriggerEnter2D(Collider2D collision)
    {
        int layerIndex = LayerMask.NameToLayer("Player");

        if(collision.gameObject.layer == layerIndex )
        {
            finishParticles.Play();
            Invoke("Reloadscene",Restartdelay);
           
        }
        
    }


    void Reloadscene()
    {
        SceneManager.LoadScene(0);
    }
}