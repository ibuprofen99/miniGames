using UnityEngine;

public class TileTriggerHandler : MonoBehaviour
{
    [SerializeField] private bool breakableTile = false;

    // Method to set the tile as breakable
    public void SetBreakable(bool value)
    {
        breakableTile = value;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && breakableTile)
        {
            Debug.Log("Breakable tile hit by player: " + gameObject.name);
            Destroy(gameObject); // Destroy this tile
        }
    }
}

