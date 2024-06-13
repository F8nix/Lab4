using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CheckpointGraph : MonoBehaviour
{
  public List<Checkpoint> nodes = new();
  public static CheckpointGraph Instance { get; private set; }
  private void Awake()
  {
    if (Instance != null && Instance != this)
    {
      Destroy(this);
    }
    else
    {
      Instance = this;
    }
  }

  private void Start()
  {
    for (int i = 0; i < nodes.Count; i++)
    {
      nodes[i].next = nodes[(i + 1) % nodes.Count];
      nodes[i].prev = nodes[(i - 1 + nodes.Count) % nodes.Count];
    }
  }



  private void OnDrawGizmosSelected()
  {
    foreach (var node in nodes)
    {

      if (node.next != null)
      {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(node.transform.position + Vector3.up, node.next.transform.position + Vector3.up);
      }

      Gizmos.color = Color.red;
      Gizmos.DrawSphere(node.transform.position + Vector3.up, 0.2f);
    }
  }

}
