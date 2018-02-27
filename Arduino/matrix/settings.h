#define DATA_PIN 3
#define LED_COUNT 225
#define BAUD_RATE 1000000
#define BRIGHTNESS 32

#define STANDBY_HEADER 0xC0
#define CLEAR_HEADER 0xC1
#define FRAME_HEADER 0xC2
#define BRIGHTNESS_HEADER 0xC3

extern CRGB leds[LED_COUNT];
extern bool clientConnected;
