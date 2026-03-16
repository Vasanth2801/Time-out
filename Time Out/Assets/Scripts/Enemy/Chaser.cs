using UnityEngine;

public class Chaser : MonoBehaviour
{
    [Header("Enemy Settings")]
    [SerializeField] private float speed = 5f;

    [Header("References")]
    [SerializeField] private Transform player;

    void Update()
    {
        transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
    }
}
