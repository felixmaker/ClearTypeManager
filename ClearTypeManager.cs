using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ClearTypeManager
{
    public static class ClearTypeManager
    {
        [DllImport("User32")]
        static extern bool SystemParametersInfo
        (
            uint uiAction,
            uint uiParam,
            uint pvParam,
            uint fWinIni
        );

        static uint SPI_SETFONTSMOOTHING = 0x004B;
        static uint SPI_SETFONTSMOOTHINGTYPE = 0x200B;
        static uint SPIF_UPDATEINIFILE = 0x1;
        static uint SPIF_SENDCHANGE = 0x2;
        static uint FE_FONTSMOOTHINGCLEARTYPE = 0x2;

        public static void EnableClearType()
        {
            SystemParametersInfo(SPI_SETFONTSMOOTHING, 1, 0, SPIF_UPDATEINIFILE | SPIF_SENDCHANGE);
            SystemParametersInfo(SPI_SETFONTSMOOTHINGTYPE, 0, FE_FONTSMOOTHINGCLEARTYPE, SPIF_UPDATEINIFILE | SPIF_SENDCHANGE);
        }

        public static void DisableClearType()
        {
            SystemParametersInfo(SPI_SETFONTSMOOTHING, 0, 0, SPIF_UPDATEINIFILE | SPIF_SENDCHANGE);
        }
    }
}
