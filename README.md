# BVE_ATSPISerial

BVEのATSプラグインでシリアル通信がしたい

@Tetsu_Otter様のテンプレートを活用してC#で作っています。感謝！

## アイデア
マイコンから呼び出してPIがリクエスト受け取りそれに応じてPIから出力回答すれば軽くなるかなー(←2021/3/21実装)


## 呼び出しキー

|内容|呼び出しキー|型|
|:-:|:-:|:-:|
|現在位置|aa|double|
|速度|ab|float|
|時刻|ac|int|
|bc圧|ad|float|
|mr圧|ae|float|
|er圧|af|float|
|bp圧|ag|float|
|sap圧|ah|float|
|電流|ai|float|
|ドア閉|aj|開=0,閉=1|

他は後々実装します
