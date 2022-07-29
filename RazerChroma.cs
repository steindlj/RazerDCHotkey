using ChromaSDK;

namespace RazerChroma
{
    public class Chroma
    {
        public void InitChroma()
        {
            ChromaSDK.APPINFOTYPE appInfo = new()
            {
                Title = "RazerDCHotkey",
                Description = "Custom Chroma Animation for Mute Button in Discord",
                Author_Name = "steindlj",
                Author_Contact = "https://github.com/steindlj",
                SupportedDevice = (0x01 | 0x02),
                Category = 0x02
            };

            var result = ChromaAnimationAPI.InitSDK(ref appInfo);

            if (result != RazerErrors.RZRESULT_SUCCESS)
            {
                Console.Error.WriteLine("Failed to initialize Chroma SDK with error={0}\r\n", result);
                InitChroma();
            }
            else
            {
                Console.WriteLine("Initialized Chroma SDK");
            }
        }

        public void setEffect(Keyboard.RZKEY key, bool muted)
        {
            var layerKeyboard = "Animations/Rainbow_Keyboard.chroma";
            var layerMouse = "Animations/Blank_Mouse.chroma";
            ChromaAnimationAPI.CloseAnimationName(layerKeyboard);
            ChromaAnimationAPI.CloseAnimationName(layerMouse);
            ChromaAnimationAPI.MakeBlankFramesRGBName(layerMouse, 30, (float)0.033, 51, 255, 255);
            ChromaAnimationAPI.SetKeyColorAllFramesName(layerKeyboard, key.GetHashCode(), setHotkeyColor(muted));
            ChromaAnimationAPI.PlayAnimationName(layerKeyboard, true);
            ChromaAnimationAPI.PlayAnimationName(layerMouse, true);
        }

        private int setHotkeyColor(bool muted)
        {
            var color = 0;
            if (muted == true)
            {
                color = ChromaAnimationAPI.GetRGB(255, 0, 0);
            }
            else
            {
                color = ChromaAnimationAPI.GetRGB(0, 255, 0);
            }
            return color;
        }
    }
}