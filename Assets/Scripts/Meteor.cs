using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine; // <-- add this

public class Meteor : MonoBehaviour
{
    private CinemachineImpulseSource impulseSource;

    void Start()
    {
        impulseSource = GetComponent<CinemachineImpulseSource>();
    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider whatIHit)
    {
        if (whatIHit.tag == "Player")
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().gameOver = true;
            Destroy(whatIHit.gameObject);
            Destroy(this.gameObject);
        }
        else if (whatIHit.tag == "Laser")
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().meteorCount++;
            Destroy(whatIHit.gameObject);

            // 🔥 Trigger camera shake
            if (impulseSource != null)
            {
                impulseSource.GenerateImpulse();
            }

            Destroy(this.gameObject);
        }
    }
}