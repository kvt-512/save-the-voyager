using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    ColliderAsteroid colliderAsteroid;
    // Start is called before the first frame update
    void Start()
    {
        colliderAsteroid = FindObjectOfType<ColliderAsteroid>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Voyager") {
            Destroy(this.gameObject);
        }

        if(other.gameObject.tag == "Asteroid") {
            Destroy(this.gameObject);
        }
    }

    // private void OnTriggerEnter2D(Collider2D other) {
    //     if(colliderAsteroid.hitCount == 3) {
    //         Destroy(other.gameObject);
    //     }
    // }
}
