using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroids : MonoBehaviour,Expandable
{
    Vector2 planetRadius;
    float InitialDistance;
    bool hasHitPlanet;
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector2(0,0);
        planetRadius = transform.position.normalized * 5.6f;
        InitialDistance = Vector3.Distance(transform.position, planetRadius);
       
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasHitPlanet)
        expand();
    }

    public void expand()
    {
        planetRadius = transform.position.normalized * 5.5f;
        var currDistance = Vector3.Distance(transform.position, planetRadius);
        float amplitude=(1 - currDistance / InitialDistance) * 1.5f;
        transform.localScale = new Vector2(amplitude, amplitude);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Planet")
        {
            transform.localScale = new Vector2(0.6f, 0.6f);
            hasHitPlanet = true;
        }
    }
}
