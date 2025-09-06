using UnityEngine;

public class ReturnToPool : MonoBehaviour
{
    public ObjectPool pool;

    void OnEnable()
    {
        // sau 2s tự tắt
        Invoke(nameof(Return), 2f);
    }

    void OnDisable()
    {
        CancelInvoke();
    }

    void Return()
    {
        gameObject.SetActive(false);
        pool.Return(gameObject);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        gameObject.SetActive(false);
        pool.Return(gameObject);
    }
}
