#include <Arduino.h>
#include <WiFi.h>
#include <PubSubClient.h>
#include <WiFiClientSecure.h>
#include <ESPAsyncWebServer.h>
#include "SPIFFS.h"
#include <Preferences.h>
#include <IRremoteESP8266.h>
#include <IRrecv.h>
#include <IRsend.h>
#include <IRutils.h>
#include <DHT.h>
#include <DHT_U.h>
#include <ArduinoOTA.h>


#define DO_PIN_1 21
#define DO_PIN_2 17
#define DO_PIN_3 15
#define DO_PIN_4 18
#define DHTPIN 32     // Define the pin connected to the DHT sensor
#define DHTTYPE DHT11 // Define the type of DHT sensor (DHT11, DHT21, or DHT22)
#define LED_Yellow 0
#define LED_Blue 16
#define Reset_Btn 19
#define IR_RECEIVE_PIN 4
#define kIrLed 5
#define MQ4_PIN 33
#define Ir_reset 34


const int MAX_RAW_LEN = 100; // Adjust the size as needed
uint16_t rawData[MAX_RAW_LEN];
int rawDataLen = 0;





WiFiClientSecure espClient;
PubSubClient client(espClient);
// Create AsyncWebServer object on port 80
AsyncWebServer server(80);
DHT dht(DHTPIN, DHTTYPE);
TaskHandle_t Task1;
TaskHandle_t Task2;
void Task1code(void *);
void Task2code(void *);


// Search for parameter in HTTP POST request
const char* PARAM_INPUT_1 = "ssid";
const char* PARAM_INPUT_2 = "pass";
const char* PARAM_INPUT_3 = "mqtt_server";
const char* PARAM_INPUT_4 = "mqtt_port";
const char* PARAM_INPUT_5 = "mqtt_usernam";
const char* PARAM_INPUT_6 = "mqtt_password";

static const char *root_ca PROGMEM = R"EOF(
-----BEGIN CERTIFICATE-----
MIIFazCCA1OgAwIBAgIRAIIQz7DSQONZRGPgu2OCiwAwDQYJKoZIhvcNAQELBQAw
TzELMAkGA1UEBhMCVVMxKTAnBgNVBAoTIEludGVybmV0IFNlY3VyaXR5IFJlc2Vh
cmNoIEdyb3VwMRUwEwYDVQQDEwxJU1JHIFJvb3QgWDEwHhcNMTUwNjA0MTEwNDM4
WhcNMzUwNjA0MTEwNDM4WjBPMQswCQYDVQQGEwJVUzEpMCcGA1UEChMgSW50ZXJu
ZXQgU2VjdXJpdHkgUmVzZWFyY2ggR3JvdXAxFTATBgNVBAMTDElTUkcgUm9vdCBY
MTCCAiIwDQYJKoZIhvcNAQEBBQADggIPADCCAgoCggIBAK3oJHP0FDfzm54rVygc
h77ct984kIxuPOZXoHj3dcKi/vVqbvYATyjb3miGbESTtrFj/RQSa78f0uoxmyF+
0TM8ukj13Xnfs7j/EvEhmkvBioZxaUpmZmyPfjxwv60pIgbz5MDmgK7iS4+3mX6U
A5/TR5d8mUgjU+g4rk8Kb4Mu0UlXjIB0ttov0DiNewNwIRt18jA8+o+u3dpjq+sW
T8KOEUt+zwvo/7V3LvSye0rgTBIlDHCNAymg4VMk7BPZ7hm/ELNKjD+Jo2FR3qyH
B5T0Y3HsLuJvW5iB4YlcNHlsdu87kGJ55tukmi8mxdAQ4Q7e2RCOFvu396j3x+UC
B5iPNgiV5+I3lg02dZ77DnKxHZu8A/lJBdiB3QW0KtZB6awBdpUKD9jf1b0SHzUv
KBds0pjBqAlkd25HN7rOrFleaJ1/ctaJxQZBKT5ZPt0m9STJEadao0xAH0ahmbWn
OlFuhjuefXKnEgV4We0+UXgVCwOPjdAvBbI+e0ocS3MFEvzG6uBQE3xDk3SzynTn
jh8BCNAw1FtxNrQHusEwMFxIt4I7mKZ9YIqioymCzLq9gwQbooMDQaHWBfEbwrbw
qHyGO0aoSCqI3Haadr8faqU9GY/rOPNk3sgrDQoo//fb4hVC1CLQJ13hef4Y53CI
rU7m2Ys6xt0nUW7/vGT1M0NPAgMBAAGjQjBAMA4GA1UdDwEB/wQEAwIBBjAPBgNV
HRMBAf8EBTADAQH/MB0GA1UdDgQWBBR5tFnme7bl5AFzgAiIyBpY9umbbjANBgkq
hkiG9w0BAQsFAAOCAgEAVR9YqbyyqFDQDLHYGmkgJykIrGF1XIpu+ILlaS/V9lZL
ubhzEFnTIZd+50xx+7LSYK05qAvqFyFWhfFQDlnrzuBZ6brJFe+GnY+EgPbk6ZGQ
3BebYhtF8GaV0nxvwuo77x/Py9auJ/GpsMiu/X1+mvoiBOv/2X/qkSsisRcOj/KK
NFtY2PwByVS5uCbMiogziUwthDyC3+6WVwW6LLv3xLfHTjuCvjHIInNzktHCgKQ5
ORAzI4JMPJ+GslWYHb4phowim57iaztXOoJwTdwJx4nLCgdNbOhdjsnvzqvHu7Ur
TkXWStAmzOVyyghqpZXjFaH3pO3JLF+l+/+sKAIuvtd7u+Nxe5AW0wdeRlN8NwdC
jNPElpzVmbUq4JUagEiuTDkHzsxHpFKVK7q4+63SM1N95R1NbdWhscdCb+ZAJzVc
oyi3B43njTOQ5yOf+1CceWxG1bQVs5ZufpsMljq4Ui0/1lvh+wjChP4kqKOJ2qxq
4RgqsahDYVvTH9w7jXbyLeiNdd8XM2w9U/t7y0Ff/9yi0GE44Za4rF2LN9d11TPA
mRGunUHBcnWEvgJBQl9nJEiU0Zsnvgc/ubhPgXRR4Xq37Z0j4r7g1SgEEzwxA57d
emyPxgcYxn/eR44/KJ4EBs+lVDR3veyJm+kXQ99b21/+jh5Xos1AnX5iItreGCc=
-----END CERTIFICATE-----
)EOF";

void reconnect();
void callback(char*, byte*,unsigned int);
void parseRawData(const String& );


String ssid, pass,mqtt_port,mqtt_server,mqtt_username,mqtt_password;
bool wifi_connected;


// Timer variables
unsigned long previousMillis = 0;
const long interval = 10000;  // interval to wait for Wi-Fi connection (milliseconds)

unsigned long previousMQ4Millis = 0;  // last time MQ-4 was read
const long mq4Interval = 5000;       // interval to read MQ-4 sensor (milliseconds)

unsigned long previousDHTMillis = 0;
const long dhtInterval = 2000;

Preferences preferences; // steore credentials in memory
IRrecv irrecv(IR_RECEIVE_PIN);
IRsend irsend(kIrLed);  
decode_results results;
bool run_once=true;


void IRAM_ATTR isr() {
  
            preferences.putString("SSID","");
          
            preferences.putString("Pass","");
           preferences.putString("MQTT_server","");

           preferences.putString("MQTT_Port","");
          
           preferences.putString("MQTT_uname","");
         
           preferences.putString("MQTT_pass","");
           
           Serial.println("reseting");
           delay(500);
           ESP.restart();
         
}

void IRAM_ATTR handleButtonPress() {
  // Read the button state and store it
  preferences.putBool("IR_once flag",true);
  Serial.print("pushed");
}

// Initialize SPIFFS
void initSPIFFS() {
  if (!SPIFFS.begin(true)) {
    Serial.println("An error has occurred while mounting SPIFFS");
  }
  Serial.println("SPIFFS mounted successfully");
}

// Read File from SPIFFS
String readFile(fs::FS &fs, const char * path){
  Serial.printf("Reading file: %s\r\n", path);

  File file = fs.open(path);
  if(!file || file.isDirectory()){
    Serial.println("- failed to open file for reading");
    return String();
  }
  
  String fileContent;
  while(file.available()){
    fileContent = file.readStringUntil('\n');
    break;     
  }
  return fileContent;
}

// Write file to SPIFFS
void writeFile(fs::FS &fs, const char * path, const char * message){
  Serial.printf("Writing file: %s\r\n", path);

  File file = fs.open(path, FILE_WRITE);
  if(!file){
    Serial.println("- failed to open file for writing");
    return;
  }
  if(file.print(message)){
    Serial.println("- file written");
  } else {
    Serial.println("- write failed");
  }
}

// Initialize WiFi
bool initWiFi() {
  if(ssid=="" ){
    Serial.println("Undefined SSID");
    return false;
  }

  
  Serial.println("Connecting to WiFi...");
    WiFi.mode(WIFI_STA);
    WiFi.begin(ssid,pass);
    Serial.println("");
   

  unsigned long currentMillis = millis();
  previousMillis = currentMillis;

  while(WiFi.status() != WL_CONNECTED) {
    currentMillis = millis();
    if (currentMillis - previousMillis >= interval) {
      
      return false;
    }
  }

    pinMode(DO_PIN_1,OUTPUT);
   pinMode(DO_PIN_2,OUTPUT);
   pinMode(DO_PIN_3,OUTPUT);
   pinMode(DO_PIN_4,OUTPUT);
  return true;
}


void setup() {
  // Serial port for debugging purposes
  //Serial.begin(115200);
  initSPIFFS();
   preferences.begin("Setup", false);
   pinMode(LED_Blue,OUTPUT);
   pinMode(LED_Yellow,OUTPUT);
   pinMode(Reset_Btn, INPUT_PULLUP);
   pinMode(Ir_reset, INPUT_PULLUP);
   attachInterrupt(digitalPinToInterrupt(Reset_Btn), isr, FALLING);
   attachInterrupt(digitalPinToInterrupt(Ir_reset), handleButtonPress, FALLING);

   dht.begin();

  // Load values saved in SPIFFS
  ssid = preferences.getString("SSID",""); //readFile(SPIFFS, ssidPath);
  pass = preferences.getString("Pass","") ;//readFile(SPIFFS, passPath);
  mqtt_server =preferences.getString("MQTT_server","");// readFile(SPIFFS, ipPath);
  mqtt_port=preferences.getString("MQTT_Port","").toInt();
  mqtt_username =preferences.getString("MQTT_uname","");// readFile (SPIFFS, gatewayPath);
  mqtt_password=preferences.getString("MQTT_pass","");
  
  

  if(initWiFi()) {
    // Route for root / web page
    espClient.setCACert(root_ca);
   client.setServer(mqtt_server.c_str(),mqtt_port.toInt());
   client.setCallback(callback);
   wifi_connected=true;  
    irsend.begin();
   irrecv.enableIRIn();   
   ArduinoOTA.onStart([]() {
        String type;
        if (ArduinoOTA.getCommand() == U_FLASH) {
            type = "sketch";
        } else { // U_SPIFFS
            type = "filesystem";
        }
        // NOTE: if updating SPIFFS this would be the place to unmount SPIFFS using SPIFFS.end()
        Serial.println("Start updating " + type);
    });
    ArduinoOTA.onEnd([]() {
        Serial.println("\nEnd");
    });
    ArduinoOTA.onProgress([](unsigned int progress, unsigned int total) {
        Serial.printf("Progress: %u%%\r", (progress / (total / 100)));
    });
    ArduinoOTA.onError([](ota_error_t error) {
        Serial.printf("Error[%u]: ", error);
        if (error == OTA_AUTH_ERROR) {
            Serial.println("Auth Failed");
        } else if (error == OTA_BEGIN_ERROR) {
            Serial.println("Begin Failed");
        } else if (error == OTA_CONNECT_ERROR) {
            Serial.println("Connect Failed");
        } else if (error == OTA_RECEIVE_ERROR) {
            Serial.println("Receive Failed");
        } else if (error == OTA_END_ERROR) {
            Serial.println("End Failed");
        }
    });
    ArduinoOTA.begin();
  }
  else {
    wifi_connected=false;
    // Connect to Wi-Fi network with SSID and password
    Serial.println("Setting AP (Access Point)");
    // NULL sets an open Access Point
    WiFi.softAP("ESP-WIFI-MANAGER", NULL);

    IPAddress IP = WiFi.softAPIP();
    Serial.print("AP IP address: ");
    Serial.println(IP); 

    // Web Server Root URL
    server.on("/", HTTP_GET, [](AsyncWebServerRequest *request){
      request->send(SPIFFS, "/wifimanager.html", "text/html");
    });
    
    server.serveStatic("/", SPIFFS, "/");
    
    server.on("/", HTTP_POST, [](AsyncWebServerRequest *request) {
      int params = request->params();
      for(int i=0;i<params;i++){
        AsyncWebParameter* p = request->getParam(i);
        if(p->isPost()){
          // HTTP POST ssid value
          if (p->name() == PARAM_INPUT_1) {
            ssid = p->value().c_str();
            Serial.print("SSID set to: ");
            Serial.println(ssid);
            // Write file to save value
            //writeFile(SPIFFS, ssidPath, ssid.c_str());
            preferences.putString("SSID",ssid.c_str());
            preferences.putBool("IR_once flag",true);
          }
          // HTTP POST pass value
          if (p->name() == PARAM_INPUT_2) {
            pass = p->value().c_str();
            Serial.print("Password set to: ");
            Serial.println(pass);
            // Write file to save value
            //writeFile(SPIFFS, passPath, pass.c_str());
            preferences.putString("Pass",pass.c_str());

          }
          // HTTP POST ip value
          if (p->name() == PARAM_INPUT_3) {
            mqtt_server = p->value().c_str();
            Serial.print("Server set to: ");
            Serial.println(mqtt_server);
            // Write file to save value
           // writeFile(SPIFFS, ipPath, ip.c_str());
           preferences.putString("MQTT_server",mqtt_server.c_str());

          }
          // HTTP POST gateway value
          if (p->name() == PARAM_INPUT_4) {
            mqtt_port = p->value().c_str();
            Serial.print("MQTT_Port set to: ");
            Serial.println(mqtt_port);
            // Write file to save value
           // writeFile(SPIFFS, gatewayPath, gateway.c_str()); 
           preferences.putString("MQTT_Port",mqtt_port.c_str());
          }

          if (p->name() == PARAM_INPUT_5) {
            mqtt_username = p->value().c_str();
            Serial.print("MQTT_uname set to: ");
            Serial.println(mqtt_username);
            // Write file to save value
           // writeFile(SPIFFS, gatewayPath, gateway.c_str()); 
           preferences.putString("MQTT_uname",mqtt_username.c_str());
          }
           if (p->name() == PARAM_INPUT_6) {
            mqtt_password = p->value().c_str();
            Serial.print("Gateway set to: ");
            Serial.println(mqtt_password);
            // Write file to save value
           // writeFile(SPIFFS, gatewayPath, gateway.c_str()); 
           preferences.putString("MQTT_pass",mqtt_password.c_str());
          }
          //Serial.printf("POST[%s]: %s\n", p->name().c_str(), p->value().c_str());
        }
      }
      request->send(200, "text/plain", "Done. ESP will restart");
      delay(3000);
      ESP.restart();
    });
    server.begin();
  }

xTaskCreatePinnedToCore(
                    Task1code,   /* Task function. */
                    "Task1",     /* name of task. */
                    10000,       /* Stack size of task */
                    NULL,        /* parameter of the task */
                    1,           /* priority of the task */
                    &Task1,      /* Task handle to keep track of created task */
                    0);          /* pin task to core 0 */                  
  delay(500); 

  //create a task that will be executed in the Task2code() function, with priority 1 and executed on core 1
  xTaskCreatePinnedToCore(
                    Task2code,   /* Task function. */
                    "Task2",     /* name of task. */
                    10000,       /* Stack size of task */
                    NULL,        /* parameter of the task */
                    1,           /* priority of the task */
                    &Task2,      /* Task handle to keep track of created task */
                    1);          /* pin task to core 1 */
    delay(500); 
}



void Task1code( void * pvParameters ){

  for(;;){
    if (wifi_connected)
  {
   ArduinoOTA.handle();}
  } 
}

//Task2code: blinks an LED every 700 ms
void Task2code( void * pvParameters ){
 

  for(;;){
    if (wifi_connected)
  {
    
    if (!client.connected()) {
        reconnect();
        

    }
    digitalWrite(LED_Blue,HIGH);
    client.loop();
    
    if (irrecv.decode(&results) && preferences.getBool("IR_once flag")) {
      String resultStr = resultToSourceCode(&results);
      preferences.putString("Ir_Raw_data",resultStr);
      delay(100);
      preferences.putBool("IR_once flag",false);
      Serial.println(preferences.getString("Ir_Raw_data",""));
       irrecv.resume();
    }
    unsigned long currentMillis = millis();
    if (currentMillis - previousMQ4Millis >= mq4Interval) {
      previousMQ4Millis = currentMillis;
      int sensorValue = analogRead(MQ4_PIN);
      float voltage = sensorValue * (5.0 / 4095.0); // Assuming a 5V reference voltage
      float rs = (5.0 - voltage) / voltage;
      float ratio = rs / 9.83; // According to datasheet sensitivity is 9.83
      float ppm = pow(ratio, -1.179);
      // Publish the sensor value to MQTT
      String sensorValueStr = String(ppm);
      client.publish("gas", sensorValueStr.c_str());
    }
    if (currentMillis - previousDHTMillis >= dhtInterval) {
      previousDHTMillis = currentMillis;
      float temperature = dht.readTemperature();
      float humidity = dht.readHumidity();
      if (isnan(temperature) || isnan(humidity)) {
        Serial.println("Failed to read from DHT sensor!");
      } else {
        String temperatureStr = String(temperature);
        String humidityStr = String(humidity);
        client.publish("temperature", temperatureStr.c_str());
        client.publish("humidity", humidityStr.c_str());
      }
    }



  }else{
    digitalWrite(LED_Blue,LOW);
    digitalWrite(LED_Yellow,HIGH);
    delay(1000);
    digitalWrite(LED_Yellow,LOW);
    delay(1000);
    Serial.println("Wifi not Connected/Setup Device");
  }
  
    
  }
}

void loop() { }



void parseRawData(const String& input) {
  int start = input.indexOf('{');
  int end = input.indexOf('}');
  
  if (start != -1 && end != -1 && start < end) {
    String rawDataStr = input.substring(start + 1, end);
    rawDataLen = 0;
    int lastIndex = 0;
    int index = rawDataStr.indexOf(',');
    
    while (index != -1 && rawDataLen < MAX_RAW_LEN) {
      rawData[rawDataLen++] = rawDataStr.substring(lastIndex, index).toInt();
      lastIndex = index + 1;
      index = rawDataStr.indexOf(',', lastIndex);
    }
    if (lastIndex < rawDataStr.length() && rawDataLen < MAX_RAW_LEN) {
      rawData[rawDataLen++] = rawDataStr.substring(lastIndex).toInt();
    }
  }
}
void reconnect() {
    while (!client.connected()) {
        Serial.print("Attempting MQTT connection...");
        
        if (client.connect("ESP32Client", mqtt_username.c_str(), mqtt_password.c_str())) {
            Serial.println("connected!");
            client.subscribe("DO_1");
            client.subscribe("DO_2");
            client.subscribe("DO_3");
            client.subscribe("DO_4");
            client.subscribe("ir_control");
            client.publish("DO_1", "1");
            client.publish("DO_2", "1");
            client.publish("DO_3", "1");
            client.publish("DO_4", "1");
        } else {
            Serial.print("failed, rc=");
            Serial.print(client.state());
            Serial.println(" try again in 5 seconds");

            digitalWrite(LED_Blue,HIGH);
            delay(2500);
            digitalWrite(LED_Blue,LOW);
            delay(2500);
            
            
        }
    }
}

void callback(char* topic, byte* payload, unsigned int length) {
    Serial.print("Message arrived [");
    Serial.print(topic);
    Serial.print("] ");
    String topic_rec = String(topic);
    String state = String((char)payload[0]);

    if (topic_rec == "DO_1") digitalWrite(DO_PIN_1, state.toInt());
    else if (topic_rec == "DO_2") digitalWrite(DO_PIN_2, state.toInt());
    else if (topic_rec == "DO_3") digitalWrite(DO_PIN_3, state.toInt());
    else if (topic_rec == "DO_4") digitalWrite(DO_PIN_4, state.toInt());
    else if(topic_rec=="ir_control") {parseRawData(preferences.getString("Ir_Raw_data",""));irsend.sendRaw(rawData, rawDataLen, 38);} //irsend.sendOnkyo(0xA4C0,0x7C1F,1);}
    


}
