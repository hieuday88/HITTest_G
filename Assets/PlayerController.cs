using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;

    public float speed = 5f;
    bool isGrounded = true;

    public Transform gun;
    public Transform firePoint;

    public GameObject bulletPrefab;   // Prefab của viên đạn
    ObjectPool bulletPool = new ObjectPool();  // Pool riêng cho bullet

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            rb.AddForce(Vector2.up * 300f);

        rb.velocity = new Vector2(moveX * speed, rb.velocity.y);

        Shoot();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        isGrounded = true;
    }

    void OnCollisionExit2D(Collision2D other)
    {
        isGrounded = false;
    }

    void Shoot()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 shootDir = (mousePos - (Vector2)transform.position).normalized;

        // Flip player
        if (shootDir.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);
        else
            transform.localScale = new Vector3(1, 1, 1);

        gun.right = shootDir;

        // Lấy bullet từ pool thay vì Instantiate
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = bulletPool.Get(bulletPrefab);
            bullet.transform.position = firePoint.position;
            bullet.transform.rotation = gun.rotation;

            Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();
            rbBullet.velocity = Vector2.zero; // reset vận tốc
            rbBullet.AddForce(shootDir * 1000f);
        }
    }
}
