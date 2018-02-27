const byte packetHeader[4] = { 0xDE, 0xAD, 0xBE, 0xEF };

void serialLoop();
bool waitForHeader(byte &);
bool bytesMatch(byte *, const byte *);
void clearBuffer();
