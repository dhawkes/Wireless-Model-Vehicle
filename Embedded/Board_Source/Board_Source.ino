#include <Servo.h>
#include <ESP8266WiFi.h>
#include <WiFiUdp.h>

// WiFi settings
char * ssid = "Mechatronics";
char * pwd = "YayFunFun";

// UDP wifi settings
WiFiUDP server;
const unsigned int local_port = 2380;
const unsigned int go_port = 2390;
const unsigned int packet_size = 2;
const IPAddress myIP(192, 168, 1, 44);
const IPAddress gateway(192, 168, 1, 1);
const IPAddress subnet(255, 255, 255, 0);

// Data buffers
byte buffer[packet_size];
char go_buffer[3];

// Drive control variables
Servo steering;
int servo_pos;


void setup() {
  // Setup pins
  pinMode(LED_BUILTIN, OUTPUT);
  digitalWrite(LED_BUILTIN, LOW);
  pinMode(D1, OUTPUT);
  digitalWrite(D1, LOW);
  pinMode(D2, OUTPUT);
  digitalWrite(D2, LOW);
  pinMode(D3, INPUT);

  // Connect to other router if switch is clicked
  if(digitalRead(D3)) {
    ssid = "modlab1";
    pwd = "ESAP2017";
  }
  
  // Enable serial connection
  Serial.begin(115200);

  // Setup wifi
  WiFi.begin(ssid, pwd);
  WiFi.config(myIP, gateway, subnet);

  // Connect to the wifi
  while(WiFi.status() != WL_CONNECTED) {
    delay(500);
    Serial.print(".");
  }
  Serial.print("Connected to network ");
  Serial.println(ssid);

  // Wait for GO! command
  server.begin(go_port);
  Serial.print("Waiting for GO! command");
  int go = 0;
  while(!go) {
    if(server.parsePacket() == 3) {
      server.read(go_buffer, 3);
      go = (char)go_buffer[0] == 'G' &&
           (char)go_buffer[1] == 'O' && 
           (char)go_buffer[2] == '!';
    }
    Serial.print(".");
    delay(50);
  }
  Serial.println();

  // Start listening for controller commands
  server.begin(local_port);
  Serial.print("Running UDP server on port ");
  Serial.print(local_port);

  // Initalize the servo
  steering.attach(D2);
  servo_pos = steering.read();

  // Set the default controller positions
  buffer[0] = 100;
  buffer[1] = 100;
}

void loop() {
  if(handlePacket()) {
    // Set servo position
    // Limit servo to 80 degrees of rotation
    // Only update the servo position if a significan movement is detected
    int new_pos = 50 + ((80 * buffer[1]) / 200);              
    if(new_pos > servo_pos + 2 || new_pos < servo_pos - 2) { 
      steering.write(new_pos);
      servo_pos = new_pos;
    }

    // Set drive speed
    int drive = ((buffer[0] - 100) * 1023) / 100;
    if(drive > 900) {
      drive = 1023;
    } else if(drive < 100) {
      drive = 0;
    }
    analogWrite(D1, drive);
  }
}

// Puts packet data in the buffer
// Returns true if a packet was received
int handlePacket() {
  if(server.parsePacket() == packet_size) {
    server.read(buffer, packet_size);
    return 1;
  }
  return 0;
}

// Debug function used to print buffer contents
void printBuffer() {
  Serial.print("Received: (");
  Serial.print(buffer[1] - 100);
  Serial.print(", ");
  Serial.print(buffer[0] - 100);
  Serial.println(")");
}

