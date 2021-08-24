using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] float backgroundScrollSpeed = 5F;
    Material myMaterial;
    Vector2 backgroundQuadOffset;
    // Start is called before the first frame update
    void Start()
    {
        myMaterial = GetComponent<Renderer>().material;
        backgroundQuadOffset = new Vector2(0F, backgroundScrollSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        myMaterial.mainTextureOffset += backgroundQuadOffset * Time.deltaTime;
    }
}
