using HardwareId;
using LitJson;
using QLTK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTK.Extensions;
public static class NroAccountExtension
{
    public static bool ExistedWindow(this NroAccount account, out IntPtr hWnd)
    {
        hWnd = IntPtr.Zero;
        if (account.process == null || account.process.HasExited)
            return false;

        hWnd = account.process.MainWindowHandle;
        return hWnd != IntPtr.Zero;
    }

    public static void sendMessage(this NroAccount account, object obj)
    {
        var socketListener = App.Current.GetService<AsynchronousSocketListener>()!;
        socketListener.Send(account.workSocket, JsonMapper.ToJson(obj));
    }
}
