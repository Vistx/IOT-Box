
# IOT Box with HiveMQ

![IOT Box  ](https://github.com/user-attachments/assets/a70e7d9e-b849-42aa-9466-b2fe1b3cf938)



## Description 
This project provides comprehensive functionality for an IoT device using ESP32. It supports Wi-Fi and MQTT for communication, has an asynchronous web server with webpage  for configuration, handles OTA updates, reads sensor data, and controls relays and IR devices. The use of preferences and SPIFFS ensures that configuration data is stored persistently across reboots. Additionally MQTT protocol makes this device accesible on all platforms such as Windows , Linux, IOS ,Android etc.  using the publisher and subscriber model .

![IOT Box  #description v2](https://github.com/user-attachments/assets/e7b0b889-9802-41d5-9a73-dbc6fbc75ecc)


## Table of Contents
- [Installation](#installation) 
- [Broker Setup](#broker setup)
- [Usage](#usage) 
- Tweaking the design
- Electronics 

## Installation
### Clone the repository 
- git clone https://github.com/username/repo.git
- go to project tasks  
   1. First : Build Filesystem Image   
   3. Then: Upload Filesystem Image
  [img]
- Upload the code to your esp32
  [img]
**Important!** The first code uploaded to the board must be done via Serial connection , after you setup the parameters in the user setup page the code can be uploaded via OTA.


## Broker Setup
This project uses HiveMQ as a broker , create an account [here](https://www.hivemq.com/) . The next step is to got to **Clusters**,  in the top right corner **Create New Cluster** and **Create a Serverless Cluster**.

After creating a Cluster enter **Manage Cluster**  page then go to **Access Management**  and create **Credentials** to connect to that cluster. 

**Important:** Give publish subscribe permissions to the created user.

## Usage

**User Setup:**
Connect to the "Setup IOT Box" access point 
Open your browser and  follow the url:  http://192.168.4.1/

Image here

Provide Your Wifi and HiveMq Broker credentials 

Windows :
Image here
Android / IOS:
 image here

Setup IoT MQTT Panel app

## Tweaking the design
Drill a small hole to access the reset button on your PCB like so:

img here 

This button resets your saved credentials and sends the device in setup mode.

##  Electronics
Parts used:
1x ESP-Wroom-32u
1x MQ-4 sensor
1x DHT 11
4x Relay module
1x IR transmitter and receiver module
1x Antenna with mount
1x Pair Male + Female 12v DC jack 
1x Push button
2x Switches
1x Prototype PCB 6x8 breadboard
3x Leds (Red,Yellow,Blue)
3x Resistors 48 Ohm



# CAD files and 3D Printing