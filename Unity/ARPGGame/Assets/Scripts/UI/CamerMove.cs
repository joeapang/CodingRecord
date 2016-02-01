using UnityEngine;
using System.Collections;

public class CamerMove : MonoBehaviour
{

    public GameObject startPosition;
    public GameObject targetPosition;
    
    private float timer;
    // Use this for initialization
    void Start ( )
    {
        transform.position = startPosition.transform.position;
    }

    // Update is called once per frame
    void Update ( )
    {
        transform.position = Vector3.Lerp ( transform.position, targetPosition.transform.position, (timer+=Time.deltaTime)/50);

    }
}
