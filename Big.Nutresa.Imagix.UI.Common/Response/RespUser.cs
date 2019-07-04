using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Big.Nutresa.Imagix.UI.Common.Response
{
    // NOTA: El código generado puede requerir, como mínimo, .NET Framework 4.5 o .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://schemas.xmlsoap.org/soap/envelope/", IsNullable = false, ElementName = "Envelope")]
    public partial class RespUser
    {

        private RespUserBody bodyField;

        /// <remarks/>
        public RespUserBody Body
        {
            get
            {
                return this.bodyField;
            }
            set
            {
                this.bodyField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    [System.Xml.Serialization.XmlRootAttribute(IsNullable = false, ElementName = "EnvelopeBody")]
    public partial class RespUserBody
    {

        private item[] getUserPointsDataReturnField;
        private itemValueItemItem[] getUserDataReturnField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Namespace = "urn:DefaultNamespace")]
        [System.Xml.Serialization.XmlArrayItemAttribute("item", Namespace = "", IsNullable = false)]
        public item[] getUserPointsDataReturn
        {
            get
            {
                return this.getUserPointsDataReturnField;
            }
            set
            {
                this.getUserPointsDataReturnField = value;
            }
        }

        //<remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Namespace = "urn:DefaultNamespace")]
        [System.Xml.Serialization.XmlArrayItemAttribute("item", Namespace = "", IsNullable = false)]
        public itemValueItemItem[] getUserDataReturn
        {
            get
            {
                return this.getUserDataReturnField;
            }
            set
            {
                this.getUserDataReturnField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class item
    {

        private string keyField;

        private itemValue valueField;

        /// <remarks/>
        public string key
        {
            get
            {
                return this.keyField;
            }
            set
            {
                this.keyField = value;
            }
        }

        /// <remarks/>
        public itemValue value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class itemValue
    {

        private itemValueItem[] itemField;

        private string[] textField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("item")]
        public itemValueItem[] item
        {
            get
            {
                return this.itemField;
            }
            set
            {
                this.itemField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string[] Text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class itemValueItem
    {

        private byte keyField;

        private itemValueItemItem[] valueField;

        /// <remarks/>
        public byte key
        {
            get
            {
                return this.keyField;
            }
            set
            {
                this.keyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("item", IsNullable = false)]
        public itemValueItemItem[] value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class itemValueItemItem
    {

        private string keyField;

        private string valueField;

        /// <remarks/>
        public string key
        {
            get
            {
                return this.keyField;
            }
            set
            {
                this.keyField = value;
            }
        }

        /// <remarks/>
        public string value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:DefaultNamespace")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:DefaultNamespace", IsNullable = false)]
    public partial class getUserPointsDataReturn
    {

        private item[] itemField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("item", Namespace = "")]
        public item[] item
        {
            get
            {
                return this.itemField;
            }
            set
            {
                this.itemField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "urn:DefaultNamespace")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "urn:DefaultNamespace", IsNullable = false)]
    public partial class getUserDataReturn
    {

        private itemValueItemItem[] itemField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("item", Namespace = "")]
        public itemValueItemItem[] item
        {
            get
            {
                return this.itemField;
            }
            set
            {
                this.itemField = value;
            }
        }
    }
}
