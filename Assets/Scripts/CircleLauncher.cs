using UnityEngine;

public class CircleLauncher : MonoBehaviour
{

    [SerializeField] private Camera cam;

    [SerializeField] private float edgeOffset;

    [SerializeField] private float bottomOffset;

    void Awake()
    {
        DetermineSpawnLocation();
    }

    void Start()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
        }
    }
    private void DetermineSpawnLocation()
    {
        float camDistance = -Camera.main.transform.position.z;

        Vector3 leftEdge = Camera.main.ScreenToWorldPoint(
        new Vector3(0, Screen.height / 2f, camDistance));

        Vector3 rightEdge = Camera.main.ScreenToWorldPoint(
        new Vector3(Screen.width, Screen.height / 2f, camDistance));

        Vector3 bottomEdge = Camera.main.ScreenToWorldPoint(
            new Vector3(Screen.width / 2f, 0, camDistance));
    }
}
