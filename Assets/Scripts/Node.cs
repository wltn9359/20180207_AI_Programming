using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Node : IComparable
{

    public float nodeTotalCost;
    public float estimeatedCost;
    public bool bObstacle;
    public Node parent;
    public Vector3 position;

    public Node()
    {
        this.estimeatedCost = 0;
        this.nodeTotalCost = 1;
        this.bObstacle = false;
        this.parent = null;

    }

    public Node(Vector3 pos)
    {
        this.estimeatedCost = 0;
        this.nodeTotalCost = 1;
        this.bObstacle = false;
        this.parent = null;
        this.position = pos;
    }

    public void MarkAsObstacle()
    {
        this.bObstacle = true;
    }

    public int CompareTo(object obj)
    {
        Node node = (Node)obj;
        if(this.estimeatedCost<node.estimeatedCost)
        {
            return -1;
        }

        if (this.estimeatedCost > node.estimeatedCost) return 1;
        return 0;
    }

}
