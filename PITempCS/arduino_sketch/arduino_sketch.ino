char input[10];   // 文字列格納用
int i = 0;  // 文字数のカウンタ
String reads;
int speed = 0;
int am = 0;

#define INTERP(xi,xi1,yi,yi1,x) (yi + ((( yi1 - yi ) * ( x - xi )) / ( xi1 - xi )))

const int ar1[] = {
  0, 5, 10, 15, 20, 25, 30, 35, 40, 45, 50, 55, 60, 65, 70, 75, 80, 85, 90, 95, 100, 105, 110, 115, 120, 125, 130, 135, 140,
  0, 2, 4, 6, 9, 12, 15, 18, 21, 25, 28, 32, 35, 39, 42, 46, 49, 53, 56, 60, 63, 67, 70, 73, 76, 79, 82, 85, 89,
};

const int ar2[] = {
  0, 5, 10, 15, 20, 25, 30, 35, 40, 45, 50, 55, 60, 65, 70, 75, 80, 85, 90, 95, 100, 105, 110, 115, 120, 125, 130, 135, 140,
  0, 2, 4, 6, 9, 12, 15, 18, 21, 25, 28, 32, 35, 39, 42, 46, 49, 53, 56, 60, 63, 67, 70, 73, 76, 79, 82, 85, 89,
};

void setup() {
  pinMode(PB4, OUTPUT);
  pinMode(PB10, OUTPUT);
  Serial.begin(19200);
}

int interp1dim(const int x, const int*ar) {
  int q;
  if (x <= ar[0]) {
    return ar[29];
  } else if (x >= ar[29 - 1]) {
    return ar[29 * 2 - 1];
  }
  for (q = 1; q < 29; q++) {
    if (ar[q] >= x) break;
  }
  return INTERP(ar[q - 1], ar[q], ar[q + 29 - 1], ar[q + 29], x);
}

void loop() {

  //位置情報を要求
  Serial.print("aa\n");

  //速度計情報を要求
  Serial.print("ab\n");
  if (Serial.available()) {
    reads = Serial.readStringUntil('\n');
    //速度計情報を受信
    if (reads.substring(0, 2) == "ab") {
      reads = reads.substring(2);
      speed = reads.toInt();
      analogWrite(PB10, interp1dim(speed, ar1));
    }
  }

  //時刻情報を要求
  Serial.print("ac\n");

  //BC圧情報を要求
  Serial.print("ad\n");

  //MR圧情報を要求
  Serial.print("ae\n");

  //ER圧情報を要求
  Serial.print("af\n");

  //BP圧情報を要求
  Serial.print("ag\n");

  //SAP圧情報を要求
  Serial.print("ah\n");

  //電流計情報を要求
  Serial.print("ai\n");
  if (Serial.available()) {
    reads = Serial.readStringUntil('\n');
    //電流計情報を受信
    if (reads.substring(0, 2) == "ai") {
      reads = reads.substring(2);
      am = reads.toInt();
      analogWrite(PB4, interp1dim(am, ar1));
    }
  }


}

//ソースは第一閉塞進行様のホームページより改変
//http://sylph.lib.net/trainsim/buhin2_arduino.html
