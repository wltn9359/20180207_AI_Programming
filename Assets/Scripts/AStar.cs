using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStar
{

    public static PriorityQueue closedList, openList;
    private static float HeuristicEstimateCost(Node curNode, Node goalNode) //curNode는 현재의 Node goal Node는 목표 Node이며 , Node는 비교해주는 함수
    {
        Vector3 vecCost = curNode.position - goalNode.position; // 간격 거리를 curNode의 위치와 goalNode의 위치를 계산하여 위치값 확인
        return vecCost.magnitude; //계산한 위치값을 담으며 , magnitude는 Distance로 대체 할수있으며 float 값으로 변환한다
    }
   
    public static ArrayList FindPath(Node start, Node goal)
    {
        openList = new PriorityQueue();
        openList.Push(start);
        start.nodeTotalCost = 0;
        start.estimeatedCost = HeuristicEstimateCost(start, goal);

        closedList = new PriorityQueue();
        Node node = null;
        while (openList.Length != 0) //openList의 갯수가 0이될때까지 계속 반복
        {
            node = openList.First();
            if (node.position == goal.position)
            {
                return CalculatePath(node);
            }
            ArrayList neighbours = new ArrayList();

            GridManager.instance.GetNeighbours(node, neighbours);

            for (int i = 0; i < neighbours.Count; i++)
            {
                Node neighboursNode = (Node)neighbours[i];
                if (!closedList.Contains(neighboursNode)) //closedList의 값이 bool값이 아니라면
                {
                    float cost = HeuristicEstimateCost(node, neighboursNode);
                    float totalCost = node.nodeTotalCost + cost;
                    float neighbourNodeEstCost = HeuristicEstimateCost(neighboursNode, goal);

                    neighboursNode.nodeTotalCost = totalCost;
                    neighboursNode.parent = node;
                    neighboursNode.estimeatedCost = totalCost + neighbourNodeEstCost;

                    if (!openList.Contains(neighboursNode))
                    {
                        openList.Push(neighboursNode);
                    }
                }
            }
            closedList.Push(node); //결정된 리스트를 Push하고
            openList.Remove(node);//openList의 Node를 삭제한다
        }
        if (node.position != goal.position)
        {
            Debug.LogError("Goal Not Found");
            return null;
        }
        return CalculatePath(node);
    }

    private static ArrayList CalculatePath(Node node)
    {
        ArrayList list = new ArrayList();
        while (node != null)
        {
            list.Add(node);
            node = node.parent;
        }
        list.Reverse();
        return list;
    }

}
