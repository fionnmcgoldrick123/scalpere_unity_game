using System;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;
using UnityEngine.UIElements;

public class BallGenerator : MonoBehaviour
{
    [SerializeField] BackgroundScaler backgroundScalar;
    [SerializeField] GameObject redball;
    private float screenWidth;
    private float screenHeight;

    [SerializeField] float minHeight = 0f;
    [SerializeField] float maxHeight = 0f;
    [SerializeField] float minDirection = -3f;
    [SerializeField] float maxDirection = 3f;


    private const float bottomOffset = -5f;
    void Start()
    {
        float screenWidth = backgroundScalar.getWidth();
        float screenHeight = backgroundScalar.getHeight();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spawnBall(redball);
        }
    }

    void spawnBall(GameObject ball)
    {
        GameObject ballPrefab = Instantiate(ball);

        float xPos = randomWidthPos();

        ballPrefab.transform.position = new Vector3(xPos, screenHeight + bottomOffset, 0f);

        Rigidbody rb = ballPrefab.GetComponent<Rigidbody>();

        if(rb != null)
        {
            float upForce = UnityEngine.Random.Range(minHeight, maxHeight); 
            float sideForce = UnityEngine.Random.Range(minDirection, maxDirection); 

            Vector3 force = new Vector3(sideForce, upForce, 0f);

            rb.AddForce(force, ForceMode.Impulse);

            rb.AddTorque(UnityEngine.Random.insideUnitSphere * 4f, ForceMode.Impulse);
        }

        
    }

    private float randomWidthPos()
    {
        return UnityEngine.Random.Range(backgroundScalar.getLeftScreen(), backgroundScalar.getRightScreen());
    }
}
