﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.296
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClientWPF.ImageTransfertServiceReference {
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
        ClientWPF.ImageTransfertServiceReference.UploadImageResponse UploadImage(ClientWPF.ImageTransfertServiceReference.ImageUploadRequest request);
        
        // CODEGEN : La génération du contrat de message depuis le nom de wrapper (ImageDownloadRequest) du message ImageDownloadRequest ne correspond pas à la valeur par défaut (DownloadImage)
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IImageTransfert/DownloadImage", ReplyAction="http://tempuri.org/IImageTransfert/DownloadImageResponse")]
        ClientWPF.ImageTransfertServiceReference.ImageDownloadResponse DownloadImage(ClientWPF.ImageTransfertServiceReference.ImageDownloadRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IImageTransfert/deleteUser", ReplyAction="http://tempuri.org/IImageTransfert/deleteUserResponse")]
        void deleteUser(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IImageTransfert/deleteAlbum", ReplyAction="http://tempuri.org/IImageTransfert/deleteAlbumResponse")]
        void deleteAlbum(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IImageTransfert/createAlbum", ReplyAction="http://tempuri.org/IImageTransfert/createAlbumResponse")]
        void createAlbum(string nom, int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IImageTransfert/deletePhotoInAlbum", ReplyAction="http://tempuri.org/IImageTransfert/deletePhotoInAlbumResponse")]
        void deletePhotoInAlbum(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IImageTransfert/deletePhoto", ReplyAction="http://tempuri.org/IImageTransfert/deletePhotoResponse")]
        void deletePhoto(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IImageTransfert/deletePhotoNom", ReplyAction="http://tempuri.org/IImageTransfert/deletePhotoNomResponse")]
        void deletePhotoNom(string nom);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IImageTransfert/getAlbum", ReplyAction="http://tempuri.org/IImageTransfert/getAlbumResponse")]
        string[] getAlbum(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IImageTransfert/getNomAlbum", ReplyAction="http://tempuri.org/IImageTransfert/getNomAlbumResponse")]
        string getNomAlbum(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IImageTransfert/getUserAlbum", ReplyAction="http://tempuri.org/IImageTransfert/getUserAlbumResponse")]
        int[] getUserAlbum(int id);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ImageUploadRequest", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class ImageUploadRequest {
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://tempuri.org/")]
        public ClientWPF.ImageTransfertServiceReference.ImageInfo ImageInfo;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public System.IO.Stream ImageData;
        
        public ImageUploadRequest() {
        }
        
        public ImageUploadRequest(ClientWPF.ImageTransfertServiceReference.ImageInfo ImageInfo, System.IO.Stream ImageData) {
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
        public ClientWPF.ImageTransfertServiceReference.ImageInfo ImageInfo;
        
        public ImageDownloadRequest() {
        }
        
        public ImageDownloadRequest(ClientWPF.ImageTransfertServiceReference.ImageInfo ImageInfo) {
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
    public interface IImageTransfertChannel : ClientWPF.ImageTransfertServiceReference.IImageTransfert, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ImageTransfertClient : System.ServiceModel.ClientBase<ClientWPF.ImageTransfertServiceReference.IImageTransfert>, ClientWPF.ImageTransfertServiceReference.IImageTransfert {
        
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
        ClientWPF.ImageTransfertServiceReference.UploadImageResponse ClientWPF.ImageTransfertServiceReference.IImageTransfert.UploadImage(ClientWPF.ImageTransfertServiceReference.ImageUploadRequest request) {
            return base.Channel.UploadImage(request);
        }
        
        public void UploadImage(ClientWPF.ImageTransfertServiceReference.ImageInfo ImageInfo, System.IO.Stream ImageData) {
            ClientWPF.ImageTransfertServiceReference.ImageUploadRequest inValue = new ClientWPF.ImageTransfertServiceReference.ImageUploadRequest();
            inValue.ImageInfo = ImageInfo;
            inValue.ImageData = ImageData;
            ClientWPF.ImageTransfertServiceReference.UploadImageResponse retVal = ((ClientWPF.ImageTransfertServiceReference.IImageTransfert)(this)).UploadImage(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ClientWPF.ImageTransfertServiceReference.ImageDownloadResponse ClientWPF.ImageTransfertServiceReference.IImageTransfert.DownloadImage(ClientWPF.ImageTransfertServiceReference.ImageDownloadRequest request) {
            return base.Channel.DownloadImage(request);
        }
        
        public System.IO.Stream DownloadImage(ClientWPF.ImageTransfertServiceReference.ImageInfo ImageInfo) {
            ClientWPF.ImageTransfertServiceReference.ImageDownloadRequest inValue = new ClientWPF.ImageTransfertServiceReference.ImageDownloadRequest();
            inValue.ImageInfo = ImageInfo;
            ClientWPF.ImageTransfertServiceReference.ImageDownloadResponse retVal = ((ClientWPF.ImageTransfertServiceReference.IImageTransfert)(this)).DownloadImage(inValue);
            return retVal.ImageData;
        }
        
        public void deleteUser(int id) {
            base.Channel.deleteUser(id);
        }
        
        public void deleteAlbum(int id) {
            base.Channel.deleteAlbum(id);
        }
        
        public void createAlbum(string nom, int id) {
            base.Channel.createAlbum(nom, id);
        }
        
        public void deletePhotoInAlbum(int id) {
            base.Channel.deletePhotoInAlbum(id);
        }
        
        public void deletePhoto(int id) {
            base.Channel.deletePhoto(id);
        }
        
        public void deletePhotoNom(string nom) {
            base.Channel.deletePhotoNom(nom);
        }
        
        public string[] getAlbum(int id) {
            return base.Channel.getAlbum(id);
        }
        
        public string getNomAlbum(int id) {
            return base.Channel.getNomAlbum(id);
        }
        
        public int[] getUserAlbum(int id) {
            return base.Channel.getUserAlbum(id);
        }
    }
}
