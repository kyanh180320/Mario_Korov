using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditPost : MonoBehaviour
{
    // Start is called before the first frame update
    //[SerializeField] private Button editButton;
    [SerializeField] private UIPostCell postCell;
    

    void Start()
    {
        //Button btn = editButton.GetComponent<Button>();
        ////btn.onClick.AddListener(() => UIManager.instance.SetStateEditUI(false));
        //UIManager.instance.SetIDPostEdit(postCell.id);
        //UIManager.instance.SetPostCellEdit(postCell);
        //print(postCell.id);
        

    }
    public void EditButton()
    {
        UIManager.instance.SetStateEditUI(false);
        UIManager.instance.SetIDPostEdit(postCell.id);
        UIManager.instance.SetPostCellEdit(postCell);
        print(postCell.id);
    }



    // Update is called once per frame



}
