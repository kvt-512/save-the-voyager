using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    // [SerializeField] AudioClip openingMusic;
    // [SerializeField] [Range(0, 1)] float openingMusicVol; 
    // Start is called before the first frame update
    private void Awake() {
        SetSingleton();
    }

    private void SetSingleton() {
        if( FindObjectsOfType(GetType()).Length > 1) {
            Destroy(this.gameObject);
        }
        else {
            DontDestroyOnLoad(this.gameObject);
        }
    }
    void Start()
    {
        // PlayMusic();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // private void PlayMusic() {
    //     AudioSource.PlayClipAtPoint(openingMusic, Camera.main.transform.position, openingMusicVol);
    // }
}
