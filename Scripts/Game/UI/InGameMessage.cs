using UnityEngine;
using UnityEngine.Pool;
using TMPro;

public class InGameMessage : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float fadeSpeed;
    private ObjectPool<InGameMessage> pool;
    private TextMeshProUGUI text;
    private float alpha;

    private void Awake()
    {
        if (text == null)
            text = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        ResetMessage();
    }

    private void Update()
    {
        transform.Translate(speed * Vector2.up * Time.deltaTime, Space.World);

        if (alpha > 0)
            FadeDown();
        else
            pool.Release(this);
        
    }

    private void FadeDown()
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, alpha);
        alpha -= fadeSpeed * Time.deltaTime * Time.deltaTime;
    }

    private void ResetMessage()
    {
        alpha = 1f;
    }

    public void SetPool(ObjectPool<InGameMessage> pool)
    {
        this.pool = pool;
    }
    public void ShowMessage(string message, Color color)
    {
        text.text = message;
        text.color = color;
    }
}
