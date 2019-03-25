using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {
    
    Camera mainCam;
    Rigidbody2D rigidBod;
    SpriteRenderer spriteRenderer;
    Vector3 spriteSize;
    float spriteBoundLeft, spriteBoundRight;

    public bool testLaunch;
    public Vector2 launch;

    float halfHeight, halfWidth, hMin, hMax, vMin, vMax;

	// Use this for initialization
	void Start () {
        mainCam = Camera.main;
        halfHeight = mainCam.orthographicSize;
        halfWidth = mainCam.aspect * halfHeight;

        hMin = -halfWidth;
        hMax = halfWidth;
        vMin = -halfHeight;
        vMax = halfHeight;

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteSize = spriteRenderer.bounds.size;
        spriteBoundLeft = hMin + spriteSize.x / 2;
        spriteBoundRight = hMax - spriteSize.x / 2;

        rigidBod = GetComponent<Rigidbody2D>();
        SpawnBall();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SpawnBall() {
        if (testLaunch)
        {
            rigidBod.AddForce(launch, ForceMode2D.Impulse);
        }
        else {
            rigidBod.AddForce(new Vector2(Random.Range(-2, 2), 4), ForceMode2D.Impulse);
        }
    }
}
