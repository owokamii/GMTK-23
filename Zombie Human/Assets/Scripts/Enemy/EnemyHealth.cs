using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    public GameObject zombiePrefab;
    public GameObject healthPrefab;

    public Transform spawnPoint;

    public UnityEvent _interactAction;
    public KeyCode _interactKey;
    
    private bool _inRange;

    [SerializeField]
    int points;

    void Update()
    {
        if (_inRange)
            if (Input.GetKeyDown(_interactKey))
            {
                ScoreManager.Instance.AddPoint(points);
                AudioManager.Instance.Play("Bite");
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
            DropItem();
            ScoreManager.Instance.AddPoint(points);
            AudioManager.Instance.Play("Bite");
            GameObject zombie = Instantiate(zombiePrefab, spawnPoint.position, spawnPoint.rotation);
            AudioManager.Instance.Play("ZombieGroan");
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

    private void DropItem()
    {
        int randNum = Random.Range(1, 6);
        Debug.Log(randNum);

        if (randNum > 3)
        {
            Instantiate(healthPrefab, spawnPoint.position, spawnPoint.rotation);
            return;
        }
        else
        {
            return;
        }
    }
}