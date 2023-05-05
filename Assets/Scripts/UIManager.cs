using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TMP_InputField inputAdd;
    [SerializeField] private TMP_InputField inputEdit;
    [SerializeField] private UIPostCell postCell;
    [SerializeField] private Transform postContainer;
    [SerializeField] private List<PostInfo> postInfos = new List<PostInfo>();
    [SerializeField] private GameObject EditUI;
    [SerializeField] private GameObject HomeUI;
    private UIPostCell postCellEdit;
    public static UIManager instance;
    int count;
    int id;
    public static User user;
    private void Awake()
    {
        instance = this;
        //if (user == null)
        //{
        //    // Nếu User chưa được khởi tạo, tạo mới User
        //    user = new User();
        //    user.id = 1; // Gán id cho User
        //    user.UserName = "username";
        //    user.Password = "password";

        //    // Tải danh sách các id bài Post của User từ cơ sở dữ liệu hoặc file
        //    //List<int> postIds = LoadPostIdsForUser(user.id);
        //    //if (postIds != null)
        //    //{
        //    //    user.listIdPost = postIds;
        //    //}
        //}
     
        postInfos = ES3.Load("postInfos", new List<PostInfo>());
        ES3.Save("postInfos", postInfos);

        
        if (postInfos != null)
        {
            for (int i = 0; i < postInfos.Count; i++)
            {
                UIPostCell uiPostCell = Instantiate(postCell, postContainer);
                uiPostCell.SetUpUI(postInfos[i]);
            }
        }
            
    }

    public void AddText()
    {

        PostInfo postInfo = new PostInfo();
        postInfo.Content = inputAdd.text;
        postInfo.id = count;
        
        postInfos.Add(postInfo);
        UIPostCell uiPostCell = Instantiate(postCell, postContainer);
        uiPostCell.SetUpUI(postInfo);

        ES3.Save("postInfos", postInfos);
        count++;
    }
    public void SetStateEditUI(bool state)
    {
        HomeUI.SetActive(state);
        EditUI.SetActive(!state);
    }
    public void SaveAfterEdit()
    {
        PostInfo postInfo = postInfos.FirstOrDefault(info => info.id == GetIDPostEdit());
        //print(GetIDPostEdit());
        //print(GetPostCellEdit().id);

        if (postInfos != null)
        {
            postInfo.Content = inputEdit.text;
            GetPostCellEdit().SetUpUI(postInfo);
            ES3.Save("postInfos", postInfos);
            SetStateEditUI(true);


        }
    }



    public List<PostInfo> GetPostInfo()
    {
        return postInfos;
    }
    public int GetIDPostEdit()
    {
        return this.id;
    }
    public void SetIDPostEdit(int value)
    {
        this.id = value;
    }
    public UIPostCell GetPostCellEdit()
    {
        return postCellEdit;
    }
    public void SetPostCellEdit(UIPostCell postcell)
    {
        postCellEdit = postcell;    
    }
    

}

//[System.Serializable]
public class PostInfo
{
    public int id;
    public int UserID;
    public string Name;
    public int LikeNum;
    public string Content;
}
public class User
{
    public int id;
    public string UserName;
    public string Password;
    public List<int> listIdPost;    
}