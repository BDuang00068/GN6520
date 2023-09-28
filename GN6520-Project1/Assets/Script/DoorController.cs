using UnityEngine;
using UnityEngine.UI;

public class DoorController : MonoBehaviour
{
    public Animator doorAnimator;
    public Text interactionText;

    private bool isOpen = false;
    private bool isPlayerNearby = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isOpen)
        {
            isPlayerNearby = true;
            UpdateInteractionText();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            interactionText.text = "";
        }
    }

    private void Update()
    {
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E) && !isOpen)
        {
            PlayerMovement player = FindObjectOfType<PlayerMovement>();
            if (player.HasAllPieces())
            {
                doorAnimator.SetTrigger("PuzzleComplete");
                isOpen = true;
                interactionText.text = "";
            }
            else
            {
                StartCoroutine(DisplayMissingPiecesMessage());
            }
        }
    }

    private void UpdateInteractionText()
    {
        if (isPlayerNearby && !isOpen)
        {
            interactionText.color = Color.white;
            interactionText.text = "Press E to place the puzzle piece.";
        }
    }

    System.Collections.IEnumerator DisplayMissingPiecesMessage()
    {
        interactionText.color = Color.red;
        interactionText.text = "You Don't Have All The Puzzle Pieces!";
        yield return new WaitForSeconds(3f); // Display the message for 3 seconds
        UpdateInteractionText(); // Revert back to the original instruction or clear if the player is not nearby
    }
}
