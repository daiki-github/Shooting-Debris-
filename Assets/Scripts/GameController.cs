using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour{
    //開始時間
    public float time;
    //カウントを整数にする
    int seconds;
    //時間表示のテキスト
    private GameObject timeText;

    // Use this for initialization
    void Start(){

        // オブジェクトの取得
        GameObject image_object = GameObject.Find("Image");
        // コンポーネントの取得
        Image image_component = image_object.GetComponent<Image>();
        // オブジェクトの取得
        image_component.enabled = false;

    }

    // Update is called once per frame
    void Update(){
        //カウントダウンスタート
        time -= Time.deltaTime;
        if (time > 0){
            //小数点以下を切り落として整数化
            seconds = (int)time;
        }
        else{
            //0で時間を止める
            seconds = 0;
        }

        if (seconds <= 0) {
            // オブジェクトの取得
            GameObject image_object = GameObject.Find("Image");
            // コンポーネントの取得
            Image image_component = image_object.GetComponent<Image>();
            // 画面内の宇宙ゴミをすべて削除する
            DestroyAllDebris();
            image_component.enabled = true;
        }

        //シーン中のscoreTextオブジェクトを取得（追加）
        this.timeText = GameObject.Find("TimeText");
        //ScoreText獲得した点数を表示(追加)
        this.timeText.GetComponent<Text>().text = "Time: " + seconds;

    }
    //  シーン中のすべての宇宙ゴミを削除
    void DestroyAllDebris(){   //int型の配列debrisを用意
        GameObject[] debris = GameObject.FindGameObjectsWithTag("debri");
        //foreach文で配列の要素を１つ１つコンソールへと書き出す
        //現在存在するdebriを配列に入れ、debris[1]、[2]、、、とするそれをそれぞれdebriのなかに入れる
        foreach (GameObject debri in debris){
            Destroy(debri);

        }


    }
}