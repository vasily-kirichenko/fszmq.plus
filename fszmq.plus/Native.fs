#if INTERACTIVE
System.Environment.CurrentDirectory <- __SOURCE_DIRECTORY__ + @"..\..\lib\czmq\win\x64\"
#else
namespace fszmq
#endif

open System
open System.Runtime.InteropServices

#nowarn "1182"
#nowarn "9"

[<RequireQualifiedAccess>]
module internal C =
    open System.Text

    type HANDLE = nativeint
    type zmq_msg_t = nativeint
    type size_t = unativeint
    type strBuffer = StringBuilder

    [<Struct; StructLayout (LayoutKind.Sequential)>]
    type zbeacon_t =
        /// Pipe through to backend agent
        val mutable pipe: HANDLE
        /// Our own address as string
        val mutable hostname: string
        val mutable ctx: HANDLE

    [<DllImport("czmq", CallingConvention = CallingConvention.Cdecl)>]
    extern IntPtr zbeacon_new (HANDLE zctx_t, int port_nbr)
    // Marshal.PtrToStructure<zbeacon_t>(returned value)
    
#if INTERACTIVE
    
    zbeacon_new()


#endif