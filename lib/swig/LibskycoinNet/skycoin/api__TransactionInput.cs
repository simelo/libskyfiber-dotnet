//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (http://www.swig.org).
// Version 3.0.12
//
// Do not make changes to this file unless you know what you are doing--modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------

namespace skycoin {

public class api__TransactionInput : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal api__TransactionInput(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(api__TransactionInput obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~api__TransactionInput() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          skycoinPINVOKE.delete_api__TransactionInput(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
    }
  }

  public coin__UxOut UxOut {
    set {
      skycoinPINVOKE.api__TransactionInput_UxOut_set(swigCPtr, coin__UxOut.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = skycoinPINVOKE.api__TransactionInput_UxOut_get(swigCPtr);
      coin__UxOut ret = (cPtr == global::System.IntPtr.Zero) ? null : new coin__UxOut(cPtr, false);
      return ret;
    } 
  }

  public ulong CalculatedHours {
    set {
      skycoinPINVOKE.api__TransactionInput_CalculatedHours_set(swigCPtr, value);
    } 
    get {
      ulong ret = skycoinPINVOKE.api__TransactionInput_CalculatedHours_get(swigCPtr);
      return ret;
    } 
  }

  public api__TransactionInput() : this(skycoinPINVOKE.new_api__TransactionInput(), true) {
  }

}

}
