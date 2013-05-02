﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.296
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace clientTest.ImageTransfertServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ImageInfo", Namespace="http://schemas.datacontract.org/2004/07/Octo_photo_wcf")]
    [System.SerializableAttribute()]
    public partial class ImageInfo : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private string IDField;
        
        private int idAlbumField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public string ID {
            get {
                return this.IDField;
            }
            set {
                if ((object.ReferenceEquals(this.IDField, value) != true)) {
                    this.IDField = value;
                    this.RaisePropertyChanged("ID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int idAlbum {
            get {
                return this.idAlbumField;
            }
            set {
                if ((this.idAlbumField.Equals(value) != true)) {
                    this.idAlbumField = value;
                    this.RaisePropertyChanged("idAlbum");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ImageTransfertServiceReference.IImageTransfert")]
    public interface IImageTransfert {
        
        // CODEGEN : La génération du contrat de message depuis l'opération UploadImage n'est ni RPC, ni encapsulée dans un document.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IImageTransfert/UploadImage", ReplyAction="http://tempuri.org/IImageTransfert/UploadImageResponse")]
        clientTest.ImageTransfertServiceReference.UploadImageResponse UploadImage(clientTest.ImageTransfertServiceReference.ImageUploadRequest request);
        
        // CODEGEN : La génération du contrat de message depuis le nom de wrapper (ImageDownloadRequest) du message ImageDownloadRequest ne correspond pas à la valeur par défaut (DownloadImage)
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IImageTransfert/DownloadImage", ReplyAction="http://tempuri.org/IImageTransfert/DownloadImageResponse")]
        clientTest.ImageTransfertServiceReference.ImageDownloadResponse DownloadImage(clientTest.ImageTransfertServiceReference.ImageDownloadRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ImageUploadRequest", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class ImageUploadRequest {
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://tempuri.org/")]
        public clientTest.ImageTransfertServiceReference.ImageInfo ImageInfo;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public System.IO.Stream ImageData;
        
        public ImageUploadRequest() {
        }
        
        public ImageUploadRequest(clientTest.ImageTransfertServiceReference.ImageInfo ImageInfo, System.IO.Stream ImageData) {
            this.ImageInfo = ImageInfo;
            this.ImageData = ImageData;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class UploadImageResponse {
        
        public UploadImageResponse() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ImageDownloadRequest", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class ImageDownloadRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public clientTest.ImageTransfertServiceReference.ImageInfo ImageInfo;
        
        public ImageDownloadRequest() {
        }
        
        public ImageDownloadRequest(clientTest.ImageTransfertServiceReference.ImageInfo ImageInfo) {
            this.ImageInfo = ImageInfo;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ImageDownloadResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class ImageDownloadResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public System.IO.Stream ImageData;
        
        public ImageDownloadResponse() {
        }
        
        public ImageDownloadResponse(System.IO.Stream ImageData) {
            this.ImageData = ImageData;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IImageTransfertChannel : clientTest.ImageTransfertServiceReference.IImageTransfert, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ImageTransfertClient : System.ServiceModel.ClientBase<clientTest.ImageTransfertServiceReference.IImageTransfert>, clientTest.ImageTransfertServiceReference.IImageTransfert {
        
        public ImageTransfertClient() {
        }
        
        public ImageTransfertClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ImageTransfertClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ImageTransfertClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ImageTransfertClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        clientTest.ImageTransfertServiceReference.UploadImageResponse clientTest.ImageTransfertServiceReference.IImageTransfert.UploadImage(clientTest.ImageTransfertServiceReference.ImageUploadRequest request) {
            return base.Channel.UploadImage(request);
        }
        
        public void UploadImage(clientTest.ImageTransfertServiceReference.ImageInfo ImageInfo, System.IO.Stream ImageData) {
            clientTest.ImageTransfertServiceReference.ImageUploadRequest inValue = new clientTest.ImageTransfertServiceReference.ImageUploadRequest();
            inValue.ImageInfo = ImageInfo;
            inValue.ImageData = ImageData;
            clientTest.ImageTransfertServiceReference.UploadImageResponse retVal = ((clientTest.ImageTransfertServiceReference.IImageTransfert)(this)).UploadImage(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        clientTest.ImageTransfertServiceReference.ImageDownloadResponse clientTest.ImageTransfertServiceReference.IImageTransfert.DownloadImage(clientTest.ImageTransfertServiceReference.ImageDownloadRequest request) {
            return base.Channel.DownloadImage(request);
        }
        
        public System.IO.Stream DownloadImage(clientTest.ImageTransfertServiceReference.ImageInfo ImageInfo) {
            clientTest.ImageTransfertServiceReference.ImageDownloadRequest inValue = new clientTest.ImageTransfertServiceReference.ImageDownloadRequest();
            inValue.ImageInfo = ImageInfo;
            clientTest.ImageTransfertServiceReference.ImageDownloadResponse retVal = ((clientTest.ImageTransfertServiceReference.IImageTransfert)(this)).DownloadImage(inValue);
            return retVal.ImageData;
        }
    }
}
