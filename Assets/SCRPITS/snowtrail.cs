using UnityEngine;

public class snowtrail : MonoBehaviour
{
    [SerializeField] ParticleSystem snowprticles;
    void OnCollisionEnter2D(Collision2D collision)
    {
        int layerIndex = LayerMask.NameToLayer("floor");
        if (collision.gameObject.layer == layerIndex)
        {
        snowprticles.Play();
        }
    }
    void  OnCollisionExit2D(Collision2D collision)

    {
        int layerIndex = LayerMask.NameToLayer("floor");
        if (collision.gameObject.layer == layerIndex)
        {
             snowprticles.Stop();
        }
       
    }
    
    
    
}
