using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    Camera camera;
    Rigidbody2D rigidbody2D;
    SpriteRenderer spriteRenderer;
    Vector3 spriteSize;
    float spriteBoundLeft, spriteBoundRight;

    public Vector2 launch;

    float halfHeight, halfWidth, hMin, hMax, vMin, vMax;

	// Use this for initialization
	void Start () {
        camera = Camera.main;
        halfHeight = camera.orthographicSize;
        halfWidth = camera.aspect * halfHeight;

        hMin = -halfWidth;
        hMax = halfWidth;
        vMin = -halfHeight;
        vMax = halfHeight;

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteSize = spriteRenderer.bounds.size;
        spriteBoundLeft = hMin + spriteSize.x / 2;
        spriteBoundRight = hMax - spriteSize.x / 2;

        rigidbody2D = GetComponent<Rigidbody2D>();
        SpawnBall();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SpawnBall() {
        rigidbody2D.AddForce(launch, ForceMode2D.Impulse);
    }
}
