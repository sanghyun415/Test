using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestGame : MonoBehaviour {

    public List<GameObject> Clay;


    public Sprite[] Question_Image;
    private Image Question_renderer;
    public GameObject Question;

    public GameObject[] ClayPos;

    public Text Quesetion_Text;
    public string[] dialogue;

    public int CountNum = 0;
    int ClayNum = 0;


    public bool Playing;
    
    void Awake()
    {
        Playing = false;
            
        
        Question_renderer = Question.GetComponent<Image>();
        //QuestionText(CountNum);
    }
    // Use this for initialization
    void Start () {
        


    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.R))
        {
            CountNum = Random.RandomRange(0, 5);

            Question_renderer.sprite = Question_Image[CountNum];
            QuestionText(CountNum);

            
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ClayMove();
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            iTween.Stop();
            iTween.Resume();
            Debug.Log("adad");
        }
    }
    void ClayMove()
    {
        
        ClayNum = Random.RandomRange(0, 3);
        MoveParent(Clay[ClayNum], ClayPos[ClayNum]);
        if(ClayNum == 0)
        {
            iTween.MoveTo(ClayPos[0], iTween.Hash("path", iTweenPath.GetPath("PosMove1"), "time", 5.5f, "orienttopath", false, "easetype", iTween.EaseType.linear, "oncomplete", "TweenStop"));
        }
        else if (ClayNum == 1)
        {
            iTween.MoveTo(ClayPos[1], iTween.Hash("path", iTweenPath.GetPath("PosMove2"), "time", 5.5f, "orienttopath", false, "easetype", iTween.EaseType.linear, "oncomplete", "TweenStop"));
        }
        else
        {
            iTween.MoveTo(ClayPos[2], iTween.Hash("path", iTweenPath.GetPath("PosMove3"), "time", 5.5f, "orienttopath", false, "easetype", iTween.EaseType.linear, "oncomplete",  "TweenStop"));
        }        

    }

    public void TweenStop()
    {

        //iTween.Stop();


        Debug.Log("asdad");

    }
    public void init()
    {
        QuestionText(CountNum);
        iTween.Stop();
    }

    public void CalyTouch(int num)
    {
        if(num != CountNum)
        {
            Debug.Log("X");
        }
        else
        {
            Debug.Log("O");
        }
        
    }

    IEnumerator GameStart()
    {
        int a = 3;
        for(int i = 0; i < 3; ++i)
        {
            Debug.Log(a);
            a--;
        }        
        yield return new WaitForSeconds(1.0f);

        MoveParent(Clay[0], ClayPos[0]);
    }


    void QuestionText(int num)
    {
        dialogue = new string[10];
        dialogue[0] = " ";
        dialogue[1] = "ㄱ";
        dialogue[2] = "ㄴ";
        dialogue[3] = "ㄷ";
        dialogue[4] = "ㄹ";
        dialogue[5] = "ㅁ";
        dialogue[6] = "ㅂ";
        dialogue[7] = "ㅅ";
        dialogue[8] = "ㅇ";
        dialogue[9] = "ㅈ";

        Quesetion_Text.text = dialogue[num];

    }

    void MoveParent(GameObject childObj, GameObject ParentObj)
    {
        childObj.transform.parent = ParentObj.transform;
        childObj.transform.localPosition = new Vector3(0, 0, 0);
        //childObj.transform.localEulerAngles = new Vector3(0, 0, 0);
        //childObj.transform.localScale = new Vector3(1, 1f, 1f);
    }

}
