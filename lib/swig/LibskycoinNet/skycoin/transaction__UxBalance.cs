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

public class transaction__UxBalance : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal transaction__UxBalance(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(transaction__UxBalance obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~transaction__UxBalance() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          skycoinPINVOKE.delete_transaction__UxBalance(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
    }
  }

  public SWIGTYPE_p_GoUint8_ Hash {
    set {
      skycoinPINVOKE.transaction__UxBalance_Hash_set(swigCPtr, SWIGTYPE_p_GoUint8_.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = skycoinPINVOKE.transaction__UxBalance_Hash_get(swigCPtr);
      SWIGTYPE_p_GoUint8_ ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_GoUint8_(cPtr, false);
      return ret;
    } 
  }

  public ulong BkSeq {
    set {
      skycoinPINVOKE.transaction__UxBalance_BkSeq_set(swigCPtr, value);
    } 
    get {
      ulong ret = skycoinPINVOKE.transaction__UxBalance_BkSeq_get(swigCPtr);
      return ret;
    } 
  }

  public cipher__Address Address {
    set {
      skycoinPINVOKE.transaction__UxBalance_Address_set(swigCPtr, cipher__Address.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = skycoinPINVOKE.transaction__UxBalance_Address_get(swigCPtr);
      cipher__Address ret = (cPtr == global::System.IntPtr.Zero) ? null : new cipher__Address(cPtr, false);
      return ret;
    } 
  }

  public ulong Coins {
    set {
      skycoinPINVOKE.transaction__UxBalance_Coins_set(swigCPtr, value);
    } 
    get {
      ulong ret = skycoinPINVOKE.transaction__UxBalance_Coins_get(swigCPtr);
      return ret;
    } 
  }

  public ulong Hours {
    set {
      skycoinPINVOKE.transaction__UxBalance_Hours_set(swigCPtr, value);
    } 
    get {
      ulong ret = skycoinPINVOKE.transaction__UxBalance_Hours_get(swigCPtr);
      return ret;
    } 
  }

  public ulong InitialHours {
    set {
      skycoinPINVOKE.transaction__UxBalance_InitialHours_set(swigCPtr, value);
    } 
    get {
      ulong ret = skycoinPINVOKE.transaction__UxBalance_InitialHours_get(swigCPtr);
      return ret;
    } 
  }

  public SWIGTYPE_p_GoUint8_ SrcTransaction {
    set {
      skycoinPINVOKE.transaction__UxBalance_SrcTransaction_set(swigCPtr, SWIGTYPE_p_GoUint8_.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = skycoinPINVOKE.transaction__UxBalance_SrcTransaction_get(swigCPtr);
      SWIGTYPE_p_GoUint8_ ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_GoUint8_(cPtr, false);
      return ret;
    } 
  }

  public transaction__UxBalance() : this(skycoinPINVOKE.new_transaction__UxBalance(), true) {
  }

}

}