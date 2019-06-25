#define DATA_PIN 3
#define WIDTH 3
#define HEIGHT 1
#define LED_COUNT WIDTH*HEIGHT
#define BAUD_RATE 1000000
#define BRIGHTNESS 255

#define STANDBY_HEADER 0xC0
#define CLEAR_HEADER 0xC1
#define FRAME_HEADER 0xC2
#define BRIGHTNESS_HEADER 0xC3

extern CRGB leds[LED_COUNT];
extern bool clientConnected;
