using UnityEngine;

public class Bitten : MonoBehaviour
{
    public GameObject zombiePrefab;
    public Transform spawnPoint;

    private bool isTriggered;

    public void HumanToZombie()
    {
        if (!isTriggered)
        {
            isTriggered = true;
            GameObject zombie = Instantiate(zombiePrefab, spawnPoint.position, spawnPoint.rotation);
            zombie.GetComponent<Rigidbody2D>();
            Destroy(gameObject);
        }
    }
}