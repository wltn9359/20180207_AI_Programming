using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriorityQueue
{

    private ArrayList nodes = new ArrayList();

    public int Length
    {
        get
        {
            return this.nodes.Count;
        }
    }

    public bool Contains(object node)
    {
        return this.nodes.Contains(node); // 자기 자신을 반환한다
    }

    public Node First()
    {
        if(this.nodes.Count > 0) // nodes가 0보다 클 경우
        {
            return (Node)this.nodes[0]; // 노드의 1번째 배열을 반환한다
        }
        return null; //nodes가 0이라면 null로 return
    }
      
    public void Push(Node node)   
    {
        this.nodes.Add(node);
        this.nodes.Sort(); //nodes의 경우 ArrayList로 배열에 리스트 넣어 사용된다
    }
   
    public void Remove(Node node)
    {
        this.nodes.Remove(node);
        this.nodes.Sort(); // Sort의 경우 추가된 List를 정렬하고 삭제된 List를 정렬한다
    }
}
