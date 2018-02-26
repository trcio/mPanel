using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace mPanel.Actions.Animator
{
    [Serializable]
    public class AnimationFile
    {
        public int Delay { get; set; }
        public List<Bitmap> Bitmaps { get; set; }

        public static bool SaveAnimation(AnimationFile animation, string file)
        {
            using (var ms = new MemoryStream())
            {
                var bf = new BinaryFormatter();
                bf.Serialize(ms, animation);

                try
                {
                    File.WriteAllBytes(file, ms.ToArray());
                }
                catch (Exception)
                {
                    return false;
                }
            }

            return true;
        }

        public static AnimationFile ReadAnimation(string file)
        {
            try
            {
                using (var ms = new MemoryStream(File.ReadAllBytes(file)))
                {
                    var bf = new BinaryFormatter();
                    return (AnimationFile) bf.Deserialize(ms);
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
