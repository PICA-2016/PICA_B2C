﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PICA_B2C.ServiceAgent.MainModule.wsInsertaClientesDSReference {
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://ws.wso2.org/dataservice")]
    public partial class DataServiceFault : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string current_paramsField;
        
        private string current_request_nameField;
        
        private string nested_exceptionField;
        
        private DataServiceFaultSource_data_service source_data_serviceField;
        
        private string ds_codeField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string current_params {
            get {
                return this.current_paramsField;
            }
            set {
                this.current_paramsField = value;
                this.RaisePropertyChanged("current_params");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string current_request_name {
            get {
                return this.current_request_nameField;
            }
            set {
                this.current_request_nameField = value;
                this.RaisePropertyChanged("current_request_name");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string nested_exception {
            get {
                return this.nested_exceptionField;
            }
            set {
                this.nested_exceptionField = value;
                this.RaisePropertyChanged("nested_exception");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public DataServiceFaultSource_data_service source_data_service {
            get {
                return this.source_data_serviceField;
            }
            set {
                this.source_data_serviceField = value;
                this.RaisePropertyChanged("source_data_service");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=4)]
        public string ds_code {
            get {
                return this.ds_codeField;
            }
            set {
                this.ds_codeField = value;
                this.RaisePropertyChanged("ds_code");
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://ws.wso2.org/dataservice")]
    public partial class DataServiceFaultSource_data_service : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string locationField;
        
        private string default_namespaceField;
        
        private string descriptionField;
        
        private string data_service_nameField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string location {
            get {
                return this.locationField;
            }
            set {
                this.locationField = value;
                this.RaisePropertyChanged("location");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string default_namespace {
            get {
                return this.default_namespaceField;
            }
            set {
                this.default_namespaceField = value;
                this.RaisePropertyChanged("default_namespace");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public string description {
            get {
                return this.descriptionField;
            }
            set {
                this.descriptionField = value;
                this.RaisePropertyChanged("description");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=3)]
        public string data_service_name {
            get {
                return this.data_service_nameField;
            }
            set {
                this.data_service_nameField = value;
                this.RaisePropertyChanged("data_service_name");
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
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://pica.com/dss/clientes")]
    public partial class Cliente : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string cOD_CONF_OUTField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="integer", IsNullable=true, Order=0)]
        public string COD_CONF_OUT {
            get {
                return this.cOD_CONF_OUTField;
            }
            set {
                this.cOD_CONF_OUTField = value;
                this.RaisePropertyChanged("COD_CONF_OUT");
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
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://pica.com/dss/clientes", ConfigurationName="wsInsertaClientesDSReference.insertaClientesDSPortType")]
    public interface insertaClientesDSPortType {
        
        // CODEGEN: Generating message contract since the wrapper name (Elementos) of message wsInsertarClienteResponse does not match the default value (wsInsertarCliente)
        [System.ServiceModel.OperationContractAttribute(Action="urn:wsInsertarCliente", ReplyAction="urn:wsInsertarClienteResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(PICA_B2C.ServiceAgent.MainModule.wsInsertaClientesDSReference.DataServiceFault), Action="urn:wsInsertarClienteDataServiceFault", Name="DataServiceFault", Namespace="http://ws.wso2.org/dataservice")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        PICA_B2C.ServiceAgent.MainModule.wsInsertaClientesDSReference.wsInsertarClienteResponse wsInsertarCliente(PICA_B2C.ServiceAgent.MainModule.wsInsertaClientesDSReference.wsInsertarClienteRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="urn:wsInsertarCliente", ReplyAction="urn:wsInsertarClienteResponse")]
        System.Threading.Tasks.Task<PICA_B2C.ServiceAgent.MainModule.wsInsertaClientesDSReference.wsInsertarClienteResponse> wsInsertarClienteAsync(PICA_B2C.ServiceAgent.MainModule.wsInsertaClientesDSReference.wsInsertarClienteRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="wsInsertarCliente", WrapperNamespace="http://pica.com/dss/clientes", IsWrapped=true)]
    public partial class wsInsertarClienteRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://pica.com/dss/clientes", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string CUSTOMERCEDULA_IN;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://pica.com/dss/clientes", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string FNAME_IN;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://pica.com/dss/clientes", Order=2)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string LNAME_IN;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://pica.com/dss/clientes", Order=3)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string PHONENUMBER_IN;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://pica.com/dss/clientes", Order=4)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string EMAIL_IN;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://pica.com/dss/clientes", Order=5)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string PASSWORD_IN;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://pica.com/dss/clientes", Order=6)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string CREDITCARDTYPE_IN;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://pica.com/dss/clientes", Order=7)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string CREDITCARDNUMBER_IN;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://pica.com/dss/clientes", Order=8)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string STATUS_IN;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://pica.com/dss/clientes", Order=9)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string STREET_IN;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://pica.com/dss/clientes", Order=10)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string STATE_IN;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://pica.com/dss/clientes", Order=11)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string ZIP_IN;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://pica.com/dss/clientes", Order=12)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string COUNTRY_IN;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://pica.com/dss/clientes", Order=13)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string ADDRESTYPE_IN;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://pica.com/dss/clientes", Order=14)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string CITY_IN;
        
        public wsInsertarClienteRequest() {
        }
        
        public wsInsertarClienteRequest(string CUSTOMERCEDULA_IN, string FNAME_IN, string LNAME_IN, string PHONENUMBER_IN, string EMAIL_IN, string PASSWORD_IN, string CREDITCARDTYPE_IN, string CREDITCARDNUMBER_IN, string STATUS_IN, string STREET_IN, string STATE_IN, string ZIP_IN, string COUNTRY_IN, string ADDRESTYPE_IN, string CITY_IN) {
            this.CUSTOMERCEDULA_IN = CUSTOMERCEDULA_IN;
            this.FNAME_IN = FNAME_IN;
            this.LNAME_IN = LNAME_IN;
            this.PHONENUMBER_IN = PHONENUMBER_IN;
            this.EMAIL_IN = EMAIL_IN;
            this.PASSWORD_IN = PASSWORD_IN;
            this.CREDITCARDTYPE_IN = CREDITCARDTYPE_IN;
            this.CREDITCARDNUMBER_IN = CREDITCARDNUMBER_IN;
            this.STATUS_IN = STATUS_IN;
            this.STREET_IN = STREET_IN;
            this.STATE_IN = STATE_IN;
            this.ZIP_IN = ZIP_IN;
            this.COUNTRY_IN = COUNTRY_IN;
            this.ADDRESTYPE_IN = ADDRESTYPE_IN;
            this.CITY_IN = CITY_IN;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="Elementos", WrapperNamespace="http://pica.com/dss/clientes", IsWrapped=true)]
    public partial class wsInsertarClienteResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://pica.com/dss/clientes", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute("Cliente")]
        public PICA_B2C.ServiceAgent.MainModule.wsInsertaClientesDSReference.Cliente[] Cliente;
        
        public wsInsertarClienteResponse() {
        }
        
        public wsInsertarClienteResponse(PICA_B2C.ServiceAgent.MainModule.wsInsertaClientesDSReference.Cliente[] Cliente) {
            this.Cliente = Cliente;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface insertaClientesDSPortTypeChannel : PICA_B2C.ServiceAgent.MainModule.wsInsertaClientesDSReference.insertaClientesDSPortType, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class insertaClientesDSPortTypeClient : System.ServiceModel.ClientBase<PICA_B2C.ServiceAgent.MainModule.wsInsertaClientesDSReference.insertaClientesDSPortType>, PICA_B2C.ServiceAgent.MainModule.wsInsertaClientesDSReference.insertaClientesDSPortType {
        
        public insertaClientesDSPortTypeClient() {
        }
        
        public insertaClientesDSPortTypeClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public insertaClientesDSPortTypeClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public insertaClientesDSPortTypeClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public insertaClientesDSPortTypeClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        PICA_B2C.ServiceAgent.MainModule.wsInsertaClientesDSReference.wsInsertarClienteResponse PICA_B2C.ServiceAgent.MainModule.wsInsertaClientesDSReference.insertaClientesDSPortType.wsInsertarCliente(PICA_B2C.ServiceAgent.MainModule.wsInsertaClientesDSReference.wsInsertarClienteRequest request) {
            return base.Channel.wsInsertarCliente(request);
        }
        
        public PICA_B2C.ServiceAgent.MainModule.wsInsertaClientesDSReference.Cliente[] wsInsertarCliente(string CUSTOMERCEDULA_IN, string FNAME_IN, string LNAME_IN, string PHONENUMBER_IN, string EMAIL_IN, string PASSWORD_IN, string CREDITCARDTYPE_IN, string CREDITCARDNUMBER_IN, string STATUS_IN, string STREET_IN, string STATE_IN, string ZIP_IN, string COUNTRY_IN, string ADDRESTYPE_IN, string CITY_IN) {
            PICA_B2C.ServiceAgent.MainModule.wsInsertaClientesDSReference.wsInsertarClienteRequest inValue = new PICA_B2C.ServiceAgent.MainModule.wsInsertaClientesDSReference.wsInsertarClienteRequest();
            inValue.CUSTOMERCEDULA_IN = CUSTOMERCEDULA_IN;
            inValue.FNAME_IN = FNAME_IN;
            inValue.LNAME_IN = LNAME_IN;
            inValue.PHONENUMBER_IN = PHONENUMBER_IN;
            inValue.EMAIL_IN = EMAIL_IN;
            inValue.PASSWORD_IN = PASSWORD_IN;
            inValue.CREDITCARDTYPE_IN = CREDITCARDTYPE_IN;
            inValue.CREDITCARDNUMBER_IN = CREDITCARDNUMBER_IN;
            inValue.STATUS_IN = STATUS_IN;
            inValue.STREET_IN = STREET_IN;
            inValue.STATE_IN = STATE_IN;
            inValue.ZIP_IN = ZIP_IN;
            inValue.COUNTRY_IN = COUNTRY_IN;
            inValue.ADDRESTYPE_IN = ADDRESTYPE_IN;
            inValue.CITY_IN = CITY_IN;
            PICA_B2C.ServiceAgent.MainModule.wsInsertaClientesDSReference.wsInsertarClienteResponse retVal = ((PICA_B2C.ServiceAgent.MainModule.wsInsertaClientesDSReference.insertaClientesDSPortType)(this)).wsInsertarCliente(inValue);
            return retVal.Cliente;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<PICA_B2C.ServiceAgent.MainModule.wsInsertaClientesDSReference.wsInsertarClienteResponse> PICA_B2C.ServiceAgent.MainModule.wsInsertaClientesDSReference.insertaClientesDSPortType.wsInsertarClienteAsync(PICA_B2C.ServiceAgent.MainModule.wsInsertaClientesDSReference.wsInsertarClienteRequest request) {
            return base.Channel.wsInsertarClienteAsync(request);
        }
        
        public System.Threading.Tasks.Task<PICA_B2C.ServiceAgent.MainModule.wsInsertaClientesDSReference.wsInsertarClienteResponse> wsInsertarClienteAsync(string CUSTOMERCEDULA_IN, string FNAME_IN, string LNAME_IN, string PHONENUMBER_IN, string EMAIL_IN, string PASSWORD_IN, string CREDITCARDTYPE_IN, string CREDITCARDNUMBER_IN, string STATUS_IN, string STREET_IN, string STATE_IN, string ZIP_IN, string COUNTRY_IN, string ADDRESTYPE_IN, string CITY_IN) {
            PICA_B2C.ServiceAgent.MainModule.wsInsertaClientesDSReference.wsInsertarClienteRequest inValue = new PICA_B2C.ServiceAgent.MainModule.wsInsertaClientesDSReference.wsInsertarClienteRequest();
            inValue.CUSTOMERCEDULA_IN = CUSTOMERCEDULA_IN;
            inValue.FNAME_IN = FNAME_IN;
            inValue.LNAME_IN = LNAME_IN;
            inValue.PHONENUMBER_IN = PHONENUMBER_IN;
            inValue.EMAIL_IN = EMAIL_IN;
            inValue.PASSWORD_IN = PASSWORD_IN;
            inValue.CREDITCARDTYPE_IN = CREDITCARDTYPE_IN;
            inValue.CREDITCARDNUMBER_IN = CREDITCARDNUMBER_IN;
            inValue.STATUS_IN = STATUS_IN;
            inValue.STREET_IN = STREET_IN;
            inValue.STATE_IN = STATE_IN;
            inValue.ZIP_IN = ZIP_IN;
            inValue.COUNTRY_IN = COUNTRY_IN;
            inValue.ADDRESTYPE_IN = ADDRESTYPE_IN;
            inValue.CITY_IN = CITY_IN;
            return ((PICA_B2C.ServiceAgent.MainModule.wsInsertaClientesDSReference.insertaClientesDSPortType)(this)).wsInsertarClienteAsync(inValue);
        }
    }
}
