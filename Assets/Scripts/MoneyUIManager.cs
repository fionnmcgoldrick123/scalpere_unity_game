using TMPro;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class MoneyUIManager : MonoBehaviour
{
    public static MoneyUIManager Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI moneyText;

    [SerializeField] private RectTransform canvasTrans;
    [SerializeField] private GameObject popupPrefab; 

    [SerializeField] private float randomX = 5f;
    [SerializeField] private float randomY = 5f;

    private int money;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        money = 0;
        moneyText.text = "0";
    }

    public void UpdateMoneyUI(int moneyScored)
    {
        money += moneyScored;
        moneyText.text = money.ToString();
    }

    public void DisplayOnScreenMoneyUI(int moneyScored, Vector3 worldPos)
    {
         Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPos);

         screenPos.x += Random.Range(-randomX, randomX);
         screenPos.y += Random.Range(-randomY, randomY);

         GameObject popup = Instantiate(popupPrefab, canvasTrans);

         popup.transform.position = screenPos;
         popup.GetComponent<TextMeshProUGUI>().text = "+ " + moneyScored;
    }
}