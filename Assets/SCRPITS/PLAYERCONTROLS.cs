using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PLAYERCONTROLS : MonoBehaviour
{
   [SerializeField] float torqueamount = 1f;
   [SerializeField] float basespeed = 15f;
   [SerializeField] float boostspeed = 25f;
   [SerializeField] ParticleSystem powerupparcticles;
    InputAction moveAction;
    Rigidbody2D myRigidbody2D;
    SurfaceEffector2D  surfaceEffector2D;
    Vector2 moveVector;
    scoremanager Scoremanager;
     bool canControlplayer = true;
     float previousRotation;
     float TotalRotation;
     int Flipcount;
     int activepowerupscount;

    void Start()
    {
       
        moveAction=InputSystem.actions.FindAction("Move");
        myRigidbody2D=GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindFirstObjectByType<SurfaceEffector2D>();
        Scoremanager = FindFirstObjectByType<scoremanager>();
    }

 
    void Update()
    {
        if(canControlplayer)
        {
        RotatePlayer();
        BoostPlayer();
        Calculateflips();
    }   }

void RotatePlayer()
    {
       
        moveVector = moveAction.ReadValue<Vector2>();
        if (moveVector.x < 0)
        {
            myRigidbody2D.AddTorque(torqueamount);
        }
        else if (moveVector.x > 0)
        {

            myRigidbody2D.AddTorque(-torqueamount);
        }
    }

void BoostPlayer()
    {
        if (moveVector.y>0)
        {
             surfaceEffector2D.speed = boostspeed;
        }
        else
        {
            surfaceEffector2D.speed = basespeed;
        }
    }

    void Calculateflips()
    {
        float currentRotation = transform.rotation.eulerAngles.z;
        TotalRotation+= Mathf.DeltaAngle(previousRotation,currentRotation);
        if (TotalRotation>340 || TotalRotation< -340)
        {
            Flipcount+=1;
            TotalRotation=0;
            Scoremanager.AddScore(100);
        }
        previousRotation=currentRotation;
    }

   public void disablecontrol()
    {
        canControlplayer = false;

    }
    public void Activatepowerup(powerupSO powerup)
    {
        powerupparcticles.Play();
        activepowerupscount +=1;

        if (powerup.GetPowerupType()== "speed")
        {
            basespeed += powerup.GetValueChange();
            boostspeed+= powerup.GetValueChange();
        }
        else if (powerup.GetPowerupType() == "torque")
        {
            torqueamount += powerup.GetValueChange();
        }
    }


    public void deactivatepowerup(powerupSO powerup)
    {
        activepowerupscount -= 1;
        if(activepowerupscount==0)
        {
            powerupparcticles.Stop();
        }
        if (powerup.GetPowerupType()== "speed")
        {
            basespeed -= powerup.GetValueChange();
            boostspeed-= powerup.GetValueChange();
        }
        else if (powerup.GetPowerupType() == "torque")
        {
            torqueamount -= powerup.GetValueChange();
        }
    }
}

    
