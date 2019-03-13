# DXLibWrapper
C#版DXライブラリ( https://dxlib.xsrv.jp/ )をより使いやすくします。

# 機能
## 図形
基本的な図形の描画や処理ができます。
+ 当たり判定
+ 移動
+ 拡大縮小(一部)
+ 描画
+ 枠描画

### 例
DXライブラリのみ
```csharp
DX.DxLib_Init();

DX.POINTDATA rectPos;
(int w, int h) size = (50, 100);
rectPos.x = 0;
rectPos.y = 0;
rectPos.color = DX.GetColor(0, 128, 0);

while (DX.ProcessMessage() != -1)
{
    DX.ClearDrawScreen();

    DX.DrawBox(rectPos.x, rectPos.y, rectPos.x + size.w, rectPos.y + size.h, rectPos.color, 1);

    rectPos.x += 2;
    rectPos.y++;

    DX.ScreenFlip();
}

DX.DxLib_End();
```

DXLibWrapper使用
```csharp

DX.DxLib_Init();

var rect = new Rectangle(point: (0, 0), size: (50, 100));
            
while (DX.ProcessMessage() != -1)
{
    DX.ClearDrawScreen();

    rect.Draw(Color.Green);

    rect.MoveBy(x: 2, y: 1);
                
    DX.ScreenFlip();
}

DX.DxLib_End();
```

### 対応図形
  - 長方形
  - 円
  - 三角形
  - 線

## シーン遷移
描画部と処理部に分かれているシーンを使ってシーン遷移ができます。  
複数シーンを管理するマネージャクラスもあります。

# 実装予定
+ 文字描画・処理
+ キー入力
+ マウス入力
+ ウィンドウ操作
