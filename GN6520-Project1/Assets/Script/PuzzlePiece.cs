using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            if (player)
            {
                player.CollectPuzzlePiece();
                Debug.Log("Destory");
                Destroy(gameObject);
            }
        }
    }
}
