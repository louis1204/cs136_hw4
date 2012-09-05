﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.544
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVC3.SLBrand {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="BrandInfo", Namespace="http://schemas.datacontract.org/2004/07/DomainModel")]
    [System.SerializableAttribute()]
    public partial class BrandInfo : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int brand_idField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string brand_nameField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int brand_id {
            get {
                return this.brand_idField;
            }
            set {
                if ((this.brand_idField.Equals(value) != true)) {
                    this.brand_idField = value;
                    this.RaisePropertyChanged("brand_id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string brand_name {
            get {
                return this.brand_nameField;
            }
            set {
                if ((object.ReferenceEquals(this.brand_nameField, value) != true)) {
                    this.brand_nameField = value;
                    this.RaisePropertyChanged("brand_name");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SLBrand.ISLBrand")]
    public interface ISLBrand {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISLBrand/ReadBrand", ReplyAction="http://tempuri.org/ISLBrand/ReadBrandResponse")]
        MVC3.SLBrand.BrandInfo ReadBrand(int id, ref string[] errors);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISLBrand/CreateBrand", ReplyAction="http://tempuri.org/ISLBrand/CreateBrandResponse")]
        int CreateBrand(string name, ref string[] errors);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISLBrand/UpdateBrand", ReplyAction="http://tempuri.org/ISLBrand/UpdateBrandResponse")]
        int UpdateBrand(int id, string name, ref string[] errors);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISLBrand/ReadAllBrand", ReplyAction="http://tempuri.org/ISLBrand/ReadAllBrandResponse")]
        MVC3.SLBrand.BrandInfo[] ReadAllBrand(ref string[] errors);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ISLBrandChannel : MVC3.SLBrand.ISLBrand, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SLBrandClient : System.ServiceModel.ClientBase<MVC3.SLBrand.ISLBrand>, MVC3.SLBrand.ISLBrand {
        
        public SLBrandClient() {
        }
        
        public SLBrandClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SLBrandClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SLBrandClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SLBrandClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public MVC3.SLBrand.BrandInfo ReadBrand(int id, ref string[] errors) {
            return base.Channel.ReadBrand(id, ref errors);
        }
        
        public int CreateBrand(string name, ref string[] errors) {
            return base.Channel.CreateBrand(name, ref errors);
        }
        
        public int UpdateBrand(int id, string name, ref string[] errors) {
            return base.Channel.UpdateBrand(id, name, ref errors);
        }
        
        public MVC3.SLBrand.BrandInfo[] ReadAllBrand(ref string[] errors) {
            return base.Channel.ReadAllBrand(ref errors);
        }
    }
}
