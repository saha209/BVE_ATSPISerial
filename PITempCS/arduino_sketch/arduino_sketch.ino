char input[5];   // 文字列格納用
int i = 0;  // 文字数のカウンタ
int speed;

void setup() {
  pinMode(PB10, OUTPUT); // 10番ピンを出力に使用
  Serial.begin(19200);
}

void loop() {
  if (Serial.available()) {
    input[i] = Serial.read();

    if (input[0] == 'a') {
      if (input[i] == '\n') {
        if (i == 5) speed = (input[2] - 48) * 100 + (input[3] - 48) * 10 + (input[4] - 48);
        if (i == 4) speed = (input[2] - 48) * 10 + (input[3] - 48);
        if (i == 3) speed = (input[2] - 48);
        Serial.print(speed);
        analogWrite(PB10, speed);
        i = 0;
      }
      else {
        i++;
      }
    }
  }
}

//ソースは第一閉塞進行様のホームページより改変
//http://sylph.lib.net/trainsim/buhin2_arduino.html

//最初の1文字しか読んでくれない
//2-3文字読ませて判定に使いたい
