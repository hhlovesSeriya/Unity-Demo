using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;
using UnityEngine;

//缺少对游戏状态的判断，通过不同的状态来进行不同的对话
//耦合性太高，有可能的话把耦合性解开，需要一个ReadFileManager

public class DiologeUI : MonoBehaviour
{
    
    [SerializeField]
    Text Word;
    int index = 0;
    //string[] Content;
    string[] strs;
   
    private void OnEnable()
    {
        index = 0;
        //Content = new string[3];
        //Content[0] = "111";
        //Content[1] = "222";
        //Content[2] = "333";

        strs = File.ReadAllLines("D:/周五英美文化.txt");//读取文件中的文字，注意UTF-8

        ////
        Word.text = strs[index];
        Debug.Log("OnEnable执行一次");
    }

    private void OnDisable()
    {
        index = 0;
        Word.text = strs[index];
        Game.ActionLock = !Game.ActionLock;
    }



    void Update()
    {
        if(Game.GameLock)
        {
            if (index >= strs.Length)
            {

                this.gameObject.SetActive(false);
                
            }
            if(index < strs.Length)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    index++;
                    Debug.Log(index);
                    if (index< strs.Length)
                    {
                        Word.text = strs[index];
                    }
                    



                }
            }
            
        }
        
    }
}
