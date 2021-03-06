using UnityEngine;using System.Collections;public class Debri : MonoBehaviour {	// 1秒あたりの回転角度	public float angle = 30F;	// 破壊時の得点	public int score = 10;	// 回転の中心左表	private Vector3 targetPos;		void Start () {		// シーン中のEarthオブジェクトへアクセスしてEarthオブジェクトのTransformコンポーネントへ アクセスする		Transform target = GameObject.Find("Earth").transform;		// Earthオブジェクトの位置情報を取得しておく		targetPos = target.position;		// 宇宙ゴミの正面の向きをEarthの方向に向ける		this.transform.LookAt(target);		// 宇宙ゴミを0から360の範囲でZ軸を中心に回転させておく		this.transform.Rotate(new Vector3(0, 0, Random.Range(0, 360)), Space.World);	}		void Update () {
        // Earthを中心に宇宙ゴミの現在の上方向に 毎秒angle分だけ回転する
        //つまり自分にとっての） Y 軸 = Vector3.up がワールドでいくつになるのか求める
        Vector3 axis = transform.TransformDirection(Vector3.up);        //地球の位置を中心に90どづつ回っていく		transform.RotateAround(targetPos, axis, angle * Time.deltaTime);

    }

    void OnMouseDown(){
        // スコアを加算する。ゲームオブジェクト同士の処理の分担
        GameObject.Find("Score").SendMessage("AddScore", score);        // クリックされたら宇宙ゴミを消す
        Destroy(gameObject);	}}