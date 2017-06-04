using UnityEngine;
using System.Collections;

/// <summary>
/// 機銃
/// 有冨勇帆
/// </summary>
public class MachineGun : MonoBehaviour {
    public GameObject objNormalBullet;  //! 通常弾
    public GameObject objRightBullet;   //! 右曲弾
    public GameObject objLeftBullet;    //! 左曲弾
    public GameObject objChageBullet;   //! チャージ弾
    public Transform traNormalBullet;   //! 通常弾位置情報
    public Transform traRightBullet;    //! 右曲弾位置情報
    public Transform traLeftBullet;     //! 左曲弾位置情報

    /// <summary>
    /// 通常弾発射
    /// </summary>
    public void ShotNormalBullet() 
    {
        Instantiate(objNormalBullet,
            traNormalBullet.position,
            traNormalBullet.rotation); 
    }

    /// <summary>
    /// 右曲弾発射
    /// </summary>
    public void ShotRightBullet()
    {
        Instantiate(objRightBullet,
            traRightBullet.position,
            traLeftBullet.rotation);
    }

    /// <summary>
    /// 左曲弾発射
    /// </summary>
    public void ShotLeftBullet()
    {
        Instantiate(objLeftBullet,
            traLeftBullet.position,
            traLeftBullet.rotation);
    }

    /// <summary>
    /// チャージ弾発射
    /// </summary>
    public void ShotChageBullet()
    {
        Instantiate(objChageBullet,
            traNormalBullet.position,
            traNormalBullet.rotation);
    }
}
