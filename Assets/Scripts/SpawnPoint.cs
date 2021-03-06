using UnityEngine;
using System.Collections;

public class SpawnPoint : MonoBehaviour {
	
	// 宇宙ゴミ プレハブ
	public GameObject debri;
	// 宇宙ゴミ発生間隔
	public float interval = 1F;
	
	void Start () {
        // SpawnDebris() コルーチンを開始する。コルーチンとはフレームを跨いで処理を中断・再開させることが出来る仕組み。
        //コルーチンを呼び出すにはStartCoroutineを使うIEnumerator型を戻り値とした関数を定義することで、その関数をコルーチンとして扱うことが出来る。
        StartCoroutine("SpawnDebris");
	}

    /// ###############
    ///  宇宙ゴミ発生
    /// ###############
    //StartCoroutine("コルーチン名")、StartCoroutine(IEnumerator型の変数)
    IEnumerator SpawnDebris() {
        // 無限ループ(true)である限りブロック内の処理を実行し続ける
		while(true) {
            // 宇宙ゴミプレハブを SpawnPointオブジェクトの位置にインスタンス化する
            //Instantiate関数とは「オブジェクトを元」に「オブジェクトを生成する関数」
            //構文public static Object Instantiate(Object original, Vector3 position, Quaternion rotation);
            //debriはコピーするゲームオブジェクト、第2引数は座標、第3引数「Quaternion.identity」は回転させない
            Instantiate(debri, transform.position, Quaternion.identity);
            // interval 分だけ処理を停止する
            //yield return を挟むことで処理を一時中断し、次のフレームまで待機することが出来ます。
            yield return new WaitForSeconds(interval);
		}
	}
}
