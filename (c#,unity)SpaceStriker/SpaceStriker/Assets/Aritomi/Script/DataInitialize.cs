using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// データ初期化
/// 有冨勇帆
/// </summary>
public class DataInitialize : MonoBehaviour
{
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
    void Initialize()
    {
        PlayerPrefs.SetInt(DataKey.LIFE_CASE, 2);
        PlayerPrefs.SetInt(DataKey.STAGE_CASE, 0);
        PlayerPrefs.SetInt(DataKey.STAGE_1, 0);
        PlayerPrefs.SetInt(DataKey.STAGE_2, 0);
        PlayerPrefs.SetInt(DataKey.STAGE_3, 0);
        PlayerPrefs.SetInt(DataKey.STAGE_4, 0);
        PlayerPrefs.SetInt(DataKey.STAGE_5, 0);
        PlayerPrefs.SetInt(DataKey.STAGE_6, 0);
        PlayerPrefs.SetInt(DataKey.STAGE_7, 0);
        PlayerPrefs.SetInt(DataKey.STAGE_8, 0);
    }
}
