﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PICA_B2C.ServiceAgent.MainModule.wsProductsReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://servicioomsproductos.kallsonys.com/", ConfigurationName="wsProductsReference.consultarProductos")]
    public interface consultarProductos {
        
        // CODEGEN: Parameter 'return' requires additional schema information that cannot be captured using the parameter mode. The specific attribute is 'System.Xml.Serialization.XmlElementAttribute'.
        [System.ServiceModel.OperationContractAttribute(Action="http://servicioomsproductos.kallsonys.com/consultarProductos/consultarPRODUCTOS_L" +
            "ISTARequest", ReplyAction="http://servicioomsproductos.kallsonys.com/consultarProductos/consultarPRODUCTOS_L" +
            "ISTAResponse")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="return")]
        PICA_B2C.ServiceAgent.MainModule.wsProductsReference.consultarPRODUCTOS_LISTAResponse consultarPRODUCTOS_LISTA(PICA_B2C.ServiceAgent.MainModule.wsProductsReference.consultarPRODUCTOS_LISTARequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://servicioomsproductos.kallsonys.com/consultarProductos/consultarPRODUCTOS_L" +
            "ISTARequest", ReplyAction="http://servicioomsproductos.kallsonys.com/consultarProductos/consultarPRODUCTOS_L" +
            "ISTAResponse")]
        System.Threading.Tasks.Task<PICA_B2C.ServiceAgent.MainModule.wsProductsReference.consultarPRODUCTOS_LISTAResponse> consultarPRODUCTOS_LISTAAsync(PICA_B2C.ServiceAgent.MainModule.wsProductsReference.consultarPRODUCTOS_LISTARequest request);
        
        // CODEGEN: Parameter 'return' requires additional schema information that cannot be captured using the parameter mode. The specific attribute is 'System.Xml.Serialization.XmlElementAttribute'.
        [System.ServiceModel.OperationContractAttribute(Action="http://servicioomsproductos.kallsonys.com/consultarProductos/consultarPRODUCTOS_I" +
            "DRequest", ReplyAction="http://servicioomsproductos.kallsonys.com/consultarProductos/consultarPRODUCTOS_I" +
            "DResponse")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="return")]
        PICA_B2C.ServiceAgent.MainModule.wsProductsReference.consultarPRODUCTOS_IDResponse consultarPRODUCTOS_ID(PICA_B2C.ServiceAgent.MainModule.wsProductsReference.consultarPRODUCTOS_IDRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://servicioomsproductos.kallsonys.com/consultarProductos/consultarPRODUCTOS_I" +
            "DRequest", ReplyAction="http://servicioomsproductos.kallsonys.com/consultarProductos/consultarPRODUCTOS_I" +
            "DResponse")]
        System.Threading.Tasks.Task<PICA_B2C.ServiceAgent.MainModule.wsProductsReference.consultarPRODUCTOS_IDResponse> consultarPRODUCTOS_IDAsync(PICA_B2C.ServiceAgent.MainModule.wsProductsReference.consultarPRODUCTOS_IDRequest request);
        
        // CODEGEN: Parameter 'return' requires additional schema information that cannot be captured using the parameter mode. The specific attribute is 'System.Xml.Serialization.XmlElementAttribute'.
        [System.ServiceModel.OperationContractAttribute(Action="http://servicioomsproductos.kallsonys.com/consultarProductos/consultarPRODUCTOS_N" +
            "OMBRERequest", ReplyAction="http://servicioomsproductos.kallsonys.com/consultarProductos/consultarPRODUCTOS_N" +
            "OMBREResponse")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="return")]
        PICA_B2C.ServiceAgent.MainModule.wsProductsReference.consultarPRODUCTOS_NOMBREResponse consultarPRODUCTOS_NOMBRE(PICA_B2C.ServiceAgent.MainModule.wsProductsReference.consultarPRODUCTOS_NOMBRERequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://servicioomsproductos.kallsonys.com/consultarProductos/consultarPRODUCTOS_N" +
            "OMBRERequest", ReplyAction="http://servicioomsproductos.kallsonys.com/consultarProductos/consultarPRODUCTOS_N" +
            "OMBREResponse")]
        System.Threading.Tasks.Task<PICA_B2C.ServiceAgent.MainModule.wsProductsReference.consultarPRODUCTOS_NOMBREResponse> consultarPRODUCTOS_NOMBREAsync(PICA_B2C.ServiceAgent.MainModule.wsProductsReference.consultarPRODUCTOS_NOMBRERequest request);
        
        // CODEGEN: Parameter 'return' requires additional schema information that cannot be captured using the parameter mode. The specific attribute is 'System.Xml.Serialization.XmlElementAttribute'.
        [System.ServiceModel.OperationContractAttribute(Action="http://servicioomsproductos.kallsonys.com/consultarProductos/consultarPRODUCTOS_D" +
            "ESCRIPCIONRequest", ReplyAction="http://servicioomsproductos.kallsonys.com/consultarProductos/consultarPRODUCTOS_D" +
            "ESCRIPCIONResponse")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="return")]
        PICA_B2C.ServiceAgent.MainModule.wsProductsReference.consultarPRODUCTOS_DESCRIPCIONResponse consultarPRODUCTOS_DESCRIPCION(PICA_B2C.ServiceAgent.MainModule.wsProductsReference.consultarPRODUCTOS_DESCRIPCIONRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://servicioomsproductos.kallsonys.com/consultarProductos/consultarPRODUCTOS_D" +
            "ESCRIPCIONRequest", ReplyAction="http://servicioomsproductos.kallsonys.com/consultarProductos/consultarPRODUCTOS_D" +
            "ESCRIPCIONResponse")]
        System.Threading.Tasks.Task<PICA_B2C.ServiceAgent.MainModule.wsProductsReference.consultarPRODUCTOS_DESCRIPCIONResponse> consultarPRODUCTOS_DESCRIPCIONAsync(PICA_B2C.ServiceAgent.MainModule.wsProductsReference.consultarPRODUCTOS_DESCRIPCIONRequest request);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://servicioomsproductos.kallsonys.com/")]
    public partial class producto : object, System.ComponentModel.INotifyPropertyChanged {
        
        private int cANTIDAD_REGISTROSField;
        
        private string cATEGORIAField;
        
        private string dESCRIPCIONField;
        
        private string fABRICANTEField;
        
        private int idField;
        
        private string iMAGEN_URLField;
        
        private string nOMBREField;
        
        private int pRECIO_LISTAField;
        
        private int pRODUCTO_IDField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=0)]
        public int CANTIDAD_REGISTROS {
            get {
                return this.cANTIDAD_REGISTROSField;
            }
            set {
                this.cANTIDAD_REGISTROSField = value;
                this.RaisePropertyChanged("CANTIDAD_REGISTROS");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=1)]
        public string CATEGORIA {
            get {
                return this.cATEGORIAField;
            }
            set {
                this.cATEGORIAField = value;
                this.RaisePropertyChanged("CATEGORIA");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=2)]
        public string DESCRIPCION {
            get {
                return this.dESCRIPCIONField;
            }
            set {
                this.dESCRIPCIONField = value;
                this.RaisePropertyChanged("DESCRIPCION");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=3)]
        public string FABRICANTE {
            get {
                return this.fABRICANTEField;
            }
            set {
                this.fABRICANTEField = value;
                this.RaisePropertyChanged("FABRICANTE");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=4)]
        public int ID {
            get {
                return this.idField;
            }
            set {
                this.idField = value;
                this.RaisePropertyChanged("ID");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=5)]
        public string IMAGEN_URL {
            get {
                return this.iMAGEN_URLField;
            }
            set {
                this.iMAGEN_URLField = value;
                this.RaisePropertyChanged("IMAGEN_URL");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=6)]
        public string NOMBRE {
            get {
                return this.nOMBREField;
            }
            set {
                this.nOMBREField = value;
                this.RaisePropertyChanged("NOMBRE");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=7)]
        public int PRECIO_LISTA {
            get {
                return this.pRECIO_LISTAField;
            }
            set {
                this.pRECIO_LISTAField = value;
                this.RaisePropertyChanged("PRECIO_LISTA");
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified, Order=8)]
        public int PRODUCTO_ID {
            get {
                return this.pRODUCTO_IDField;
            }
            set {
                this.pRODUCTO_IDField = value;
                this.RaisePropertyChanged("PRODUCTO_ID");
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="consultarPRODUCTOS_LISTA", WrapperNamespace="http://servicioomsproductos.kallsonys.com/", IsWrapped=true)]
    public partial class consultarPRODUCTOS_LISTARequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://servicioomsproductos.kallsonys.com/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int NUMERO_PAGINA;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://servicioomsproductos.kallsonys.com/", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int TAMANO_PAGINA;
        
        public consultarPRODUCTOS_LISTARequest() {
        }
        
        public consultarPRODUCTOS_LISTARequest(int NUMERO_PAGINA, int TAMANO_PAGINA) {
            this.NUMERO_PAGINA = NUMERO_PAGINA;
            this.TAMANO_PAGINA = TAMANO_PAGINA;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="consultarPRODUCTOS_LISTAResponse", WrapperNamespace="http://servicioomsproductos.kallsonys.com/", IsWrapped=true)]
    public partial class consultarPRODUCTOS_LISTAResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://servicioomsproductos.kallsonys.com/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public PICA_B2C.ServiceAgent.MainModule.wsProductsReference.producto[] @return;
        
        public consultarPRODUCTOS_LISTAResponse() {
        }
        
        public consultarPRODUCTOS_LISTAResponse(PICA_B2C.ServiceAgent.MainModule.wsProductsReference.producto[] @return) {
            this.@return = @return;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="consultarPRODUCTOS_ID", WrapperNamespace="http://servicioomsproductos.kallsonys.com/", IsWrapped=true)]
    public partial class consultarPRODUCTOS_IDRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://servicioomsproductos.kallsonys.com/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int ID;
        
        public consultarPRODUCTOS_IDRequest() {
        }
        
        public consultarPRODUCTOS_IDRequest(int ID) {
            this.ID = ID;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="consultarPRODUCTOS_IDResponse", WrapperNamespace="http://servicioomsproductos.kallsonys.com/", IsWrapped=true)]
    public partial class consultarPRODUCTOS_IDResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://servicioomsproductos.kallsonys.com/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public PICA_B2C.ServiceAgent.MainModule.wsProductsReference.producto[] @return;
        
        public consultarPRODUCTOS_IDResponse() {
        }
        
        public consultarPRODUCTOS_IDResponse(PICA_B2C.ServiceAgent.MainModule.wsProductsReference.producto[] @return) {
            this.@return = @return;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="consultarPRODUCTOS_NOMBRE", WrapperNamespace="http://servicioomsproductos.kallsonys.com/", IsWrapped=true)]
    public partial class consultarPRODUCTOS_NOMBRERequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://servicioomsproductos.kallsonys.com/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string NOMBRE;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://servicioomsproductos.kallsonys.com/", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int NUMERO_PAGINA;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://servicioomsproductos.kallsonys.com/", Order=2)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int TAMANO_PAGINA;
        
        public consultarPRODUCTOS_NOMBRERequest() {
        }
        
        public consultarPRODUCTOS_NOMBRERequest(string NOMBRE, int NUMERO_PAGINA, int TAMANO_PAGINA) {
            this.NOMBRE = NOMBRE;
            this.NUMERO_PAGINA = NUMERO_PAGINA;
            this.TAMANO_PAGINA = TAMANO_PAGINA;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="consultarPRODUCTOS_NOMBREResponse", WrapperNamespace="http://servicioomsproductos.kallsonys.com/", IsWrapped=true)]
    public partial class consultarPRODUCTOS_NOMBREResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://servicioomsproductos.kallsonys.com/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public PICA_B2C.ServiceAgent.MainModule.wsProductsReference.producto[] @return;
        
        public consultarPRODUCTOS_NOMBREResponse() {
        }
        
        public consultarPRODUCTOS_NOMBREResponse(PICA_B2C.ServiceAgent.MainModule.wsProductsReference.producto[] @return) {
            this.@return = @return;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="consultarPRODUCTOS_DESCRIPCION", WrapperNamespace="http://servicioomsproductos.kallsonys.com/", IsWrapped=true)]
    public partial class consultarPRODUCTOS_DESCRIPCIONRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://servicioomsproductos.kallsonys.com/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string DESCRIPCION;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://servicioomsproductos.kallsonys.com/", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int NUMERO_PAGINA;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://servicioomsproductos.kallsonys.com/", Order=2)]
        [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public int TAMANO_PAGINA;
        
        public consultarPRODUCTOS_DESCRIPCIONRequest() {
        }
        
        public consultarPRODUCTOS_DESCRIPCIONRequest(string DESCRIPCION, int NUMERO_PAGINA, int TAMANO_PAGINA) {
            this.DESCRIPCION = DESCRIPCION;
            this.NUMERO_PAGINA = NUMERO_PAGINA;
            this.TAMANO_PAGINA = TAMANO_PAGINA;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="consultarPRODUCTOS_DESCRIPCIONResponse", WrapperNamespace="http://servicioomsproductos.kallsonys.com/", IsWrapped=true)]
    public partial class consultarPRODUCTOS_DESCRIPCIONResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://servicioomsproductos.kallsonys.com/", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute("return", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public PICA_B2C.ServiceAgent.MainModule.wsProductsReference.producto[] @return;
        
        public consultarPRODUCTOS_DESCRIPCIONResponse() {
        }
        
        public consultarPRODUCTOS_DESCRIPCIONResponse(PICA_B2C.ServiceAgent.MainModule.wsProductsReference.producto[] @return) {
            this.@return = @return;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface consultarProductosChannel : PICA_B2C.ServiceAgent.MainModule.wsProductsReference.consultarProductos, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class consultarProductosClient : System.ServiceModel.ClientBase<PICA_B2C.ServiceAgent.MainModule.wsProductsReference.consultarProductos>, PICA_B2C.ServiceAgent.MainModule.wsProductsReference.consultarProductos {
        
        public consultarProductosClient() {
        }
        
        public consultarProductosClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public consultarProductosClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public consultarProductosClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public consultarProductosClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        PICA_B2C.ServiceAgent.MainModule.wsProductsReference.consultarPRODUCTOS_LISTAResponse PICA_B2C.ServiceAgent.MainModule.wsProductsReference.consultarProductos.consultarPRODUCTOS_LISTA(PICA_B2C.ServiceAgent.MainModule.wsProductsReference.consultarPRODUCTOS_LISTARequest request) {
            return base.Channel.consultarPRODUCTOS_LISTA(request);
        }
        
        public PICA_B2C.ServiceAgent.MainModule.wsProductsReference.producto[] consultarPRODUCTOS_LISTA(int NUMERO_PAGINA, int TAMANO_PAGINA) {
            PICA_B2C.ServiceAgent.MainModule.wsProductsReference.consultarPRODUCTOS_LISTARequest inValue = new PICA_B2C.ServiceAgent.MainModule.wsProductsReference.consultarPRODUCTOS_LISTARequest();
            inValue.NUMERO_PAGINA = NUMERO_PAGINA;
            inValue.TAMANO_PAGINA = TAMANO_PAGINA;
            PICA_B2C.ServiceAgent.MainModule.wsProductsReference.consultarPRODUCTOS_LISTAResponse retVal = ((PICA_B2C.ServiceAgent.MainModule.wsProductsReference.consultarProductos)(this)).consultarPRODUCTOS_LISTA(inValue);
            return retVal.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<PICA_B2C.ServiceAgent.MainModule.wsProductsReference.consultarPRODUCTOS_LISTAResponse> PICA_B2C.ServiceAgent.MainModule.wsProductsReference.consultarProductos.consultarPRODUCTOS_LISTAAsync(PICA_B2C.ServiceAgent.MainModule.wsProductsReference.consultarPRODUCTOS_LISTARequest request) {
            return base.Channel.consultarPRODUCTOS_LISTAAsync(request);
        }
        
        public System.Threading.Tasks.Task<PICA_B2C.ServiceAgent.MainModule.wsProductsReference.consultarPRODUCTOS_LISTAResponse> consultarPRODUCTOS_LISTAAsync(int NUMERO_PAGINA, int TAMANO_PAGINA) {
            PICA_B2C.ServiceAgent.MainModule.wsProductsReference.consultarPRODUCTOS_LISTARequest inValue = new PICA_B2C.ServiceAgent.MainModule.wsProductsReference.consultarPRODUCTOS_LISTARequest();
            inValue.NUMERO_PAGINA = NUMERO_PAGINA;
            inValue.TAMANO_PAGINA = TAMANO_PAGINA;
            return ((PICA_B2C.ServiceAgent.MainModule.wsProductsReference.consultarProductos)(this)).consultarPRODUCTOS_LISTAAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        PICA_B2C.ServiceAgent.MainModule.wsProductsReference.consultarPRODUCTOS_IDResponse PICA_B2C.ServiceAgent.MainModule.wsProductsReference.consultarProductos.consultarPRODUCTOS_ID(PICA_B2C.ServiceAgent.MainModule.wsProductsReference.consultarPRODUCTOS_IDRequest request) {
            return base.Channel.consultarPRODUCTOS_ID(request);
        }
        
        public PICA_B2C.ServiceAgent.MainModule.wsProductsReference.producto[] consultarPRODUCTOS_ID(int ID) {
            PICA_B2C.ServiceAgent.MainModule.wsProductsReference.consultarPRODUCTOS_IDRequest inValue = new PICA_B2C.ServiceAgent.MainModule.wsProductsReference.consultarPRODUCTOS_IDRequest();
            inValue.ID = ID;
            PICA_B2C.ServiceAgent.MainModule.wsProductsReference.consultarPRODUCTOS_IDResponse retVal = ((PICA_B2C.ServiceAgent.MainModule.wsProductsReference.consultarProductos)(this)).consultarPRODUCTOS_ID(inValue);
            return retVal.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<PICA_B2C.ServiceAgent.MainModule.wsProductsReference.consultarPRODUCTOS_IDResponse> PICA_B2C.ServiceAgent.MainModule.wsProductsReference.consultarProductos.consultarPRODUCTOS_IDAsync(PICA_B2C.ServiceAgent.MainModule.wsProductsReference.consultarPRODUCTOS_IDRequest request) {
            return base.Channel.consultarPRODUCTOS_IDAsync(request);
        }
        
        public System.Threading.Tasks.Task<PICA_B2C.ServiceAgent.MainModule.wsProductsReference.consultarPRODUCTOS_IDResponse> consultarPRODUCTOS_IDAsync(int ID) {
            PICA_B2C.ServiceAgent.MainModule.wsProductsReference.consultarPRODUCTOS_IDRequest inValue = new PICA_B2C.ServiceAgent.MainModule.wsProductsReference.consultarPRODUCTOS_IDRequest();
            inValue.ID = ID;
            return ((PICA_B2C.ServiceAgent.MainModule.wsProductsReference.consultarProductos)(this)).consultarPRODUCTOS_IDAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        PICA_B2C.ServiceAgent.MainModule.wsProductsReference.consultarPRODUCTOS_NOMBREResponse PICA_B2C.ServiceAgent.MainModule.wsProductsReference.consultarProductos.consultarPRODUCTOS_NOMBRE(PICA_B2C.ServiceAgent.MainModule.wsProductsReference.consultarPRODUCTOS_NOMBRERequest request) {
            return base.Channel.consultarPRODUCTOS_NOMBRE(request);
        }
        
        public PICA_B2C.ServiceAgent.MainModule.wsProductsReference.producto[] consultarPRODUCTOS_NOMBRE(string NOMBRE, int NUMERO_PAGINA, int TAMANO_PAGINA) {
            PICA_B2C.ServiceAgent.MainModule.wsProductsReference.consultarPRODUCTOS_NOMBRERequest inValue = new PICA_B2C.ServiceAgent.MainModule.wsProductsReference.consultarPRODUCTOS_NOMBRERequest();
            inValue.NOMBRE = NOMBRE;
            inValue.NUMERO_PAGINA = NUMERO_PAGINA;
            inValue.TAMANO_PAGINA = TAMANO_PAGINA;
            PICA_B2C.ServiceAgent.MainModule.wsProductsReference.consultarPRODUCTOS_NOMBREResponse retVal = ((PICA_B2C.ServiceAgent.MainModule.wsProductsReference.consultarProductos)(this)).consultarPRODUCTOS_NOMBRE(inValue);
            return retVal.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<PICA_B2C.ServiceAgent.MainModule.wsProductsReference.consultarPRODUCTOS_NOMBREResponse> PICA_B2C.ServiceAgent.MainModule.wsProductsReference.consultarProductos.consultarPRODUCTOS_NOMBREAsync(PICA_B2C.ServiceAgent.MainModule.wsProductsReference.consultarPRODUCTOS_NOMBRERequest request) {
            return base.Channel.consultarPRODUCTOS_NOMBREAsync(request);
        }
        
        public System.Threading.Tasks.Task<PICA_B2C.ServiceAgent.MainModule.wsProductsReference.consultarPRODUCTOS_NOMBREResponse> consultarPRODUCTOS_NOMBREAsync(string NOMBRE, int NUMERO_PAGINA, int TAMANO_PAGINA) {
            PICA_B2C.ServiceAgent.MainModule.wsProductsReference.consultarPRODUCTOS_NOMBRERequest inValue = new PICA_B2C.ServiceAgent.MainModule.wsProductsReference.consultarPRODUCTOS_NOMBRERequest();
            inValue.NOMBRE = NOMBRE;
            inValue.NUMERO_PAGINA = NUMERO_PAGINA;
            inValue.TAMANO_PAGINA = TAMANO_PAGINA;
            return ((PICA_B2C.ServiceAgent.MainModule.wsProductsReference.consultarProductos)(this)).consultarPRODUCTOS_NOMBREAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        PICA_B2C.ServiceAgent.MainModule.wsProductsReference.consultarPRODUCTOS_DESCRIPCIONResponse PICA_B2C.ServiceAgent.MainModule.wsProductsReference.consultarProductos.consultarPRODUCTOS_DESCRIPCION(PICA_B2C.ServiceAgent.MainModule.wsProductsReference.consultarPRODUCTOS_DESCRIPCIONRequest request) {
            return base.Channel.consultarPRODUCTOS_DESCRIPCION(request);
        }
        
        public PICA_B2C.ServiceAgent.MainModule.wsProductsReference.producto[] consultarPRODUCTOS_DESCRIPCION(string DESCRIPCION, int NUMERO_PAGINA, int TAMANO_PAGINA) {
            PICA_B2C.ServiceAgent.MainModule.wsProductsReference.consultarPRODUCTOS_DESCRIPCIONRequest inValue = new PICA_B2C.ServiceAgent.MainModule.wsProductsReference.consultarPRODUCTOS_DESCRIPCIONRequest();
            inValue.DESCRIPCION = DESCRIPCION;
            inValue.NUMERO_PAGINA = NUMERO_PAGINA;
            inValue.TAMANO_PAGINA = TAMANO_PAGINA;
            PICA_B2C.ServiceAgent.MainModule.wsProductsReference.consultarPRODUCTOS_DESCRIPCIONResponse retVal = ((PICA_B2C.ServiceAgent.MainModule.wsProductsReference.consultarProductos)(this)).consultarPRODUCTOS_DESCRIPCION(inValue);
            return retVal.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<PICA_B2C.ServiceAgent.MainModule.wsProductsReference.consultarPRODUCTOS_DESCRIPCIONResponse> PICA_B2C.ServiceAgent.MainModule.wsProductsReference.consultarProductos.consultarPRODUCTOS_DESCRIPCIONAsync(PICA_B2C.ServiceAgent.MainModule.wsProductsReference.consultarPRODUCTOS_DESCRIPCIONRequest request) {
            return base.Channel.consultarPRODUCTOS_DESCRIPCIONAsync(request);
        }
        
        public System.Threading.Tasks.Task<PICA_B2C.ServiceAgent.MainModule.wsProductsReference.consultarPRODUCTOS_DESCRIPCIONResponse> consultarPRODUCTOS_DESCRIPCIONAsync(string DESCRIPCION, int NUMERO_PAGINA, int TAMANO_PAGINA) {
            PICA_B2C.ServiceAgent.MainModule.wsProductsReference.consultarPRODUCTOS_DESCRIPCIONRequest inValue = new PICA_B2C.ServiceAgent.MainModule.wsProductsReference.consultarPRODUCTOS_DESCRIPCIONRequest();
            inValue.DESCRIPCION = DESCRIPCION;
            inValue.NUMERO_PAGINA = NUMERO_PAGINA;
            inValue.TAMANO_PAGINA = TAMANO_PAGINA;
            return ((PICA_B2C.ServiceAgent.MainModule.wsProductsReference.consultarProductos)(this)).consultarPRODUCTOS_DESCRIPCIONAsync(inValue);
        }
    }
}
