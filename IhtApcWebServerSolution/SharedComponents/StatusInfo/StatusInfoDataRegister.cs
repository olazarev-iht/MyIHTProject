using System.Windows;
//using System.Windows.Media;

namespace SharedComponents.StatusInfo
{
    public class StatusInfoDataRegister
    {
        public enum Register
        {
            Reg_0,
            Reg_1,
            Reg_2,
            Reg_4,
        }

        public enum RegisterIdxBit
        {
            Bit_0,
            Bit_1,
            Bit_2,
            Bit_3,
            Bit_4,
            Bit_5,
            Bit_6,
            Bit_7,
            Bit_8,
            Bit_9,
            Bit_10,
            Bit_11,
            Bit_12,
            Bit_13,
            Bit_14,
            Bit_15,
        }

        public readonly string Description;
        //public readonly Brush OffColor;
        //public readonly Brush OnColor;
        public readonly bool IsVisible;

        public StatusInfoDataRegister()
        {
            Description = string.Empty;
            //OffColor = Brushes.White;
            //OnColor = Brushes.White;
            IsVisible = false;
        }

        public StatusInfoDataRegister(
           string description,
           //Brush offColor,
           //Brush onColor,
           bool isVisible)
        {
            Description = description;
            //OffColor = offColor;
            //OnColor = onColor;
            IsVisible = isVisible;
        }
    }
}
