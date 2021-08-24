using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] Transform releasePoint;
    [SerializeField] GameObject asteroid;
    [SerializeField] float releaseSpeed = 2F;

    [SerializeField] float dealyTimeForRelease;
    [SerializeField] float nextRelease = 0.0F;
    float releaseRate = 10F;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ReleaseInIntervals();
    }

    private void ReleaseInIntervals() {
        if(Time.time > nextRelease) {
            StartCoroutine(TriggerAfterSec());
        }
    }

    private void ReleaseAsteroid() {
        var asteroidGameObject = Instantiate(asteroid, releasePoint.position, Quaternion.identity) as GameObject;
        var rb = asteroidGameObject.GetComponent<Rigidbody2D>();
        rb.AddForce(releasePoint.up * releaseSpeed, ForceMode2D.Impulse);
    }

    IEnumerator TriggerAfterSec() {
        nextRelease = Time.time + releaseRate;
        yield return new WaitForSeconds(dealyTimeForRelease);
        ReleaseAsteroid();
    }
}
