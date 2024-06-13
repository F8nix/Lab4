using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshBot : MonoBehaviour
{
  public Transform followTarget;
  NavMeshAgent agent;

  private void Start()
  {
    agent = GetComponent<NavMeshAgent>();
    agent.SetDestination(followTarget.position);
  }
  void Update()
  {
    if (Vector3.Distance(transform.position, followTarget.position) > 0.5f)
    {
      agent.SetDestination(followTarget.position);
    }
  }
}
