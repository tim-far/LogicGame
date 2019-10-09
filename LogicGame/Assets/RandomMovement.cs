using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    public float maxX;
    public float minX;
    public float maxY;
    public float minY;

    public float speed;

    private Vector2 targetPosition;

    Vector2 getRandomPosition()
    {
        float targetX = Random.Range(minX, maxY);
        float targetY = Random.Range(minY, maxY);
        return new Vector2(targetX, targetY);
    }

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = getRandomPosition();
    }

    // Update is called once per frame
    void Update()
    {
        if((Vector2)transform.position != targetPosition)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed);
        }
        else
        {
            targetPosition = getRandomPosition();
        }
    }
}
