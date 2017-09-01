using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SphinxNet
{
  public class PocketSphinx
  {
    
    [DllImport("cmusphinx\\pocketsphinx.dll")]
    public static extern IntPtr ps_args();

    //ps_decoder_t* ps_init(cmd_ln_t* config)
    [DllImport("cmusphinx\\pocketsphinx.dll",
        CallingConvention = CallingConvention.Cdecl)]
    public extern static IntPtr ps_init(IntPtr config);

    //ps_decoder_t* ps_init(cmd_ln_t* config)
    [DllImport("cmusphinx\\sphinxbase.dll",
        CallingConvention = CallingConvention.Cdecl)]
    public extern static IntPtr cmd_ln_init(IntPtr inout_cmdln, IntPtr defn, [MarshalAs(UnmanagedType.I4)] Int32 strict, params string[] args);


  }
}
