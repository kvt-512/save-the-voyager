using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderAsteroid : MonoBehaviour
{
    public int hitCap = 3;
    [SerializeField] GameObject colliderParticles;
    [SerializeField] AudioClip explosionSFX;
    [SerializeField] [Range(0, 1)] float explosionSFXVol;
    // [SerializeField] CameraShake cameraShake;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        hitCap -= damageDealer.GetDamage();
        if(hitCap <= 0) {
            Instantiate(colliderParticles, transform.position, Quaternion.identity);
            // StartCoroutine(cameraShake.Shake(1F, 1F));
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(explosionSFX, Camera.main.transform.position, explosionSFXVol);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Instantiate(colliderParticles, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
        AudioSource.PlayClipAtPoint(explosionSFX, Camera.main.transform.position, explosionSFXVol);
    }
}
