using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ARITOMI
{
    /// <summary>
    /// 自機
    /// 有冨勇帆
    /// </summary>
	public class Player : SpaceShip
	{
        /// <summary>
        /// 初期化
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// ショット
        /// </summary>
        protected override void ActShot()
        {
            // フラグの定義
            bool flag_isPushShotButton = // ショット用ボタンが押されたか？
                ssInputState == InputState.TOUCH_TOP ||
                ssInputState == InputState.TOUCH_RIGHT ||
                ssInputState == InputState.TOUCH_LEFT;

            // ショット用ボタンが押されていなければ何もしない
            if (!(flag_isPushShotButton))
                return;

            // チャージショットが打てるなら
            if (bCanChageShot)
            {
                // チャージショットを打つ
                machineGun.ShotChageBullet();

                // 行動した
                Acted();
                return;
            }

            // 各ボタンに対応した弾を撃つ
            switch (ssInputState)
            {
                // 通常弾
                case InputState.TOUCH_TOP:
                    machineGun.ShotNormalBullet();
                    break;
                // 右側の弾
                case InputState.TOUCH_RIGHT:
                    machineGun.ShotRightBullet();
                    break;
                // 左側の弾
                case InputState.TOUCH_LEFT:
                    machineGun.ShotLeftBullet();
                    break;
            }

            // 行動した
            Acted();
        }

        /// <summary>
        /// 特殊行動
        /// </summary>
        protected override void ActSpecial()
        {
            // 何もしない
        }

        /// <summary>
        /// 更新
        /// </summary>
        protected override void ShipUpdate()
        {
            // コントローラーの入力情報を登録する
            ssInputState = controller.GetInputState();
        }
	}
}
