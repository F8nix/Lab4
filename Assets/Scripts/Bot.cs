using UnityEngine;

public class Bot : MonoBehaviour
{
  public CheckpointGraph graph;
  public float speed = 5f;
  public Checkpoint currentNode;
  bool isRunning = false;

  private int defaultNode = 0;
  private float minDistance = 0.1f;
  void Start()
  {

  }

  void Update()
  {
    //if were to add more things into update, kick this into function
    if (!isRunning) return;
    if (currentNode == null)
    {
      currentNode = graph.nodes[defaultNode];
    }
    transform.position = Vector3.MoveTowards(transform.position, currentNode.transform.position, speed * Time.deltaTime);
    if (Vector3.Distance(transform.position, currentNode.transform.position) < minDistance)
    {
      currentNode = currentNode.next;

      if (currentNode == null)
      {
        currentNode = graph.nodes[defaultNode];
      }
    }
  }

  public void StartRunning()
  {
    isRunning = true;
  }

  public void StopRunning()
  {
    isRunning = false;
  }
}