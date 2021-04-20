using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Civilian : MonoBehaviour
{

    void Start()
    {
        RagDoll(true);
    }


    void RagDoll(bool value)
    {
        var bodyParts = GetComponentsInChildren<Rigidbody>();
        
        foreach (var bodypart in bodyParts)
        {
            bodypart.isKinematic = value;
        }
        var colliders = GetComponentsInChildren<Collider>();
        foreach (var collider in colliders)
        {
            collider.enabled = value;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Car"))
        {
              ScoreBox.currentScore--;

            other.GetComponent<CarController>().HitZombie();
            GetComponent<Animator>().enabled = false;
            RagDoll(false);
            var bodyParts = GetComponentsInChildren<Rigidbody>();
            foreach (var bodyPart in bodyParts)
            {
                bodyPart.AddExplosionForce(1000, bodyPart.transform.position, 1f);
            }
            this.enabled = false;
        }
    }
}
