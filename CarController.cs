using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
      public AudioSource source;
      public AudioClip hitBaddieAudio;
      public AudioClip contactSound;

      private PlayerInput inputManager;
      public List<WheelCollider> throttleWheels;
      public List<WheelCollider> steeringWheels;
      public float strengthCoefficient = 200000f;
      public float maxTurn = 20f;

      public Vector3 startPosition;
      //     public Transform startPosition; 

      public GameObject myCar;



      // Start is called before the first frame update
      void Start()
      {
            inputManager = GetComponent<PlayerInput>();
             startPosition = new Vector3(-90.95f, 0f, 25.05f);
      }

      // Update is called once per frame
      void FixedUpdate()
      {
            foreach (WheelCollider wheel in throttleWheels)
            {
                  wheel.motorTorque = strengthCoefficient * Time.deltaTime * inputManager.Acceleration;
                  wheel.wheelDampingRate = inputManager.wheelDampening;
            }

            foreach (WheelCollider wheel in steeringWheels)
            {
                  wheel.steerAngle = maxTurn * inputManager.Steering;
                  wheel.wheelDampingRate = inputManager.wheelDampening;
            }

            // to reposition the car
            if (OVRInput.GetUp(OVRInput.RawButton.Y))
            {
                  resetPosition();
            }
      }


      public void HitZombie()
      {
            source.PlayOneShot(hitBaddieAudio);
      }

      void OnTriggerEnter(Collider other)
      {
            if (other.CompareTag("Wall"))
            {
                  source.PlayOneShot(contactSound);
            }
      }


      private void resetPosition()
      {
            myCar.transform.position = startPosition;
      }



}
