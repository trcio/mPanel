using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mPanel.Matrix;
using MoonSharp.Interpreter;

namespace mPanel.Actions.Scripter
{
    public class MatrixScript
    {
        private const string FpsNumberName = "fps";
        private const string DrawFunctionName = "draw";

        private Script Lua;
        private DynValue DrawHandle;

        public Frame Frame { get; set; }
        public double FrameInterval { get; set; }

        static MatrixScript()
        {
            UserData.RegisterType<Graphics>();
            UserData.RegisterType<Color>();
            UserData.RegisterType<Point>();
            UserData.RegisterType<Pen>();
            UserData.RegisterType<Brush>();
        }

        public MatrixScript()
        {
            Frame = new Frame();
        }

        private void SetGlobals()
        {
            Lua.Globals["g"] = Frame.Graphics;
            Lua.Globals["width"] = Frame.Width;
            Lua.Globals["height"] = Frame.Height;
            Lua.Globals["rgb"] = (Func<byte, byte, byte, Color>) LuaFunctions.Rgb;
            Lua.Globals["hsv"] = (Func<byte, Color>) LuaFunctions.Hsv;
            Lua.Globals["point"] = (Func<int, int, Point>) LuaFunctions.Point;
            Lua.Globals["pen"] = (Func<Color, Pen>) LuaFunctions.Pen;
            Lua.Globals["brush"] = (Func<Color, Brush>) LuaFunctions.Brush;
        }

        private bool MemberExists(string name, DataType type)
        {
            return Lua.Globals.Pairs.Count(pair => pair.Key.String.Equals(name) && pair.Value.Type == type) == 1;
        }

        public void LoadString(string code)
        {
            Lua = new Script {Options = {CheckThreadAccess = false}};
            SetGlobals();

            Lua.DoString(code);

            if (!MemberExists(FpsNumberName, DataType.Number))
                throw new Exception($"'{FpsNumberName}' number must be declared");

            if (!MemberExists(DrawFunctionName, DataType.Function))
                throw new Exception($"'{DrawFunctionName}' function must be declared");

            FrameInterval = 1000 / Lua.Globals.Get("fps").Number;
            DrawHandle = Lua.Globals.Get("draw");
        }

        public void ExecuteDraw()
        {
            Lua.Call(DrawHandle);
        }
    }
}
