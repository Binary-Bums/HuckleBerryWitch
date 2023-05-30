using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    [SerializeField] Transform[] Positions;
    [SerializeField] float ObjectSpeed;

    private int NextPosIndex;

    private Transform GetNextPos()
    {
        NextPosIndex++;
        if (NextPosIndex >= Positions.Length)
        {
            NextPosIndex = 0;
        }
        return Positions[NextPosIndex];
    }

    private void Start()
    {
        if (Positions.Length > 0)
        {
            transform.position = Positions[0].position;
        }
    }

    private void Update()
    {
        MoveGameObject();
    }

    private void MoveGameObject()
    {
        Transform nextPos = GetNextPos();

        if (transform.position == nextPos.position)
        {
            transform.position = nextPos.position;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, nextPos.position, ObjectSpeed * Time.deltaTime);
        }
    }
}