using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

public class MoveBody : MonoBehaviour
{
    public GameObject body;

    void Update()
    {
        transform.DOMove(body.transform.position, 0.15f);
        transform.DORotate(body.transform.rotation.eulerAngles, 0.15f);
    }


}
