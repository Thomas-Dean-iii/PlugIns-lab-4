using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorOrbit : MonoBehaviour
{
    public Transform Target;   // Player to orbit around
    public float Distance; // Orbit radius
    public float OrbitSpeed = 1f; // How fast the meteor orbits

    private float angle; // Current angle around the player

    void Start()
    {
        Distance = Random.Range(2f, 6f);

        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            Target = player.transform;
        }
        else
        {
            Debug.LogWarning("Player not found. MeteorOrbit will not work.");
        }
    }

    void Update()
    {
        if (Target == null) return;

        OrbitSpeed = Distance * .5f;
        angle += OrbitSpeed * Time.deltaTime;


        float x = Target.position.x + Mathf.Cos(angle) * Distance;
        float y = Target.position.y + Mathf.Sin(angle) * Distance;

        transform.position = new Vector2(x, y);
    }
}