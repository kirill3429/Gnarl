using UnityEngine;
using UnityEngine.Pool;

public class MessagesPool : MonoBehaviour
{
    [SerializeField] private InGameMessage messagePrefab;
    public static ObjectPool<InGameMessage> pool;

    private void Start()
    {
        pool = new ObjectPool<InGameMessage>(OnCreate, OnGet, OnRelease);
    }

    private InGameMessage OnCreate()
    {
        InGameMessage message = Instantiate(messagePrefab);
        message.SetPool(pool);
        return message;
    }

    private void OnGet(InGameMessage message)
    {
        message.gameObject.SetActive(true);
    }

    private void OnRelease(InGameMessage message)
    {
        message.gameObject.SetActive(false);
    }
}
