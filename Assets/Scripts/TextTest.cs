using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextTest : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TMP_InputField input;
    [SerializeField] private TextMeshProUGUI textTest;
    [SerializeField] private GameObject content;
    [SerializeField] private UIPostCell postCell;
    [SerializeField] private Transform postContainer;
    [SerializeField] private List<PostInfo> postInfos = new List<PostInfo>();

    float yContent;
    private void Awake()
    {
        yContent = 1;
        textTest.text = DataPlayer.GetValue<string>("textTest");
        int childCount = content.transform.childCount;
    
        

        postInfos = ES3.Load("postInfos", new List<PostInfo>());
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
        postInfo.Content = "TEST" + Random.Range(0, 100);
        postInfos.Add(postInfo);

        ES3.Save("postInfos", postInfos);
    }


}

//[System.Serializable]
public class PostInfo
{
    public string Name;
    public int LikeNum;
    public string Content;
}