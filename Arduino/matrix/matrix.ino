#include <FastLED.h>
#include "settings.h"
#include "serial.h"
#include "standby.h"

CRGB leds[LED_COUNT];

void setup()
{
    Serial.begin(BAUD_RATE);

    FastLED.addLeds<NEOPIXEL, DATA_PIN>(leds, LED_COUNT);

    FastLED.setBrightness(BRIGHTNESS);

    FastLED.show();

    setupStandby();
}

void loop()
{
    serialLoop();

    if (!clientConnected)
        standbyLoop();
}
