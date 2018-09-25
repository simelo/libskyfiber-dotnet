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

public class TransactionObjectHandle : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal TransactionObjectHandle(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(TransactionObjectHandle obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~TransactionObjectHandle() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          skycoinPINVOKE.delete_TransactionObjectHandle(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
    }
  }

  public SWIGTYPE_p_GoUint8_ hash {
    set {
      skycoinPINVOKE.set_TransactionObjectHandle_hash(swigCPtr, SWIGTYPE_p_GoUint8_.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = skycoinPINVOKE.get_TransactionObjectHandle_hash(swigCPtr);
      SWIGTYPE_p_GoUint8_ ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_GoUint8_(cPtr, false);
      return ret;
    } 
  }

  public SWIGTYPE_p_Transaction__Handle handle {
    set {
      skycoinPINVOKE.set_TransactionObjectHandle_handle(swigCPtr, SWIGTYPE_p_Transaction__Handle.getCPtr(value));
      if (skycoinPINVOKE.SWIGPendingException.Pending) throw skycoinPINVOKE.SWIGPendingException.Retrieve();
    } 
    get {
      SWIGTYPE_p_Transaction__Handle ret = new SWIGTYPE_p_Transaction__Handle(skycoinPINVOKE.get_TransactionObjectHandle_handle(swigCPtr), true);
      if (skycoinPINVOKE.SWIGPendingException.Pending) throw skycoinPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    } 
  }

  public TransactionObjectHandle() : this(skycoinPINVOKE.new_TransactionObjectHandle(), true) {
  }

}

}