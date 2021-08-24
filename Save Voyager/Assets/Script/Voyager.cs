using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voyager : MonoBehaviour
{
    float rotateSpeed = 5F;
    [SerializeField] GameObject explosionVFX;
    [SerializeField] AudioClip explosionSFX;
    [SerializeField] [Range(0, 1)] float explosionSFXVol;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0F, 0F, rotateSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        Instantiate(explosionVFX, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
        AudioSource.PlayClipAtPoint(explosionSFX, Camera.main.transform.position, explosionSFXVol);
        FindObjectOfType<Level>().LoadGameOver();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Instantiate(explosionVFX, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
        AudioSource.PlayClipAtPoint(explosionSFX, Camera.main.transform.position, explosionSFXVol);
        FindObjectOfType<Level>().LoadGameOver();   
    }
}
