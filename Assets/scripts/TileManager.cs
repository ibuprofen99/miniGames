using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tileRows; // Rows of tiles assigned in the inspector

    private void Start()
    {
        // Iterate over each row
        foreach (GameObject row in tileRows)
        {
            int pick = Random.Range(0, 2); // Generate either 0 or 1

            // Decide which child to destroy based on the random pick
            GameObject childToDestroy;
            if (pick == 0)
            {
                childToDestroy = row.transform.GetChild(1).gameObject;
            }
            else
            {
                childToDestroy = row.transform.GetChild(0).gameObject;
            }

            // Tag the chosen child as breakable
            TileTriggerHandler handler = childToDestroy.AddComponent<TileTriggerHandler>();
            handler.SetBreakable(true);
        }
    }
}


