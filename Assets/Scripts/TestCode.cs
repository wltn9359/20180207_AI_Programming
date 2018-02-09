﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCode : MonoBehaviour {

    private Transform startPos, endPos;
    public Node startNode { get; set; }
    public Node goalNode { get; set; }

    public ArrayList pathArray;

    GameObject objStartCude, objEndCube;
    private float elapsedTime = 0;
    private float intervalTime = 1;
    
    
	void Start ()
    {

        objStartCude = GameObject.FindGameObjectWithTag("Start");
        objEndCube = GameObject.FindGameObjectWithTag("End");

        pathArray = new ArrayList();
        FindPath();
        
	}
	
   
	void Update ()
    {

        elapsedTime += Time.deltaTime;
        if(elapsedTime >= intervalTime)
        {
            elapsedTime = 0;
            FindPath();
        }

	}

    void FindPath()
    {

        startPos = objStartCude.transform;
        endPos = objEndCube.transform;

        startNode = new Node(GridManager.instance.GetGridCellCenter(GridManager.instance.GetGridIndex(startPos.position)));

        goalNode = new Node(GridManager.instance.GetGridCellCenter(GridManager.instance.GetGridIndex(endPos.position)));

        pathArray = AStar.FindPath(startNode, goalNode);
        
    }

    void OnDrawGizmos()
    {
        if(pathArray == null)
        {
            return;
        }

        if(pathArray.Count > 0)
        {
            int index = 1;
            foreach (Node node in pathArray)
            {

                if (index<pathArray.Count)
                {
                    Node nextNode = (Node)pathArray[index];
                    Debug.DrawLine(node.position, nextNode.position, Color.cyan);
                    index++;
                }
            }
        }
    }

}
