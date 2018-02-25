namespace mPanel.Matrix
{
    public class GuiPanel : MatrixPanel
    {
        private bool InUse;

        public override bool Connected => InUse;

        public GuiPanel(int width, int height) : base(width, height) { }

        public override bool Connect()
        {
            InUse = true;
            return true;
        }

        public override void Disconnect()
        {
            InUse = false;
        }

        public override void Standby(byte brightness)
        {
            OnFrameHook(new byte[Width * Height * PixelDataLength]);
        }

        public override void Clear()
        {
            OnFrameHook(new byte[Width * Height * PixelDataLength]);
        }

        public override void SendFrame(byte[] buffer)
        {
            OnFrameHook(buffer);
        }

        public override void SendFrame(Frame frame)
        {
            SendFrame(frame.GetBytes());
        }

        public override void SetBrightness(byte brightness)
        {

        }

        public override string ToString()
        {
            return "GUI";
        }

        public override void Dispose()
        {

        }
    }
}
