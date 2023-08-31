using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<IBonus>() != null)
        {
            IBonus bonus = collision.gameObject.GetComponent<IBonus>();
            if (bonus != null)
            {
                bonus.BonusEffect();
                collision.gameObject.SetActive(false);
            }
        }
    }
}
