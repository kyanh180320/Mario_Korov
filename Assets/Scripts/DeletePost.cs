using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DeletePost : MonoBehaviour
{
    // Start is called before the first frame update
    //[SerializeField] private Transform postContainer;
    [SerializeField] private Button deleteButton;
    void Start()
    {
        Button btn = deleteButton.GetComponent<Button>();
        btn.onClick.AddListener(DeletePostCell);
    }

    [SerializeField] private UIPostCell postCell;
    
    void DeletePostCell()
    {
        // Tìm kiếm UIPostCell được chọn
        int idUIPostCell = postCell.id;

        if (postCell != null)
        {
            // Lấy thông tin PostInfo của UIPostCell được chọn
            PostInfo postInfo = UIManager.instance.GetPostInfo().FirstOrDefault(info => info.id == idUIPostCell);

            if (postInfo != null)
            {
                
                // Hủy UIPostCell và loại bỏ nó khỏi danh sách postInfos
                Destroy(postCell.gameObject);
                UIManager.instance.GetPostInfo().Remove(postInfo);

                // Lưu lại danh sách postInfos mới
                ES3.Save("postInfos", UIManager.instance.GetPostInfo());
            }
        }

    }
}
