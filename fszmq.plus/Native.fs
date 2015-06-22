namespace fszmq

open System
open System.Runtime.InteropServices

#nowarn "1182"
#nowarn "9"

[<RequireQualifiedAccess>]
module internal C =
    open System.Text

    type HANDLE = nativeint
    type zmq_msg_t =  nativeint
    type size_t = unativeint
    type strBuffer = StringBuilder

    [<Struct; StructLayout (LayoutKind.Sequential)>]
    type zbeacon_t =
        //  Pipe through to backend agent
        val mutable pipe: HANDLE
        //  Our own address as string
        val mutable hostname: string
        //  TODO: actorize this class
        val mutable ctx: HANDLE

    [<DllImport("")]
    zbeacon_t *
    zbeacon_new (zctx_t *ctx, int port_nbr)
