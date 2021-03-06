using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	//  スコア
	private int score;
    //スコアを表示するテキスト（追加）
    private GameObject scoreText;

    //  スコアを初期化する
    //InitScoreでは一つの処理しかしていないのでそこまでInitScoreの価値はない。
    //scoreを0で初期化するという決まりごとをInitScore()を常に使うことで覚えておかずに済むようになる。
    void InitScore() {
		this.score = 0;
	}

	//  スコアを加算する
	void AddScore(int score) {
		this.score += score;
      
        //シーン中のscoreTextオブジェクトを取得（追加）
        this.scoreText = GameObject.Find("ScoreText");
        //ScoreText獲得した点数を表示(追加)
        this.scoreText.GetComponent<Text>().text = "Score: " + this.score;
    }

    void Update () {
        //  Textを書き換える

    }
}