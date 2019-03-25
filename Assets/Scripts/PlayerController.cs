using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    Camera mainCam;
    SpriteRenderer spriteRenderer;
    Vector3 spriteSize;
    float spriteBoundLeft, spriteBoundRight;

    public float moveSpeed;

    float halfHeight, halfWidth, hMin, hMax, vMin, vMax;

	// Use this for initialization
	void Start () {
		mainCam = Camera.main;
        halfHeight = mainCam.orthographicSize;
        halfWidth = mainCam.aspect * halfHeight;

        hMin = -halfWidth;
        hMax =  halfWidth;
        vMin = -halfHeight;
        vMax = halfHeight;

        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteSize = spriteRenderer.bounds.size;
        spriteBoundLeft = hMin + spriteSize.x / 2;
        spriteBoundRight = hMax - spriteSize.x/2;
    }
	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxis("Horizontal");
        Vector3 step = new Vector3(h, 0, 0);
        Vector3 nextPos = transform.position + (moveSpeed * step * Time.deltaTime);

        if (nextPos.x < spriteBoundLeft)
        {
            nextPos.x = spriteBoundLeft;
        }
        else if (nextPos.x > spriteBoundRight)
        {
            nextPos.x = spriteBoundRight;
        }

        transform.position = nextPos;
	}
}
