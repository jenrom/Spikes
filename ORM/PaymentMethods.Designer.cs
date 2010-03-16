﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Data.EntityClient;
using System.ComponentModel;
using System.Xml.Serialization;
using System.Runtime.Serialization;

[assembly: EdmSchemaAttribute()]
#region EDM Relationship Metadata

[assembly: EdmRelationshipAttribute("PaymentsModel", "paymentMethodAssignedTo", "Customers", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(OrmSpikes.Customer), "PaymentMethod", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(OrmSpikes.PaymentMethod))]
[assembly: EdmRelationshipAttribute("PaymentsModel", "usedPaymentMethodId", "PaymentMethod", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, typeof(OrmSpikes.PaymentMethod), "Customers", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(OrmSpikes.Customer))]
[assembly: EdmRelationshipAttribute("PaymentsModel", "contactAdress", "Contacts", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(OrmSpikes.Contact), "Adressses", System.Data.Metadata.Edm.RelationshipMultiplicity.ZeroOrOne, typeof(OrmSpikes.Address))]
[assembly: EdmRelationshipAttribute("PaymentsModel", "serviceToCustomer", "Customer", System.Data.Metadata.Edm.RelationshipMultiplicity.One, typeof(OrmSpikes.Customer), "Services", System.Data.Metadata.Edm.RelationshipMultiplicity.Many, typeof(OrmSpikes.Service))]

#endregion

namespace OrmSpikes
{
    #region Contexts
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    public partial class Entities : ObjectContext
    {
        #region Constructors
    
        /// <summary>
        /// Initializes a new Entities object using the connection string found in the 'Entities' section of the application configuration file.
        /// </summary>
        public Entities() : base("name=Entities", "Entities")
        {
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new Entities object.
        /// </summary>
        public Entities(string connectionString) : base(connectionString, "Entities")
        {
            OnContextCreated();
        }
    
        /// <summary>
        /// Initialize a new Entities object.
        /// </summary>
        public Entities(EntityConnection connection) : base(connection, "Entities")
        {
            OnContextCreated();
        }
    
        #endregion
    
        #region Partial Methods
    
        partial void OnContextCreated();
    
        #endregion
    
        #region ObjectSet Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<PaymentMethod> PaymentMethodSet
        {
            get
            {
                if ((_PaymentMethodSet == null))
                {
                    _PaymentMethodSet = base.CreateObjectSet<PaymentMethod>("PaymentMethodSet");
                }
                return _PaymentMethodSet;
            }
        }
        private ObjectSet<PaymentMethod> _PaymentMethodSet;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Customer> CustomerSet
        {
            get
            {
                if ((_CustomerSet == null))
                {
                    _CustomerSet = base.CreateObjectSet<Customer>("CustomerSet");
                }
                return _CustomerSet;
            }
        }
        private ObjectSet<Customer> _CustomerSet;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Address> AddressSet
        {
            get
            {
                if ((_AddressSet == null))
                {
                    _AddressSet = base.CreateObjectSet<Address>("AddressSet");
                }
                return _AddressSet;
            }
        }
        private ObjectSet<Address> _AddressSet;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Contact> ContactSet
        {
            get
            {
                if ((_ContactSet == null))
                {
                    _ContactSet = base.CreateObjectSet<Contact>("ContactSet");
                }
                return _ContactSet;
            }
        }
        private ObjectSet<Contact> _ContactSet;
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        public ObjectSet<Service> ServiceSet
        {
            get
            {
                if ((_ServiceSet == null))
                {
                    _ServiceSet = base.CreateObjectSet<Service>("ServiceSet");
                }
                return _ServiceSet;
            }
        }
        private ObjectSet<Service> _ServiceSet;

        #endregion
        #region AddTo Methods
    
        /// <summary>
        /// Deprecated Method for adding a new object to the PaymentMethodSet EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToPaymentMethodSet(PaymentMethod paymentMethod)
        {
            base.AddObject("PaymentMethodSet", paymentMethod);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the CustomerSet EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToCustomerSet(Customer customer)
        {
            base.AddObject("CustomerSet", customer);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the AddressSet EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToAddressSet(Address address)
        {
            base.AddObject("AddressSet", address);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the ContactSet EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToContactSet(Contact contact)
        {
            base.AddObject("ContactSet", contact);
        }
    
        /// <summary>
        /// Deprecated Method for adding a new object to the ServiceSet EntitySet. Consider using the .Add method of the associated ObjectSet&lt;T&gt; property instead.
        /// </summary>
        public void AddToServiceSet(Service service)
        {
            base.AddObject("ServiceSet", service);
        }

        #endregion
    }
    

    #endregion
    
    #region Entities
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="PaymentsModel", Name="Address")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Address : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Address object.
        /// </summary>
        /// <param name="id">Initial value of the Id property.</param>
        public static Address CreateAddress(global::System.Int32 id)
        {
            Address address = new Address();
            address.Id = id;
            return address;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id != value)
                {
                    OnIdChanging(value);
                    ReportPropertyChanging("Id");
                    _Id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Id");
                    OnIdChanged();
                }
            }
        }
        private global::System.Int32 _Id;
        partial void OnIdChanging(global::System.Int32 value);
        partial void OnIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Street
        {
            get
            {
                return _Street;
            }
            set
            {
                OnStreetChanging(value);
                ReportPropertyChanging("Street");
                _Street = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Street");
                OnStreetChanged();
            }
        }
        private global::System.String _Street;
        partial void OnStreetChanging(global::System.String value);
        partial void OnStreetChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PaymentsModel", "contactAdress", "Contacts")]
        public Contact Contact
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Contact>("PaymentsModel.contactAdress", "Contacts").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Contact>("PaymentsModel.contactAdress", "Contacts").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Contact> ContactReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Contact>("PaymentsModel.contactAdress", "Contacts");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Contact>("PaymentsModel.contactAdress", "Contacts", value);
                }
            }
        }

        #endregion
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="PaymentsModel", Name="Contact")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Contact : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Contact object.
        /// </summary>
        /// <param name="id">Initial value of the Id property.</param>
        public static Contact CreateContact(global::System.Int32 id)
        {
            Contact contact = new Contact();
            contact.Id = id;
            return contact;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id != value)
                {
                    OnIdChanging(value);
                    ReportPropertyChanging("Id");
                    _Id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Id");
                    OnIdChanged();
                }
            }
        }
        private global::System.Int32 _Id;
        partial void OnIdChanging(global::System.Int32 value);
        partial void OnIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String Name
        {
            get
            {
                return _Name;
            }
            set
            {
                OnNameChanging(value);
                ReportPropertyChanging("Name");
                _Name = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("Name");
                OnNameChanged();
            }
        }
        private global::System.String _Name;
        partial void OnNameChanging(global::System.String value);
        partial void OnNameChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PaymentsModel", "contactAdress", "Adressses")]
        public Address Address
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Address>("PaymentsModel.contactAdress", "Adressses").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Address>("PaymentsModel.contactAdress", "Adressses").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Address> AddressReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Address>("PaymentsModel.contactAdress", "Adressses");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Address>("PaymentsModel.contactAdress", "Adressses", value);
                }
            }
        }

        #endregion
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="PaymentsModel", Name="CreditCardPaymentMethod")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class CreditCardPaymentMethod : PaymentMethod
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new CreditCardPaymentMethod object.
        /// </summary>
        /// <param name="id">Initial value of the id property.</param>
        /// <param name="status">Initial value of the status property.</param>
        /// <param name="registrationDate">Initial value of the registrationDate property.</param>
        public static CreditCardPaymentMethod CreateCreditCardPaymentMethod(global::System.Int32 id, global::System.Byte status, global::System.DateTime registrationDate)
        {
            CreditCardPaymentMethod creditCardPaymentMethod = new CreditCardPaymentMethod();
            creditCardPaymentMethod.id = id;
            creditCardPaymentMethod.status = status;
            creditCardPaymentMethod.registrationDate = registrationDate;
            return creditCardPaymentMethod;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String cardType
        {
            get
            {
                return _cardType;
            }
            set
            {
                OncardTypeChanging(value);
                ReportPropertyChanging("cardType");
                _cardType = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("cardType");
                OncardTypeChanged();
            }
        }
        private global::System.String _cardType;
        partial void OncardTypeChanging(global::System.String value);
        partial void OncardTypeChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String cardHolderName
        {
            get
            {
                return _cardHolderName;
            }
            set
            {
                OncardHolderNameChanging(value);
                ReportPropertyChanging("cardHolderName");
                _cardHolderName = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("cardHolderName");
                OncardHolderNameChanged();
            }
        }
        private global::System.String _cardHolderName;
        partial void OncardHolderNameChanging(global::System.String value);
        partial void OncardHolderNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String cardNumber
        {
            get
            {
                return _cardNumber;
            }
            set
            {
                OncardNumberChanging(value);
                ReportPropertyChanging("cardNumber");
                _cardNumber = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("cardNumber");
                OncardNumberChanged();
            }
        }
        private global::System.String _cardNumber;
        partial void OncardNumberChanging(global::System.String value);
        partial void OncardNumberChanged();

        #endregion
    
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="PaymentsModel", Name="Customer")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Customer : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Customer object.
        /// </summary>
        /// <param name="id">Initial value of the id property.</param>
        /// <param name="name">Initial value of the name property.</param>
        public static Customer CreateCustomer(global::System.Int32 id, global::System.String name)
        {
            Customer customer = new Customer();
            customer.id = id;
            customer.name = name;
            return customer;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 id
        {
            get
            {
                return _id;
            }
            set
            {
                if (_id != value)
                {
                    OnidChanging(value);
                    ReportPropertyChanging("id");
                    _id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("id");
                    OnidChanged();
                }
            }
        }
        private global::System.Int32 _id;
        partial void OnidChanging(global::System.Int32 value);
        partial void OnidChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String name
        {
            get
            {
                return _name;
            }
            set
            {
                OnnameChanging(value);
                ReportPropertyChanging("name");
                _name = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("name");
                OnnameChanged();
            }
        }
        private global::System.String _name;
        partial void OnnameChanging(global::System.String value);
        partial void OnnameChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PaymentsModel", "usedPaymentMethodId", "PaymentMethod")]
        public PaymentMethod UsedPaymentMethod
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<PaymentMethod>("PaymentsModel.usedPaymentMethodId", "PaymentMethod").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<PaymentMethod>("PaymentsModel.usedPaymentMethodId", "PaymentMethod").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<PaymentMethod> UsedPaymentMethodReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<PaymentMethod>("PaymentsModel.usedPaymentMethodId", "PaymentMethod");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<PaymentMethod>("PaymentsModel.usedPaymentMethodId", "PaymentMethod", value);
                }
            }
        }
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PaymentsModel", "serviceToCustomer", "Services")]
        public EntityCollection<Service> Services
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<Service>("PaymentsModel.serviceToCustomer", "Services");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedCollection<Service>("PaymentsModel.serviceToCustomer", "Services", value);
                }
            }
        }

        #endregion
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="PaymentsModel", Name="DirectDebitPaymentMethod")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class DirectDebitPaymentMethod : PaymentMethod
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new DirectDebitPaymentMethod object.
        /// </summary>
        /// <param name="id">Initial value of the id property.</param>
        /// <param name="status">Initial value of the status property.</param>
        /// <param name="registrationDate">Initial value of the registrationDate property.</param>
        public static DirectDebitPaymentMethod CreateDirectDebitPaymentMethod(global::System.Int32 id, global::System.Byte status, global::System.DateTime registrationDate)
        {
            DirectDebitPaymentMethod directDebitPaymentMethod = new DirectDebitPaymentMethod();
            directDebitPaymentMethod.id = id;
            directDebitPaymentMethod.status = status;
            directDebitPaymentMethod.registrationDate = registrationDate;
            return directDebitPaymentMethod;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String bankAccountNumber
        {
            get
            {
                return _bankAccountNumber;
            }
            set
            {
                OnbankAccountNumberChanging(value);
                ReportPropertyChanging("bankAccountNumber");
                _bankAccountNumber = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("bankAccountNumber");
                OnbankAccountNumberChanged();
            }
        }
        private global::System.String _bankAccountNumber;
        partial void OnbankAccountNumberChanging(global::System.String value);
        partial void OnbankAccountNumberChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public global::System.String holderName
        {
            get
            {
                return _holderName;
            }
            set
            {
                OnholderNameChanging(value);
                ReportPropertyChanging("holderName");
                _holderName = StructuralObject.SetValidValue(value, true);
                ReportPropertyChanged("holderName");
                OnholderNameChanged();
            }
        }
        private global::System.String _holderName;
        partial void OnholderNameChanging(global::System.String value);
        partial void OnholderNameChanged();

        #endregion
    
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="PaymentsModel", Name="PaymentMethod")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    [KnownTypeAttribute(typeof(CreditCardPaymentMethod))]
    [KnownTypeAttribute(typeof(DirectDebitPaymentMethod))]
    public abstract partial class PaymentMethod : EntityObject
    {
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 id
        {
            get
            {
                return _id;
            }
            set
            {
                if (_id != value)
                {
                    OnidChanging(value);
                    ReportPropertyChanging("id");
                    _id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("id");
                    OnidChanged();
                }
            }
        }
        private global::System.Int32 _id;
        partial void OnidChanging(global::System.Int32 value);
        partial void OnidChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Byte status
        {
            get
            {
                return _status;
            }
            set
            {
                OnstatusChanging(value);
                ReportPropertyChanging("status");
                _status = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("status");
                OnstatusChanged();
            }
        }
        private global::System.Byte _status;
        partial void OnstatusChanging(global::System.Byte value);
        partial void OnstatusChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.DateTime registrationDate
        {
            get
            {
                return _registrationDate;
            }
            set
            {
                OnregistrationDateChanging(value);
                ReportPropertyChanging("registrationDate");
                _registrationDate = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("registrationDate");
                OnregistrationDateChanged();
            }
        }
        private global::System.DateTime _registrationDate;
        partial void OnregistrationDateChanging(global::System.DateTime value);
        partial void OnregistrationDateChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PaymentsModel", "paymentMethodAssignedTo", "Customers")]
        public Customer AssignedTo
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Customer>("PaymentsModel.paymentMethodAssignedTo", "Customers").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Customer>("PaymentsModel.paymentMethodAssignedTo", "Customers").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Customer> AssignedToReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Customer>("PaymentsModel.paymentMethodAssignedTo", "Customers");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Customer>("PaymentsModel.paymentMethodAssignedTo", "Customers", value);
                }
            }
        }

        #endregion
    }
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="PaymentsModel", Name="Service")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class Service : EntityObject
    {
        #region Factory Method
    
        /// <summary>
        /// Create a new Service object.
        /// </summary>
        /// <param name="id">Initial value of the Id property.</param>
        /// <param name="name">Initial value of the Name property.</param>
        /// <param name="monthlyFee">Initial value of the MonthlyFee property.</param>
        public static Service CreateService(global::System.Int32 id, global::System.String name, global::System.Decimal monthlyFee)
        {
            Service service = new Service();
            service.Id = id;
            service.Name = name;
            service.MonthlyFee = monthlyFee;
            return service;
        }

        #endregion
        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Int32 Id
        {
            get
            {
                return _Id;
            }
            set
            {
                if (_Id != value)
                {
                    OnIdChanging(value);
                    ReportPropertyChanging("Id");
                    _Id = StructuralObject.SetValidValue(value);
                    ReportPropertyChanged("Id");
                    OnIdChanged();
                }
            }
        }
        private global::System.Int32 _Id;
        partial void OnIdChanging(global::System.Int32 value);
        partial void OnIdChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.String Name
        {
            get
            {
                return _Name;
            }
            set
            {
                OnNameChanging(value);
                ReportPropertyChanging("Name");
                _Name = StructuralObject.SetValidValue(value, false);
                ReportPropertyChanged("Name");
                OnNameChanged();
            }
        }
        private global::System.String _Name;
        partial void OnNameChanging(global::System.String value);
        partial void OnNameChanged();
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public global::System.Decimal MonthlyFee
        {
            get
            {
                return _MonthlyFee;
            }
            set
            {
                OnMonthlyFeeChanging(value);
                ReportPropertyChanging("MonthlyFee");
                _MonthlyFee = StructuralObject.SetValidValue(value);
                ReportPropertyChanged("MonthlyFee");
                OnMonthlyFeeChanged();
            }
        }
        private global::System.Decimal _MonthlyFee;
        partial void OnMonthlyFeeChanging(global::System.Decimal value);
        partial void OnMonthlyFeeChanged();

        #endregion
    
        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PaymentsModel", "serviceToCustomer", "Customer")]
        public Customer BoughtBy
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Customer>("PaymentsModel.serviceToCustomer", "Customer").Value;
            }
            set
            {
                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Customer>("PaymentsModel.serviceToCustomer", "Customer").Value = value;
            }
        }
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<Customer> BoughtByReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<Customer>("PaymentsModel.serviceToCustomer", "Customer");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<Customer>("PaymentsModel.serviceToCustomer", "Customer", value);
                }
            }
        }

        #endregion
    }

    #endregion
    
}
