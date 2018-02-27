#include <Arduino.h>
#include <FastLED.h>
#include "settings.h"
#include "serial.h"

bool clientConnected = false;

void serialLoop()
{
    if (!Serial)
    {
        clientConnected = false;
        return;
    }
    
    byte command;

    if (!waitForHeader(command))
        return;

    clientConnected = true;
    
    switch (command)
    {
        // standby mode
        case STANDBY_HEADER:
        {
            byte value = Serial.read();
          
            FastLED.setBrightness(value);
            
            clientConnected = false;
        }
        break;
        // clear leds of color
        case CLEAR_HEADER:
        {
            FastLED.clear();
        }
        break;
        // read a frame of data
        case FRAME_HEADER:
        {            
            FastLED.clear();
            
            Serial.readBytes((byte *) leds, LED_COUNT * 3);
        }    
        break;
        // set master brightness
        case BRIGHTNESS_HEADER:
        {         
            byte value = Serial.read();
            
            FastLED.setBrightness(value);
        }
        break;
    }

    FastLED.show();

    clearBuffer();
}

bool waitForHeader(byte &command)
{
    if (Serial.available() < 1)
        return false;
    
    byte b = Serial.read();
    
    if (b != packetHeader[0])
        return false;
    
    byte bytes[5] = { b };
    
    Serial.readBytes(bytes + 1, 4);

    command = bytes[4];
    
    return bytesMatch(bytes, packetHeader);
}

bool bytesMatch(byte *bytes, const byte *expected)
{
    for (byte i = 0; i < sizeof(expected); i++)
    {
        if (bytes[i] != expected[i])
            return false;
    }

    return true;
}

void clearBuffer()
{
    while (Serial.available() > 0)
    {
        Serial.read();
    }
}
