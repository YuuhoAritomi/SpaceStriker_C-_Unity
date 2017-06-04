using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// ステージセレクト管理者
/// 有冨勇帆
/// </summary>
public class StageSelectManager : MonoBehaviour
{
    [SerializeField]
    private GameObject player;          //! プレイヤー

    [SerializeField]
    private Text text;                  //! 勝利か負けか

    [SerializeField]
    private SelectStage stageSelect;    //! ステージ選択処理

    /// <summary>
    /// ステップ
    /// </summary>
    private enum Step
    {
        GAMESTART,      //! ゲーム開始
        GAMEPLAY,       //! ゲーム中
        GAMEOVER,       //! ゲームオーバー
    }

    private Step step;  //! ステップ

    //! ステージセレクト用敵機の位置をセット
    private Vector3 setPos(int _lCase, int _sCase)
    {
        Vector3 pos0 = new Vector3(    0f, 0f,  -4.74f);
        Vector3 pos1 = new Vector3(-1.25f, 0f,  -2.53f);
        Vector3 pos2 = new Vector3( 1.25f, 0f,  -2.53f);
        Vector3 pos3 = new Vector3( -2.5f, 0f, -0.098f);
        Vector3 pos4 = new Vector3(    0f, 0f, -0.091f);
        Vector3 pos5 = new Vector3(  2.5f, 0f, -0.106f);
        Vector3 pos6 = new Vector3(-1.25f, 0f,  2.277f);
        Vector3 pos7 = new Vector3( 1.25f, 0f,   2.21f);
        Vector3 pos8 = new Vector3(    0f, 0f,    4.3f);


        Vector3[][] vec3 = new Vector3[][]
        {
            new Vector3 [] { pos0, pos1, pos2, pos3, pos4, pos5, pos6, pos7, pos8 },
            new Vector3 [] { pos0, pos1, pos2, pos3, pos4, pos5, pos6, pos7, pos8 },
            new Vector3 [] { pos0, pos1, pos2, pos3, pos4, pos5, pos6, pos7, pos8 }
        };

        return vec3[_lCase][_sCase];
    }

    /// <summary>
    /// フラグ管理
    /// </summary>
    /// <param name="_lCase"></param>
    /// <param name="_sCase"></param>
    /// <returns></returns>
    private int flag(int _lCase, int _sCase)
    {
        int[][] i = new int[][]
        {
            new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 }, 
            new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 }, 
            new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }
        };

        return i[_lCase][_sCase];
    }
    
    [SerializeField]
    private float timeMax_start;    // タイマー最大値
    
    private float time_start;       // タイマー

    /// <summary>
    /// タイマーが最大時間を超えないようにする
    /// </summary>
    /// <param name="_time"></param>
    /// <param name="_maxTime"></param>
    /// <returns></returns>
    private int timeOver(float _time, float _maxTime) { return (_time >= _maxTime) ? 1 : 0; }

    /// <summary>
    /// 開始
    /// </summary>
    void Start()
    {
        Initialize();
    }

    /// <summary>
    /// 初期化
    /// </summary>
    private void Initialize()
    {
        AudioManager.Instance.PlayBGM(AudioName.BGMName[1]);
        text.gameObject.SetActive(false);
        step = Step.GAMESTART;
        time_start = 0;
        player.transform.position = setPos(PlayerPrefs.GetInt(DataKey.LIFE_CASE), PlayerPrefs.GetInt(DataKey.STAGE_CASE));
    }

    /// <summary>
    /// 更新
    /// </summary>
    void Update()
    {
        StepUpdate();
    }

    /// <summary>
    /// 各ステップごとに更新する
    /// </summary>
    private void StepUpdate()
    {
        switch (step)
        {
            case Step.GAMESTART:    // ゲームスタート
                GameStart();   
                return;
            case Step.GAMEPLAY:     // ゲームプレイ
                GamePlay();     
                return;
            case Step.GAMEOVER:     // ゲームオーバー
                GameOver();     
                return;
        }
        
        Debug.Log("ステップが初期化されてないよ");
    }

    /// <summary>
    /// ゲーム開始処理
    /// </summary>
    private void GameStart()
    {
        time_start += Time.deltaTime;

        if (PlayerPrefs.GetInt(DataKey.LIFE_CASE) == 1)     // 死亡しているならゲームオーバー
        {
            text.gameObject.SetActive(true);
            text.text = "GameOver";
            if (!(Input.GetMouseButtonDown(0))) return;
            step = Step.GAMEOVER;
            return;
        }

        if (timeOver(time_start, timeMax_start) == 0) return;

        stageSelect._sCase = flag(PlayerPrefs.GetInt(DataKey.LIFE_CASE),PlayerPrefs.GetInt(DataKey.STAGE_CASE));
        PlayerPrefs.SetInt(DataKey.STAGE_CASE, stageSelect._sCase);
        step = Step.GAMEPLAY;
    }

    /// <summary>
    /// ゲーム中の処理
    /// </summary>
    private void GamePlay()
    {
        if (PlayerPrefs.GetInt(DataKey.STAGE_CASE) == 9)    // 全ステージを攻略したらゲームクリア
        {
            text.gameObject.SetActive(true);
            text.text = "GameClear";
            if (!(Input.GetMouseButtonDown(0))) return;
            step = Step.GAMEOVER;
        }
    }

    /// <summary>
    /// ゲームオーバー処理
    /// </summary>
    private void GameOver()
    {
        Application.LoadLevel("title");
    }
}
