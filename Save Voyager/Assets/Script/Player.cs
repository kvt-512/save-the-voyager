using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float playerSpeed = 5F;
    float angle;
    Rigidbody2D rb;
    Vector2 mousePos;
    Vector2 movement;
    Vector2 lookDirection;
    [SerializeField] Transform firePoint;
    float projectileForce = 20F;
    [SerializeField] GameObject projectile;
    float nextShot = 0.0F;
    float shootRate = 0.1F;
    // [SerializeField] GameObject targetGameObject;
    Voyager targetGameObject;
    [SerializeField] bool hasTargetGameObject = false;

    int scoreValue = 1;
    float bounds = 7.4F;
    [SerializeField] GameObject explosionVFX;
    [SerializeField] AudioClip explosionSFX;
    [SerializeField] [Range(0, 1)] float explosionSFXVol;
     [SerializeField] AudioClip projectileSFX;
    [SerializeField] [Range(0, 1)] float projectileSFXVol;

    // Start is called before the first frame update
    void Start()
    {
        targetGameObject = FindObjectOfType<Voyager>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Get Axis for Player Movement
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        //Get the mouse positions according to unity world points
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        ShootWhenMouseClicked();

        //Increase score by time
        IncreaseScore();
    }

    void FixedUpdate() {
        PlayerMovement();
        FaceMouse();
        // GetVoyager();
    }

    private void PlayerMovement() {
        var newPos = rb.position + movement * playerSpeed * Time.deltaTime;
        newPos.x = Mathf.Clamp(newPos.x, -bounds, bounds);
        newPos.y = Mathf.Clamp(newPos.y, -bounds + 3, bounds - 3);
        rb.MovePosition(newPos);
    }

    private void FaceMouse() {
        lookDirection = new Vector2(
            mousePos.x - transform.position.x,
            mousePos.y - transform.position.y
        );

        transform.up = lookDirection;
    }

    private void ShootWhenMouseClicked() {
        if(Input.GetButton("Fire1") && Time.time > nextShot) {
            nextShot = Time.time + shootRate;
            Shoot();
        }
    }

    private void Shoot() {
        GameObject projectileGameObject = Instantiate(projectile, firePoint.position, firePoint.rotation) as GameObject;
        Rigidbody2D rb = projectileGameObject.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * projectileForce, ForceMode2D.Impulse);
        AudioSource.PlayClipAtPoint(projectileSFX, Camera.main.transform.position, projectileSFXVol);
    }

    private void GetVoyager() {
        if(Input.GetMouseButtonDown(1) && !hasTargetGameObject) {
            targetGameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;
            targetGameObject.transform.SetParent(this.transform);
            hasTargetGameObject = true;
        }
        else if(Input.GetMouseButtonDown(1) && hasTargetGameObject) {
            targetGameObject.transform.SetParent(null);
            hasTargetGameObject = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag != "Projectile") {
            Instantiate(explosionVFX, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            AudioSource.PlayClipAtPoint(explosionSFX, Camera.main.transform.position, explosionSFXVol);
            FindObjectOfType<Level>().LoadGameOver();
        }
    }

    private void IncreaseScore() {
        scoreValue = scoreValue + (int) Time.deltaTime;
        FindObjectOfType<GameSession>().AddScore(scoreValue);
    }
}
