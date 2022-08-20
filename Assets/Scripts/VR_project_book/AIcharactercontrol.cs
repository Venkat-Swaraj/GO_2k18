using UnityEngine;
using UnityEngine.AI;

public class AIcharactercontrol : MonoBehaviour
{
    public Transform Target;

    private NavMeshAgent _navMeshAgent;
    // Start is called before the first frame update
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        _navMeshAgent.destination = Target.position;
    }
}
