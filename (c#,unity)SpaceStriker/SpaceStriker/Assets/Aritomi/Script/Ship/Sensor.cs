using UnityEngine;
using System.Collections;

namespace ARITOMI
{
    /// <summary>
    /// AIコントロール用センサーコリダー
    /// </summary>
    public class Sensor : MonoBehaviour
    {
        // ぶつかった弾の情報
        private bool col_normalBullet = false;  //! 通常弾が当たったか？
        private bool col_rightBullet = false;   //! 右曲弾が当たったか？
        private bool col_leftBullet = false;    //! 左曲弾が当たったか？
        private bool flag_col =false;           //! センサーに何か当たったか？

        /// <summary>
        /// 判定更新
        /// </summary>
        /// <param name="_col_1"></param>
        /// <param name="_col_2"></param>
        /// <param name="_col_3"></param>
        private void ColUpdate(bool _col_1, bool _col_2, bool _col_3)
        {
            col_normalBullet = _col_1;
            col_rightBullet = _col_2;
            col_leftBullet = _col_3;

        }

        /// <summary>
        /// 衝突判定
        /// </summary>
        /// <param name="col"></param>
        void OnTriggerEnter(Collider col)
        {
            switch (col.tag)
            {
                case TagConstant.TAG_NORMAL_BULLET:
                    ColUpdate(true, false, false);
                    flag_col = true;
                    break;
                case TagConstant.TAG_RIGHT_BULLET:
                    ColUpdate(false, true, false);
                    flag_col = true;
                    break;
                case TagConstant.TAG_LEFT_BULLET:
                    ColUpdate(false, false, true);
                    flag_col = true;
                    break;
            }
        }

        /// <summary>
        /// ノーマルバレットが当たったかを取得する
        /// </summary>
        /// <returns></returns>
        public bool ColNormalBullet()
        {
            return col_normalBullet;
        }

        /// <summary>
        /// ライトバレットが当たったか取得する
        /// </summary>
        /// <returns></returns>
        public bool ColRightBullet()
        {
            return col_rightBullet;
        }

        /// <summary>
        /// レフトバレットが当たったか取得する
        /// </summary>
        /// <returns></returns>
        public bool ColLeftBullet()
        {
            return col_leftBullet;
        }

        /// <summary>
        /// センサーが何かに当たったかを取得する
        /// </summary>
        /// <returns></returns>
        public bool GetFlagCol()
        {
            return flag_col;
        }

        /// <summary>
        /// フラグ初期化
        /// </summary>
        public void ColInitialize()
        {
            ColUpdate(false, false, false);
            flag_col = false;
        }
    }
}
