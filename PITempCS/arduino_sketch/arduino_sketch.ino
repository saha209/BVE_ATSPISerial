char input[5];   // 文字列格納用
int i = 0;  // 文字数のカウンタ
int speed;

#define INTERP(xi,xi1,yi,yi1,x) (yi + ((( yi1 - yi ) * ( x - xi )) / ( xi1 - xi )))

const int ar[]={
0,5,10,15,20,25,30,35,40,45,50,55,60,65,70,75,80,85,90,95,100,105,110,115,120,125,130,135,140,
0,2,4,6,9,12,15,18,21,25,28,32,35,39,42,46,49,53,56,60,63,67,70,73,76,79,82,85,89,
};


void setup() {
  pinMode(PB10, OUTPUT); // 10番ピンを出力に使用
  Serial.begin(19200);
}

int interp1dim(const int x,const int*ar){
    int q;
    if(x<=ar[0]){
      return ar[29];
    }else if(x>=ar[29-1]){
      return ar[29*2-1];
    }  
    for(q=1;q<29;q++){
      if(ar[q]>=x) break;
    }
    return INTERP(ar[q-1],ar[q],ar[q+29-1],ar[q+29],x);
}
void loop() {
  if (Serial.available()) {
    input[i] = Serial.read();

    if (input[0] == 'a') {
      if (input[i] == '\n') {
        if (input[1] == 'b' && i == 5) speed = (input[2] - 48) * 100 + (input[3] - 48) * 10 + (input[4] - 48);
        if (input[1] == 'b' && i == 4) speed = (input[2] - 48) * 10 + (input[3] - 48);
        if (input[1] == 'b' && i == 3) speed = (input[2] - 48);
       
        Serial.print(speed);
          analogWrite(PB10, interp1dim(speed,ar));
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

//2文字読めるようになりました
