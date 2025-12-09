using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{

    private void Update()
    {
        CheckForCollisions();
    }

    private void CheckForCollisions()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                HandleCollision(hit);
            }
        }
    }

    private void HandleCollision(RaycastHit hit)
    {
        Debug.Log("Hit: " + hit.collider.name);

        IBall ball = hit.collider.GetComponent<IBall>();
        MoneyManager.AssignMoney(ball.GetValue());
        MoneyUIManager.Instance.DisplayOnScreenMoneyUI(ball.GetValue(), hit.collider.transform.position);

        Destroy(hit.collider.gameObject);
    }


}
