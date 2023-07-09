using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    public GameObject zombiePrefab;
    public Transform spawnPoint;

    public UnityEvent _interactAction;
    public KeyCode _interactKey;
    
    private bool _inRange;

    void Update()
    {
        if (_inRange)
            if (Input.GetKeyDown(_interactKey))
            {
                FindObjectOfType<AudioManager>().Play("Bite");
                _interactAction.Invoke();
            }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            _inRange = true;
        }

        else if(collision.gameObject.CompareTag("Zombie"))
        {
            FindObjectOfType<AudioManager>().Play("Bite");
            GameObject zombie = Instantiate(zombiePrefab, spawnPoint.position, spawnPoint.rotation);
            FindObjectOfType<AudioManager>().Play("ZombieGroan");
            zombie.GetComponent<Rigidbody2D>();
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            _inRange = false;
        }
    }
}
