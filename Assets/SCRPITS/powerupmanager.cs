using UnityEngine;

public class powerupmanager : MonoBehaviour
{
    [SerializeField] powerupSO powerup;

PLAYERCONTROLS player;

SpriteRenderer spriteRenderer;
float timeleft;

 void Start()
{
    player = FindFirstObjectByType<PLAYERCONTROLS>();
    spriteRenderer = GetComponent<SpriteRenderer>();
    timeleft = powerup.GetTime();
}


 void Update()
{
        
        countdowntimer();
}

void countdowntimer()
    {
        if (spriteRenderer.enabled == false)
        {
            if(timeleft >0)
            {
                timeleft -=Time.deltaTime;

                if(timeleft<=0)
                {
                    player.deactivatepowerup(powerup);
                }
            }
            
            
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        int layerIndex = LayerMask.NameToLayer("Player");

        if(collision.gameObject.layer == layerIndex && spriteRenderer.enabled )
        {
            spriteRenderer.enabled = false;
            player.Activatepowerup(powerup);
           
        }
    }
}
