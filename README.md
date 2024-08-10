
# IOT Box with HiveMQ

![IOT Box  ](https://github.com/user-attachments/assets/a70e7d9e-b849-42aa-9466-b2fe1b3cf938)



## Description 
This project provides comprehensive functionality for an IoT device using ESP32. It supports Wi-Fi and MQTT for communication, has an asynchronous web server with webpage  for configuration, handles OTA updates, reads sensor data, and controls relays and IR devices. The use of preferences and SPIFFS ensures that configuration data is stored persistently across reboots. Additionally MQTT protocol makes this device accesible on all platforms such as Windows , Linux, IOS ,Android etc.  using the publisher and subscriber model .


![IOT Box  #description v2](https://github.com/user-attachments/assets/e7b0b889-9802-41d5-9a73-dbc6fbc75ecc)


## Table of Contents
- [Installation](#installation) 
- [Broker Setup](#broker-setup)
- [Usage](#usage) 
- [Tweaking the design](#tweaking-the-design)
- [Electronics](#electronics)
- [Cad files and 3d printing](#cad-files-and-3d-printing)

## Installation
### Clone the repository 
- git clone https://github.com/Vistx/IOT-Box.git
- go to project /IOT Box tasks  
   1. First : Build Filesystem Image   
   2. Then: Upload Filesystem Image
  
  ![1](https://github.com/user-attachments/assets/429ac1e1-7675-42f1-81b2-c67eea4b3313)

- Upload the code to your esp32

![2](https://github.com/user-attachments/assets/6afe996c-2f75-4429-bfd5-66e8d29e7e84)

**Important!** The first code uploaded to the board must be done via Serial connection , after you setup the parameters in the user setup page the code can be uploaded via OTA. You can find the devices IP address in your router, after the first upload via serial change the  upload_port = ip_here in platform.ini file .



![lan users ota edited](https://github.com/user-attachments/assets/001f6988-c398-411f-812a-6701829a38fa)


## Broker Setup
This project uses HiveMQ as a broker , create an account [here](https://www.hivemq.com/) . The next step is to got to **Clusters**,  in the top right corner **Create New Cluster** 

![cluster1edited](https://github.com/user-attachments/assets/565701f5-91bf-49c7-920d-2060af4c1ac9)

and **Create a Serverless Cluster**.

![cluster2edited](https://github.com/user-attachments/assets/ba1d5a5b-b6cd-46c0-ba15-9fd50135dda7)

After creating a Cluster enter **Manage Cluster**  page 

![cluster3edited](https://github.com/user-attachments/assets/c3bd256d-bbcb-46c9-9281-87dfeb4d17ab)

then go to **Access Management**  and create **Credentials** to connect to that cluster. 

![cluster4edited](https://github.com/user-attachments/assets/aebe92c6-78a5-4a4d-ab51-0c181dd55722)

**Important:** Give publish subscribe permissions to the created user.

## Usage

**User Setup:**
Connect to the "Setup IOT Box" access point 
Open your browser and  follow the url:  http://192.168.4.1/

![user setupedited](https://github.com/user-attachments/assets/0f44a2cf-59f3-4074-8688-7d5798ce3494)


Provide Your Wifi and HiveMq Broker credentials 

Windows :

![WINDOWSAPP1](https://github.com/user-attachments/assets/95ce6c4b-2ad7-4a09-8093-742ed96e31d4)



Android / IOS:

I use this app 

![unnamed](https://github.com/user-attachments/assets/6cbdfe8b-13e0-40a3-bc46-6035e632f48a)

Setup IoT MQTT Panel app

![app setup](https://github.com/user-attachments/assets/e094f885-a7b2-48a8-8977-085e7d61807c)

![app setup1](https://github.com/user-attachments/assets/be0d8c54-cc70-4854-8053-91dab02cea9b)

### Broker address(Use HiveMq credentials), username, password ,port(8883),protocol(TSL)

![app setup2](https://github.com/user-attachments/assets/270ebdd8-6d8b-4ac6-a32d-6b568397c2f7)

![app setup3](https://github.com/user-attachments/assets/c89d501e-42fb-46ca-82be-defc0ef61282)

### Setup button for IR codes

![app setup4](https://github.com/user-attachments/assets/599b934d-e250-42c4-a25e-9acc49e391f2)

### Toggle Switch For relay controll 4 in toal (topics -> DO_1,DO_2,DO_3,DO_4)

![app setup5](https://github.com/user-attachments/assets/67699eb4-ef10-46d2-8b89-e6a1eff38679)

![app setup6](https://github.com/user-attachments/assets/85ea0783-f35f-46e6-b2e4-a28cd48ce121)

![app setup 7](https://github.com/user-attachments/assets/d31918a4-ccf3-4cb7-8b4d-b24c943f6a1f)

### Three gauges for gas, humidity and temperature topics 


## Tweaking the design
Drill a small hole to access the reset button on your PCB like so:

![hole drill](https://github.com/user-attachments/assets/250d82ad-56fd-41d5-9e2d-ced1d3bfbabb)


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

### Prototype PCB

![schematics](https://github.com/user-attachments/assets/aa3639ba-ab77-4f25-8d04-51e43380cf9d)

![PCB](https://github.com/user-attachments/assets/286e40b5-c8d3-4025-89c9-f41120a14d95)

![pcb2](https://github.com/user-attachments/assets/c0c77f18-9a70-4a73-86ac-677280d3f414)




### Assembly
![electronics6](https://github.com/user-attachments/assets/72ad0518-fbf2-432c-a7fd-52cc6da0cedf)

![electronics1](https://github.com/user-attachments/assets/ca0b776a-60ca-4361-b8f7-3ecc621fc05d)

![electronics3](https://github.com/user-attachments/assets/6cf6b4d3-3533-4e64-bd61-c09888fd95b0)

![eelectronics2](https://github.com/user-attachments/assets/2a79634b-bcd5-4a39-ab6a-4b76cdf1ce8a)

![electronics4](https://github.com/user-attachments/assets/5d710371-8eaf-44c1-9398-f68911a04567)

![electronics5](https://github.com/user-attachments/assets/9755c0be-b226-432a-9bfd-195fb67ff83c)




# CAD files and 3D Printing

You can find Fusion 360 Files [here](https://grabcad.com/library/iot-box-1)

![WhatsAppVideo2024-08-09at21 43 57-ezgif com-optimize](https://github.com/user-attachments/assets/caf98319-e943-444f-a7df-6f3dad130119)

![WhatsAppVideo2024-08-09at21 44 25-ezgif com-optimize](https://github.com/user-attachments/assets/5803e229-8ab7-4975-bde8-f0c72147a524)



# References

https://randomnerdtutorials.com/

https://www.svgrepo.com/
