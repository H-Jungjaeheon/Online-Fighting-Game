using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class BtnTmpColorChange : MonoBehaviour
{
    private Color overColor = new Color(39,24,9);
    TextMeshProUGUI text;
    private void Start()
    {
        gameObject.AddComponent<BoxCollider2D>().isTrigger = true;
        text = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    private void OnMouseEnter()
    {
        text.color = overColor;
    }

    private void OnMouseExit()
    {
        text.color = Color.white;
    }
}
