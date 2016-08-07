using UnityEngine;
using System.Collections;

public class RandomMovement : MonoBehaviour {
    public const int IDLE = 0;
    public const int GOING = 1;

    public bool RandomSpeed = false;
    public float MaxSpeed = 0.3f;
    public float MinSpeed = 1;
    public float Speed;

    public Vector2 MinSpot;
    public Vector2 MaxSpot;

    public float MinWaitingTime = 0.5f;
    public float MaxWaitingTime = 1;

    public Vector2 TargetSpot;

    private int _currentState;
    private CamelController _controller;

    void Start () {
        RandomizeTargetSpot();

        _currentState = GOING;
        _controller = GetComponent<CamelController>();
        if (RandomSpeed) {
            Speed = Random.Range(MaxSpeed, MinSpeed);
        }
    }

    void Update () {
        if (Vector2.Distance(transform.position, TargetSpot) < 0.1f) {
            if (_currentState != IDLE) {
                StartCoroutine("GetThere"); // must be executed only once!
            }
            _controller.IsWalking = false;
        } else {
            _controller.LookingLeft = TargetSpot.x - transform.position.x < 0;
            _controller.IsWalking = true;
            GoToTargetSpot();
        }
    }

    public void RandomizeTargetSpot () {        
        TargetSpot = new Vector2(Random.Range(MinSpot.x, MaxSpot.x),
                                 Random.Range(MinSpot.y, MaxSpot.y));
    }

    public void GoToTargetSpot () {
        transform.position = transform.position +
            (Vector3) (Speed * Time.deltaTime *
                       (TargetSpot - (Vector2) transform.position).normalized);
    }

    IEnumerator GetThere () {
        _currentState = IDLE;
        yield return new WaitForSeconds(Random.Range(MinWaitingTime, MaxWaitingTime));
        _currentState = GOING;
        RandomizeTargetSpot();
    }
}
