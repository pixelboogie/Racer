using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

      public float speed = 1.3f;



      public float Acceleration
      {
            get { return m_Acceleration; }
      }
      public float Steering
      {
            get { return m_Steering; }
      }


      float m_Acceleration;
      float m_Steering;


      bool m_FixedUpdateHappened;

      private bool accelerating = false;
      private bool breaking = false;
      private bool turningLeft = false;
      private bool turningRight = false;
      private bool reversing = false;


      public float wheelDampening;

      public AudioSource source;
      // public AudioClip screech;
      public AudioClip brakes;


      public AudioClip[] carSounds;
      public AudioClip carSounds0;
      public AudioClip carSounds1;
      public AudioClip carSounds2;
     private int thisRand;
      void Start()
      {
            carSounds = new AudioClip[3];
            carSounds[0] = carSounds0;
            carSounds[1] = carSounds1;
            carSounds[2] = carSounds2;

      }

      void Update()
      {
            GetPlayerInput();

            if (accelerating)
            {
                  m_Acceleration = speed;
                  wheelDampening = 500f;

            }
            else if (breaking)
            {
                  if (m_Acceleration < speed)
                  {
                        m_Acceleration = 0;
                  }
                  else
                  {
                        m_Acceleration = speed * -1; // make speed a negative
                  }

                  wheelDampening = 1000f;
            }

            else if (reversing)
            {

                  m_Acceleration = -1.3f;
                  wheelDampening = 1000f;
            }
            else
            {
                  m_Acceleration = 0f;
                  wheelDampening = 5f;
            }


            if (turningLeft)
                  m_Steering = -1f;
            else if (!turningLeft && turningRight)
                  m_Steering = 1f;
            else
                  m_Steering = 0f;


      }

      private void GetPlayerInput()
      {
            if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
            {
                  accelerating = true;
                  //  source.volume = .2f;
                   thisRand = UnityEngine.Random.Range(0,3);
                  source.PlayOneShot(carSounds[thisRand]);
                       

            }
            if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
            {
                  //    source.volume = 1.0f;
                  accelerating = false;
            }
            if (OVRInput.GetDown(OVRInput.Button.One))
            // if (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstickDown, OVRInput.Controller.RTouch))
            {
                  breaking = true;
                  //    source.volume = .2f;
                  source.PlayOneShot(brakes);
            }

            if (OVRInput.GetUp(OVRInput.Button.One))
            // if (OVRInput.GetUp(OVRInput.Button.PrimaryThumbstickDown, OVRInput.Controller.RTouch))
            {

                  //    source.volume = 1.0f;
                  breaking = false;
            }

            if (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstickDown, OVRInput.Controller.RTouch))
            {
                  reversing = true;
            }


            if (OVRInput.GetUp(OVRInput.Button.PrimaryThumbstickDown, OVRInput.Controller.RTouch))
            {
                  reversing = false;
            }
            if (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstickLeft, OVRInput.Controller.RTouch))
            {
                  turningLeft = true;
            }
            if (OVRInput.GetUp(OVRInput.Button.PrimaryThumbstickLeft, OVRInput.Controller.RTouch))
            {
                  turningLeft = false;
            }

            if (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstickRight, OVRInput.Controller.RTouch))
            {
                  turningRight = true;
            }
            if (OVRInput.GetUp(OVRInput.Button.PrimaryThumbstickRight, OVRInput.Controller.RTouch))
            {
                  turningRight = false;
            }
      }
}

