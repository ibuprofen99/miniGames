using UnityEngine;
using System.Collections.Generic;
using System;

public class ObstacleSpawner : MonoBehaviour
{
    private List<GameObject> floorObstacles = new List<GameObject>();
    private List<GameObject> ceilingObstacles = new List<GameObject>();

    public Transform characterTransform; // Reference to the character's transform
    public float obstacleActivationRange = 7f; // Range within which obstacles are activated or deactivated

    private void Start()
    {
        FindObstaclesWithTag("Floors", floorObstacles);
        FindObstaclesWithTag("Ceiling", ceilingObstacles);

        // Sort the obstacles by their 'y' positions
        SortObstaclesByYPosition(floorObstacles);
        SortObstaclesByYPosition(ceilingObstacles);

        // Debug print the sorted lists
        //Debug.Log("Sorted Floor Obstacles:");
        //PrintObstaclesPositions(floorObstacles);
        //Debug.Log("Sorted Ceiling Obstacles:");
        //PrintObstaclesPositions(ceilingObstacles);

        SpawnObstacles();
    }

    private void FindObstaclesWithTag(string tag, List<GameObject> obstacleList)
    {
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject obstacle in obstacles)
        {
            obstacleList.Add(obstacle);
        }
    }

    private void SortObstaclesByYPosition(List<GameObject> obstacles)
    {
        // Sort obstacles by their 'y' positions using Array.Sort
        obstacles.Sort((a, b) => a.transform.position.y.CompareTo(b.transform.position.y));
    }

    private void PrintObstaclesPositions(List<GameObject> obstacles)
    {
        foreach (var obstacle in obstacles)
        {
            //Debug.Log(obstacle.name + " position: " + obstacle.transform.position);
        }
    }

    public void SpawnObstacles()
    {
        for (int i = 0; i < Mathf.Min(floorObstacles.Count, ceilingObstacles.Count); i++)
        {
            int randomInt = UnityEngine.Random.Range(0, 100); // Random integer between 0 and 99
            //Debug.Log(randomInt);

            if (randomInt < 39)
            {
                EnableFloorObstacle(i);
            }
            else if (randomInt < 79)
            {
                EnableCeilingObstacle(i);
            }
            else
            {
                DisableObstacles(i);
            }
        }
    }

    private void EnableFloorObstacle(int index)
    {
        if (index >= 0 && index < floorObstacles.Count)
        {
            if (!IsWithinActivationRange(floorObstacles[index].transform.position.y))
            {
                floorObstacles[index].SetActive(true);
            }
            //Debug.Log("Floor obstacle enabled at position: " + floorObstacles[index].transform.localPosition);

            // Ensure that the corresponding ceiling obstacle is disabled
            if (index < ceilingObstacles.Count)
            {
                ceilingObstacles[index].SetActive(false);
                //Debug.Log("Ceiling obstacle disabled at position: " + ceilingObstacles[index].transform.localPosition);
            }
        }
    }

    private void EnableCeilingObstacle(int index)
    {
        if (index >= 0 && index < ceilingObstacles.Count)
        {
            if (!IsWithinActivationRange(ceilingObstacles[index].transform.position.y))
            {
                ceilingObstacles[index].SetActive(true);
            }
            //Debug.Log("Ceiling obstacle enabled at position: " + ceilingObstacles[index].transform.localPosition);

            // Ensure that the corresponding floor obstacle is disabled
            if (index < floorObstacles.Count)
            {
                floorObstacles[index].SetActive(false);
                //Debug.Log("Floor obstacle disabled at position: " + floorObstacles[index].transform.localPosition);
            }
        }
    }

    private void DisableObstacles(int index)
    {
        if (index >= 0 && index < floorObstacles.Count && index < ceilingObstacles.Count)
        {
            if (index < floorObstacles.Count)
            {
                floorObstacles[index].SetActive(false);
                //Debug.Log("Floor obstacle disabled at position: " + floorObstacles[index].transform.localPosition);
            }

            if (index < ceilingObstacles.Count)
            {
                ceilingObstacles[index].SetActive(false);
                //Debug.Log("Ceiling obstacle disabled at position: " + ceilingObstacles[index].transform.localPosition);
            }
        }
        else
        {
            //Debug.LogWarning("Invalid index for disabling obstacles: " + index);
        }
    }

    public void DisableAllObstacles()
    {
        foreach (GameObject floorObstacle in floorObstacles)
        {
            if (IsWithinActivationRange(floorObstacle.transform.position.y))
            {
                floorObstacle.SetActive(false);
            }
        }

        foreach (GameObject ceilingObstacle in ceilingObstacles)
        {
            if (IsWithinActivationRange(ceilingObstacle.transform.position.y))
            {
                ceilingObstacle.SetActive(false);
            }
        }
    }

    private bool IsWithinActivationRange(float positionY)
    {
        if (characterTransform != null)
        {
            float characterPosY = characterTransform.position.y;
            return Mathf.Abs(positionY - characterPosY) <= obstacleActivationRange;
        }
        return false;
    }
}
