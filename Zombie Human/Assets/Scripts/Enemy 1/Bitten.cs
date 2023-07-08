using UnityEngine;

public class Bitten : MonoBehaviour
{
    //public CircleCollider2D circleCollider;
    //public SpriteRenderer _currentSprite;
    //public Sprite _newSprite;

    private bool isTriggered;

    public void HumanToZombie()
    {
        if (!isTriggered)
        {
            isTriggered = true;
            Debug.Log("humans turned zombie");
            //_currentSprite.sprite = _newSprite;
            Destroy(gameObject);
        }
    }
}