using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AddBody : MonoBehaviour
{

    public GameObject bodyPrefab;

    public GameObject head;

    public GameObject tail;

    public List<GameObject> bodies = new List<GameObject>();

    void Start()
    {
        GameObject obj = Instantiate(bodyPrefab, transform.position, Quaternion.identity);
        obj.transform.SetParent(transform.parent);
        obj.transform.SetSiblingIndex(1);
        bodies.Add(obj);
        obj.GetComponent<MoveBody>().body = head;
        AddTail();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Food>() != null)
        {
            Destroy(collision.gameObject);
            GameObject obj = Instantiate(bodyPrefab, bodies[bodies.Count - 1].transform.position, Quaternion.identity);
            obj.transform.SetParent(transform.parent);
            obj.transform.SetSiblingIndex(bodies.Count + 1);
            bodies.Add(obj);
            GameManager.instance.score += 1;
            GameManager.instance.scoreText.text = "Score:" + GameManager.instance.score.ToString();
            GameManager.instance.hasFood = false;
            obj.GetComponent<MoveBody>().body = bodies[bodies.Count - 2];
            AddTail();
        }
    }

    void AddTail()
    {
        tail.GetComponent<MoveBody>().body = bodies[bodies.Count - 1];
    }
}
