using Unity.VisualScripting;
using UnityEngine;

public class RedBall : MonoBehaviour, IBall 
{
    public void move()
    {
        Debug.Log("moves");
    }

    public void die()
    {
        Debug.Log("die");
    }
}
