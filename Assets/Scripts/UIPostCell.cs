using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIPostCell : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _tmpContent;
    public int id { get; set; } 
    public void SetUpUI(PostInfo postInfo)
    {
        _tmpContent.text = postInfo.Content;
        id = postInfo.id;
    }
}
