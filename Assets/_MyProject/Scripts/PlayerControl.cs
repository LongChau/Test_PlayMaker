using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] float _distance;
    [SerializeField] LayerMask _terrainMask;
    [SerializeField] GameObject _guidance;
    [SerializeField] NavMeshAgent _agent;
    [SerializeField] Animator _anim;
    [SerializeField] PlayMakerFSM _fsm;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction, Color.blue);
            RaycastHit hitInfo;
            var isHitTerrain = Physics.Raycast(ray, out hitInfo, _distance, _terrainMask);
            if (isHitTerrain)
            {
                Debug.Log($"Hit point: {hitInfo.point}");
                _guidance.transform.position = hitInfo.point;
                _agent.SetDestination(hitInfo.point);
            }
        }

        float animMoveSpeed = Mathf.Clamp01(_agent.velocity.magnitude);
        _anim.SetFloat("MoveSpeed", animMoveSpeed);
    }

    public void OnEnemyExit()
    {

    }

    public void OnEnemyEnter()
    {

    }
}
