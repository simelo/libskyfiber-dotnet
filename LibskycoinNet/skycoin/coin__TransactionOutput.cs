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

public class coin__TransactionOutput : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal coin__TransactionOutput(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(coin__TransactionOutput obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~coin__TransactionOutput() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          skycoinPINVOKE.delete_coin__TransactionOutput(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
    }
  }

  public int isEqual(coin__TransactionOutput t) {
    int ret = skycoinPINVOKE.coin__TransactionOutput_isEqual(swigCPtr, coin__TransactionOutput.getCPtr(t));
    return ret;
  }

  public cipher__Address Address {
    set {
      skycoinPINVOKE.set_coin__TransactionOutput_Address(swigCPtr, cipher__Address.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = skycoinPINVOKE.get_coin__TransactionOutput_Address(swigCPtr);
      cipher__Address ret = (cPtr == global::System.IntPtr.Zero) ? null : new cipher__Address(cPtr, false);
      return ret;
    } 
  }

  public SWIGTYPE_p_GoUint64_ Coins {
    set {
      skycoinPINVOKE.set_coin__TransactionOutput_Coins(swigCPtr, SWIGTYPE_p_GoUint64_.getCPtr(value));
      if (skycoinPINVOKE.SWIGPendingException.Pending) throw skycoinPINVOKE.SWIGPendingException.Retrieve();
    } 
    get {
      SWIGTYPE_p_GoUint64_ ret = new SWIGTYPE_p_GoUint64_(skycoinPINVOKE.get_coin__TransactionOutput_Coins(swigCPtr), true);
      if (skycoinPINVOKE.SWIGPendingException.Pending) throw skycoinPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    } 
  }

  public SWIGTYPE_p_GoUint64_ Hours {
    set {
      skycoinPINVOKE.set_coin__TransactionOutput_Hours(swigCPtr, SWIGTYPE_p_GoUint64_.getCPtr(value));
      if (skycoinPINVOKE.SWIGPendingException.Pending) throw skycoinPINVOKE.SWIGPendingException.Retrieve();
    } 
    get {
      SWIGTYPE_p_GoUint64_ ret = new SWIGTYPE_p_GoUint64_(skycoinPINVOKE.get_coin__TransactionOutput_Hours(swigCPtr), true);
      if (skycoinPINVOKE.SWIGPendingException.Pending) throw skycoinPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    } 
  }

  public coin__TransactionOutput() : this(skycoinPINVOKE.new_coin__TransactionOutput(), true) {
  }

}

}
