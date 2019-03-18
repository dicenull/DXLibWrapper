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
static void Main(string[] args)
{
  DX.ChangeWindowMode(DX.TRUE);
  DX.SetDrawScreen(DX.DX_SCREEN_BACK);

  DX.DxLib_Init();

  while (DX.ProcessMessage() != -1)
  {
    DX.ClearDrawScreen();

    int x, y;
    DX.GetMousePoint(out x, out y);
    DX.DrawCircle(x, y, 10, DX.GetColor(0, 0, 255), DX.TRUE);
                
    DX.ScreenFlip();
  }

  DX.DxLib_End();
}
```

DXLibWrapper使用
```csharp
public void Run()
{
  while (DxSystem.Update())
  {
    new Circle(Input.Mouse.Point, 10).Draw(Palette.Blue);
  }
}
```

### 対応図形
  - 長方形
  - 円
  - 三角形
  - 線

## シーン遷移
描画部と処理部に分かれているシーンを使ってシーン遷移ができます。  
複数シーンを管理するマネージャクラスがあり、シーン間のデータ共有も可能です。

## 文字列描画
文字の描画ができます。  
色、フォント、大きさなどの指定ができます。

## キー、マウス入力
キーボードとマウスからの入力を受け取ることができます。  

## 画像描画
画像を読み込んで描画することができます。  
画像の回転、拡大縮小もできます。

## 音再生
音声ファイルを読み込み音の再生ができます。

## ウィンドウ
ウィンドウサイズやタイトルなどを調整することができます。

### 使用ライブラリライセンス
[ライセンス](/使用ライブラリライセンス.txt)
