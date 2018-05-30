using System;

// SimplexNoise is a C# implementation of the FastLED/noise.cpp inoise8 function

namespace mPanel.Extra.Noise
{
    public static class SimplexNoise
    {
        private static readonly byte[] Permutations =
        {
            151, 160, 137, 91, 90, 15, 131, 13, 201, 95, 96, 53, 194, 233, 7, 225, 140, 36, 103, 30, 69, 142, 8, 99, 37,
            240, 21, 10, 23, 190, 6, 148, 247, 120, 234, 75, 0, 26, 197, 62, 94, 252, 219, 203, 117, 35, 11, 32, 57,
            177, 33, 88, 237, 149, 56, 87, 174, 20, 125, 136, 171, 168, 68, 175, 74, 165, 71, 134, 139, 48, 27, 166, 77,
            146, 158, 231, 83, 111, 229, 122, 60, 211, 133, 230, 220, 105, 92, 41, 55, 46, 245, 40, 244, 102, 143, 54,
            65, 25, 63, 161, 1, 216, 80, 73, 209, 76, 132, 187, 208, 89, 18, 169, 200, 196, 135, 130, 116, 188, 159, 86,
            164, 100, 109, 198, 173, 186, 3, 64, 52, 217, 226, 250, 124, 123, 5, 202, 38, 147, 118, 126, 255, 82, 85,
            212, 207, 206, 59, 227, 47, 16, 58, 17, 182, 189, 28, 42, 223, 183, 170, 213, 119, 248, 152, 2, 44, 154,
            163, 70, 221, 153, 101, 155, 167, 43, 172, 9, 129, 22, 39, 253, 19, 98, 108, 110, 79, 113, 224, 232, 178,
            185, 112, 104, 218, 246, 97, 228, 251, 34, 242, 193, 238, 210, 144, 12, 191, 179, 162, 241, 81, 51, 145,
            235, 249, 14, 239, 107, 49, 192, 214, 31, 181, 199, 106, 157, 184, 84, 204, 176, 115, 121, 50, 45, 127, 4,
            150, 254, 138, 236, 205, 93, 222, 114, 67, 29, 24, 72, 243, 141, 128, 195, 78, 66, 215, 61, 156, 180, 151
        };

        public static byte Noise(ushort xCoord, ushort yCoord, ushort zCoord)
        {
            var noise = Raw(xCoord, yCoord, zCoord);
            noise += 64;
            return (byte) Math.Min(255, noise + noise);
        }

        private static sbyte Raw(ushort xCoord, ushort yCoord, ushort zCoord)
        {
            const byte n = 0x80;

            var x = (byte) (xCoord >> 8);
            var y = (byte) (yCoord >> 8);
            var z = (byte) (zCoord >> 8);

            var a = (byte) (Permutations[x] + y);
            var aa = (byte) (Permutations[a] + z);
            var ab = (byte) (Permutations[a + 1] + z);
            var b = (byte) (Permutations[x + 1] + y);
            var ba = (byte) (Permutations[b] + z);
            var bb = (byte) (Permutations[b + 1] + z);

            var u = (byte) xCoord;
            var v = (byte) yCoord;
            var w = (byte) zCoord;

            var xx = (sbyte) ((u >> 1) & 0x7F);
            var yy = (sbyte) ((v >> 1) & 0x7F);
            var zz = (sbyte) ((w >> 1) & 0x7F);

            u = Scale(u, u);
            v = Scale(v, v);
            w = Scale(w, w);

            var x1 = Lerp(Grad(Permutations[aa], xx, yy, zz), Grad(Permutations[ba], (sbyte) (xx - n), yy, zz), u);
            var x2 = Lerp(Grad(Permutations[ab], xx, (sbyte) (yy - n), zz), Grad(Permutations[bb], (sbyte) (xx - n), (sbyte) (yy - n), zz), u);
            var x3 = Lerp(Grad(Permutations[aa + 1], xx, yy, (sbyte) (zz - n)), Grad(Permutations[ba + 1], (sbyte) (xx - n), yy, (sbyte) (zz - n)), u);
            var x4 = Lerp(Grad(Permutations[ab + 1], xx, (sbyte) (yy - n), (sbyte) (zz - n)), Grad(Permutations[bb + 1], (sbyte) (xx - n), (sbyte) (yy - n), (sbyte) (zz - n)), u);

            return Lerp(Lerp(x1, x2, v), Lerp(x3, x4, v), w);
        }

        private static byte Scale(byte a, byte scale)
        {
            return (byte) (a * (scale / 256.0));
        }

        private static sbyte Lerp(sbyte a, sbyte b, byte frac)
        {
            if (b > a)
                return (sbyte) (a + Scale((byte) (b - a), frac));

            return (sbyte) (a - Scale((byte) (a - b), frac));
        }

        private static sbyte SelectBasedOnHashBit(byte hash, byte bit, sbyte a, sbyte b)
        {
            return (hash & (1 << bit)) > 0 ? a : b;
        }

        private static sbyte Average(sbyte a, sbyte b)
        {
            return (sbyte) (((a + b) >> 1) + (a & 0x1));
        }

        private static sbyte Grad(byte hash, sbyte x, sbyte y, sbyte z)
        {
            hash &= 0xF;

            var u = SelectBasedOnHashBit(hash, 3, y, x);
            var v = hash < 4 ? y : (hash == 12 || hash == 14 ? x : z);

            if ((hash & 1) > 0)
                u = (sbyte) -u;

            if ((hash & 2) > 0)
                v = (sbyte) -v;

            return Average(u, v);
        }
    }
}
