using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatableObject : MonoBehaviour
{
    public float initialXSpeed = 0.02f;
    public float initialYSpeed = 0.02f;
    public float initialZSpeed = 0.02f;

    public List<Texture> textures; // List of textures to cycle through

    private float xSpeed;
    private float ySpeed;
    private float zSpeed;

    private int currentTextureIndex = 0; // Index of the current texture

    // Start is called before the first frame update
    void Start()
    {
        xSpeed = initialXSpeed;
        ySpeed = initialYSpeed;
        zSpeed = initialZSpeed;

        // Set the initial texture
        if (textures != null && textures.Count > 0)
        {
            GetComponent<Renderer>().material.mainTexture = textures[currentTextureIndex];
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Apply the rotation
        transform.Rotate(new Vector3(xSpeed, ySpeed, zSpeed));
    }

    // This method is called when the mouse is clicked over the object
    void OnMouseDown()
    {
        // Increment the texture index and loop back to 0 if it exceeds the number of textures
        currentTextureIndex = (currentTextureIndex + 1) % textures.Count;

        // Apply the new texture
        GetComponent<Renderer>().material.mainTexture = textures[currentTextureIndex];
    }
}