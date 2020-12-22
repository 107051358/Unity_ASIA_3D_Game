using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NPC : MonoBehaviour
{
    [Header("NPC 資料")]
    public NPCData data;
    [Header("對話框")]
    public GameObject dialogue;
    [Header("對話內容")]
    public Text textContent;
    [Header("對話者名稱")]
    public Text textName;
    [Header("對話間隔")]
    public float interval = 0.2f;


    public bool playerInArea;

    public enum NPCState
    {
        FirstDialogue,Missioning,Finish 
    }

    public NPCState state = NPCState.FirstDialogue;

    /*協同程序
    private void Start()
    {
        StartCoroutine(Test());
    }

    private IEnumerator Test()
    {
        print("嗨~");
        yield return new WaitForSeconds(1.5f);
        print("嗨~我是一點五秒後");
        yield return new WaitForSeconds(2);
        print("嗨~又過去兩秒了");
    }
    */

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "小明")
        {
            playerInArea = true;
            StartCoroutine(Dialogue());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == "小明")
        {
            playerInArea = false;
            StopDialogue();
        }
    }
      
    private  void StopDialogue()
    {
        dialogue.SetActive(false);
        StopAllCoroutines();
    }

    private IEnumerator Dialogue()
    {
        //{
        //    for (int i = 0; i < 10; i++)
        //    {
        //        print("我是超難懂的迴圈:"+i)
        //    }
        //}

        dialogue.SetActive(true);

        textContent.text = "";

        textName.text = name;

        string dialogueString = data.dialogueB;

        switch (state)
        {
            case NPCState.FirstDialogue:
                dialogueString = data.dialogueA;
                break;
            case NPCState.Missioning:
                dialogueString = data.dialogueB;
                break;
            case NPCState.Finish:
                dialogueString = data.dialogueC;
                break;
          
        }

        for (int i = 0; i < dialogueString.Length; i++)
        {
            // print(data.dialogueA[i]);
            textContent.text += dialogueString[i] + "";
            yield return new WaitForSeconds(interval);
        }
    }
}
