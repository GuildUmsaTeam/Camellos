using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ZOrderController : MonoBehaviour {
    public List<GameObject> Components;
    public float Depth;
    public GameObject Background;

    void Start () {
        
    }
    
    void Update () {
        _Sort();
        _SetZOrder();
    }

    private void _Sort () {
        Components.Sort(delegate(GameObject a, GameObject b) {
                return (int) Mathf.Sign(b.GetComponent<ZOrder>().GetZOrderPosition().y -
                                        a.GetComponent<ZOrder>().GetZOrderPosition().y);
            });
    }

    private void _SetZOrder () {
        float step = Depth/Components.Count;

        for (int i=0; i<Components.Count; i++) {
            Components[i].transform.position =
                new Vector3(Components[i].transform.position.x,
                            Components[i].transform.position.y,
                            Background.transform.position.z - i * step);
        }
    }
}
