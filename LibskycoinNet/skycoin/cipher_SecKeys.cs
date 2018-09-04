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

public class cipher_SecKeys : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal cipher_SecKeys(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(cipher_SecKeys obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~cipher_SecKeys() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          skycoinPINVOKE.delete_cipher_SecKeys(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
    }
  }

  public cipher_SecKey getAt(int i) {
    global::System.IntPtr cPtr = skycoinPINVOKE.cipher_SecKeys_getAt(swigCPtr, i);
    cipher_SecKey ret = (cPtr == global::System.IntPtr.Zero) ? null : new cipher_SecKey(cPtr, false);
    return ret;
  }

  public int setAt(int i, cipher_SecKey seckey) {
    int ret = skycoinPINVOKE.cipher_SecKeys_setAt(swigCPtr, i, cipher_SecKey.getCPtr(seckey));
    return ret;
  }

  public int isEqual(cipher_SecKeys a) {
    int ret = skycoinPINVOKE.cipher_SecKeys_isEqual(swigCPtr, cipher_SecKeys.getCPtr(a));
    return ret;
  }

  public void allocate(int n) {
    skycoinPINVOKE.cipher_SecKeys_allocate(swigCPtr, n);
  }

  public void release() {
    skycoinPINVOKE.cipher_SecKeys_release(swigCPtr);
  }

  public cipher_SecKey data {
    set {
      skycoinPINVOKE.set_cipher_SecKeys_data(swigCPtr, cipher_SecKey.getCPtr(value));
    } 
    get {
      global::System.IntPtr cPtr = skycoinPINVOKE.get_cipher_SecKeys_data(swigCPtr);
      cipher_SecKey ret = (cPtr == global::System.IntPtr.Zero) ? null : new cipher_SecKey(cPtr, false);
      return ret;
    } 
  }

  public int count {
    set {
      skycoinPINVOKE.set_cipher_SecKeys_count(swigCPtr, value);
    } 
    get {
      int ret = skycoinPINVOKE.get_cipher_SecKeys_count(swigCPtr);
      return ret;
    } 
  }

  public cipher_SecKeys() : this(skycoinPINVOKE.new_cipher_SecKeys(), true) {
  }

}

}
