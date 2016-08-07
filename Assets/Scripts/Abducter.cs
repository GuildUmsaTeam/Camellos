using UnityEngine;
using UnityEngine.UI;

using System;
using System.Collections;
using System.Collections.Generic;

public class Abducter : MonoBehaviour {
    private List<GameObject> _camels;
    public Text Quantity;
    public GameObject CamelPrototype;

    public List<GameObject> Camels {
        get {
            if (_camels == null) {
                _camels = new List<GameObject>();
            }

            return _camels;
        }
    }

    void Update () {
	if (Input.GetKeyDown(KeyCode.A)) {
            Refresh();
        }
    }

    public void Refresh () {
        int b = Balance();
        if (b < 0) {
            Abduct(-b);
        } else {
            Drop(b);
        }
    } 

    public void Abduct (int quantity) {
        for (int i=0; i<quantity; i++) {
            int removeIndex = UnityEngine.Random.Range(0,Camels.Count);
            Camels[removeIndex].GetComponent<Abducted>().GetAbducted();
            Camels.RemoveAt(removeIndex);
        }
    }

    public void Drop (int quantity) {
        for (int i=0; i<quantity; i++) {
            GameObject camel = Instantiate(CamelPrototype);
            camel.GetComponent<RandomMovement>().RandomizeTargetSpot();
            camel.transform.position = transform.position;
            camel.GetComponent<Abducted>().GetDropped();
        }
    }

    public int Balance () {
        int quantity = Int32.TryParse(Quantity.text, out quantity) ? quantity : 0;
        return quantity - Camels.Count;
    }
}
