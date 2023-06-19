using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public Light spotLight;
    [SerializeField] internal float viewDistance;
    internal float searchDelay;
    [SerializeField] [Range(0, 180)] internal float viewAngle;
    internal LayerMask obstructionMask;
    internal bool playerDetected = false;
    private Transform _player;

    public Transform Player
    {
        get { return _player; }
    }
    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Start()
    {
        viewAngle = spotLight.spotAngle;
        viewDistance= spotLight.range;
        StartCoroutine(SearchForTargets());
    }

    private IEnumerator SearchForTargets()
    {
        WaitForSeconds wait = new WaitForSeconds(searchDelay);
        while (gameObject.activeSelf)
        {
            yield return wait;
            if (InFieldOfView())
            {
                playerDetected = true;
            }
            else
            {
                playerDetected = false;
            }
        }
    }
    public bool InFieldOfView()
    {
       if(Vector3.Distance(transform.position, _player.position)<viewDistance)
        {
            Debug.DrawLine(transform.position, _player.position,Color.magenta);
            Vector3 dirToPlayer=(_player.position-transform.position).normalized;
            float angleBetweenEnemyAndPlayer=Vector3.Angle(transform.forward, dirToPlayer);
            if(angleBetweenEnemyAndPlayer<viewAngle/2)
            {
                if (!Physics.Linecast(transform.position, _player.position, obstructionMask))
                {
                    return true;
                }
            }
            
        }
       return false;
    }
    private void OnValidate()
    {
        if (spotLight != null && spotLight.type != LightType.Spot)
        {
            Debug.LogError("Field of View flashLight must be a Spot Light.");
            spotLight = null;
        }
        else if (spotLight != null)
        {
            spotLight.spotAngle = viewAngle;
            spotLight.range = viewDistance;
        }
    }

  
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Debug.DrawRay(transform.position,transform.forward*viewDistance);
    }
}
