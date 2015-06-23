//#r @"..\packages\fszmq\lib\net45\fszmq.dll"
#r @"..\..\fszmq\src\fszmq\bin\Debug\fszmq.dll"
#nowarn "1182"
#nowarn "9"

open System
open System.Runtime.InteropServices
open fszmq

Environment.CurrentDirectory <- __SOURCE_DIRECTORY__ + @"..\..\lib\czmq\win\x64\"

[<RequireQualifiedAccess>]
module C =
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
    extern HANDLE zbeacon_new (HANDLE zctx_t, int port_nbr)

module Test =
    let ctx = new Context()
    let beaconHandle = C.zbeacon_new (ctx.Handle, 9999)
    let beacon = Marshal.PtrToStructure<C.zbeacon_t>(beaconHandle)
    
    