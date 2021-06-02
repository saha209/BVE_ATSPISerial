char input[10];   // 文字列格納用
int i = 0;  // 文字数のカウンタ
String reads;
float speed = 0;
int am = 0;
int door = 0;


void setup() {
  pinMode(PA0, OUTPUT);
  pinMode(PB4, OUTPUT);
  pinMode(PB10, OUTPUT);
  Serial.begin(19200);
}

void loop() {

  //速度計情報を要求
  Serial.print("ab\n");
  if (Serial.available()) {
    reads = Serial.readStringUntil('\n');

    //速度計情報を受信
    if (reads.substring(0, 2) == "ab") {
      reads = reads.substring(2);
      speed = reads.toFloat();
      analogWrite(PB10, speed / 1.55);
    }
  }

  //電流計情報を要求
  Serial.print("ai\n");
  if (Serial.available()) {
    reads = Serial.readStringUntil('\n');

    //電流計情報を受信
    if (reads.substring(0, 2) == "ai") {
      reads = reads.substring(2);
      am = reads.toFloat();
      if (am <= 0) {
        am = am * -1;
      }
      analogWrite(PB4, am / 16);
    }
  }

  //ドア情報を要求
  Serial.print("aj\n");
  if (Serial.available()) {
    reads = Serial.readStringUntil('\n');

    //ドア情報を受信
    if (reads.substring(0, 2) == "aj") {
      reads = reads.substring(2);
      door = reads.toInt();
      if (door != 0) {
        digitalWrite(PA0, HIGH);
      } else {
        digitalWrite(PA0, LOW);
      }
    }
  }

}

//ソースは第一閉塞進行様のホームページより改変
//http://sylph.lib.net/trainsim/buhin2_arduino.html
