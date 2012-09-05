﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.544
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVC3.SLProductType {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ProductTypeInfo", Namespace="http://schemas.datacontract.org/2004/07/DomainModel")]
    [System.SerializableAttribute()]
    public partial class ProductTypeInfo : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int product_type_idField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string product_type_nameField;
        
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
        public int product_type_id {
            get {
                return this.product_type_idField;
            }
            set {
                if ((this.product_type_idField.Equals(value) != true)) {
                    this.product_type_idField = value;
                    this.RaisePropertyChanged("product_type_id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string product_type_name {
            get {
                return this.product_type_nameField;
            }
            set {
                if ((object.ReferenceEquals(this.product_type_nameField, value) != true)) {
                    this.product_type_nameField = value;
                    this.RaisePropertyChanged("product_type_name");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SLProductType.ISLProductType")]
    public interface ISLProductType {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISLProductType/ReadProductType", ReplyAction="http://tempuri.org/ISLProductType/ReadProductTypeResponse")]
        MVC3.SLProductType.ProductTypeInfo ReadProductType(int id, ref string[] errors);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISLProductType/CreateProductType", ReplyAction="http://tempuri.org/ISLProductType/CreateProductTypeResponse")]
        int CreateProductType(string name, ref string[] errors);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISLProductType/UpdateProductType", ReplyAction="http://tempuri.org/ISLProductType/UpdateProductTypeResponse")]
        int UpdateProductType(int id, string name, ref string[] errors);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISLProductType/ReadAllProductType", ReplyAction="http://tempuri.org/ISLProductType/ReadAllProductTypeResponse")]
        MVC3.SLProductType.ProductTypeInfo[] ReadAllProductType(ref string[] errors);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ISLProductTypeChannel : MVC3.SLProductType.ISLProductType, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SLProductTypeClient : System.ServiceModel.ClientBase<MVC3.SLProductType.ISLProductType>, MVC3.SLProductType.ISLProductType {
        
        public SLProductTypeClient() {
        }
        
        public SLProductTypeClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SLProductTypeClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SLProductTypeClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SLProductTypeClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public MVC3.SLProductType.ProductTypeInfo ReadProductType(int id, ref string[] errors) {
            return base.Channel.ReadProductType(id, ref errors);
        }
        
        public int CreateProductType(string name, ref string[] errors) {
            return base.Channel.CreateProductType(name, ref errors);
        }
        
        public int UpdateProductType(int id, string name, ref string[] errors) {
            return base.Channel.UpdateProductType(id, name, ref errors);
        }
        
        public MVC3.SLProductType.ProductTypeInfo[] ReadAllProductType(ref string[] errors) {
            return base.Channel.ReadAllProductType(ref errors);
        }
    }
}
