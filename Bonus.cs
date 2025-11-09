using Unity.VisualScripting;
using UnityEngine;

public class Bonus : MonoBehaviour
{

    [SerializeField]
    float speed = 3;
    void Start()
    {
        
    }
    void Update()
    {
        this.transform.Translate(Vector3.down * speed * Time.deltaTime);
        if (transform.position.y < -5.8f)
        {
            Destroy(this.gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            // üçlü atış bonusunu aktifleştir
            PlayerSc player = collision.GetComponent<PlayerSc>();
            if(player != null)
            {
                player.TripleShootActive();
            }
            Destroy(this.gameObject);
        }
    }
}
