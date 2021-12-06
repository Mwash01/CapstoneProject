using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPanel : MonoBehaviour
{
    public void OnEnable() {
        transform.LeanMoveLocal(new Vector2(0, -30), 0.8f).setEaseOutQuad();
    }
}
