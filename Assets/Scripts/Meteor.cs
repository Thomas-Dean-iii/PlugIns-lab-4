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
        transform.Translate(Vector3.down * Time.deltaTime * 2f);

        if (transform.position.y < -11f)
        {
            Destroy(this.gameObject);
        }
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