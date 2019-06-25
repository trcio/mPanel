#include <FastLED.h>
#include "settings.h"
#include "standby.h"

// fillNoise and rainbowPulse repurposed from FastLED example project

static uint16_t x;
static uint16_t y;
static uint16_t z;

uint16_t speed = 2;
uint16_t scale = 10;

byte noise[WIDTH][HEIGHT];

CRGBPalette16 currentPalette( RainbowColors_p );

void setupStandby()
{
    x = random16();
    y = random16();
    z = random16();
}

void standbyLoop()
{
    fillNoise();
    rainbowPulse();
    FastLED.show();
}

void rainbowPulse()
{
    static byte offset = 128;
    
    for (int i = 0; i < WIDTH; i++)
    {
        for (int j = 0; j < HEIGHT; j++)
        {
            byte index = noise[i][j] + offset;
            byte bright = noise[i][j];
            
            if (bright > 127)
                bright = 255;
            else
                bright = dim8_raw(bright * 2);
                
            leds[j * 15 + i] = ColorFromPalette(currentPalette, index, bright, LINEARBLEND);
        }
    }

    offset++;
}

void fillNoise()
{
    byte dataSmoothing = 0;
    
    if (speed < 50)
        dataSmoothing = 200 - (speed * 4);
    
    for (int i = 0; i < WIDTH; i++)
    {
        int ioffset = scale * i;
        for (int j = 0; j < HEIGHT; j++)
        {
            int joffset = scale * j;
            
            byte data = inoise8(x + ioffset, y + joffset, z);
            
            data = qsub8(data, 16);
            data = qadd8(data, scale8(data, 39));
            
            if (dataSmoothing)
            {
                byte olddata = noise[i][j];
                byte newdata = scale8(olddata, dataSmoothing) + scale8(data, 256 - dataSmoothing);
                data = newdata;
            }
            
            noise[i][j] = data;
        }
    }
    
    z += speed / 2;
    x += speed / 8;
    y -= speed / 16;
}
